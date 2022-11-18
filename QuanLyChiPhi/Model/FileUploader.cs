using QuanLyChiPhi.Common;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace QuanLyChiPhi.Model
{
    public class FileUploader
    {
        private readonly IWebHostEnvironment environment;
        public FileUploader(IWebHostEnvironment environment)
        {
            this.environment = environment;
        }
        
        public Task SavePostImageAsync(HDFileUpload postRequest)
        {
            var uniqueFileName = FileHelper.GetUniqueFileName(postRequest.File.FileName);

            var uploads = Path.Combine(environment.WebRootPath, "uploaded");

            var filePath = Path.Combine(uploads, uniqueFileName);

            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            postRequest.File.CopyToAsync(new FileStream(filePath, FileMode.Create));
            postRequest.Url = filePath;
            return null;
        }

        public HttpResponseMessage Get(string filename, string path, bool viewonly = false)
        {
            HttpResponseMessage result = null;

            FileInfo fi = new FileInfo(Dungchung.Base64Decode(path));
            if (string.IsNullOrEmpty(filename) == true || string.IsNullOrEmpty(Dungchung.Base64Decode(filename))
                || string.IsNullOrEmpty(path) == true || string.IsNullOrEmpty(Dungchung.Base64Decode(path)))
            {
                result = new HttpResponseMessage(HttpStatusCode.NotFound);
            }
            else if (File.Exists(Dungchung.Base64Decode(path)) || fi.Exists)
            {
                FileStream fs = new FileStream(Dungchung.Base64Decode(path), FileMode.Open);
                try
                {
                    result = new HttpResponseMessage(HttpStatusCode.OK);
                    result.Content = new StreamContent(fs);
                    //fs.Close();
                    var ex = Path.GetExtension(Dungchung.Base64Decode(path));
                    var listImage = new List<string>();
                    listImage.Add(".gif");
                    listImage.Add(".png");
                    listImage.Add(".jpg");
                    listImage.Add(".jpeg");
                    if (ex.ToLower() == ".pdf" && viewonly)
                    {
                        var filenameguid = Path.GetFileName(Dungchung.Base64Decode(path));
                        result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/pdf");
                        ContentDispositionHeaderValue contentDisposition = null;
                        if (ContentDispositionHeaderValue.TryParse("inline; filename=" + Dungchung.Base64Decode(filename), out contentDisposition))
                        {
                            result.Content.Headers.ContentDisposition = contentDisposition;
                        }
                        result.Content.Headers.ContentDisposition.FileName = Dungchung.Base64Decode(filename);
                        return result;
                    }
                    else if (listImage.Contains(ex.ToLower()) && viewonly)
                    {
                        var filenameguid = Path.GetFileName(Dungchung.Base64Decode(path));
                        string mimeType = MimeMapping.MimeUtility.GetMimeMapping(filenameguid);
                        result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(mimeType);
                        ContentDispositionHeaderValue contentDisposition = null;
                        if (ContentDispositionHeaderValue.TryParse("inline; filename=" + filenameguid, out contentDisposition))
                        {
                            result.Content.Headers.ContentDisposition = contentDisposition;
                        }
                        result.Content.Headers.ContentDisposition.FileName = filenameguid;
                        //fs.Close();
                        return result;
                    }
                    else
                    {
                        result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
                        result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                    }
                    result.Content.Headers.ContentDisposition.FileName = Dungchung.Base64Decode(filename);
                }
                catch (Exception)
                {
                    fs.Close();
                }
            }
            else
            {
                result = new HttpResponseMessage(HttpStatusCode.NotFound);
            }
            return result;
        }


        public class HDFileUpload
        {
            public HDFileUpload(string name, string namelocal, string url, string size)
            {
                Name = name;
                NameLocal = namelocal;
                Url = url;
                Size = size;
            }
            public IFormFile File { get; set; }
            public string Name { get; set; }
            public string NameLocal { get; set; }
            public string Url { get; set; }

            public string Size { get; set; }
        }
    }
}
