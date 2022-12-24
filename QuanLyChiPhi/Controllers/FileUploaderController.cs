using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using QuanLyChiPhi.Common;
using Microsoft.AspNetCore.Http.Extensions;
using static QuanLyChiPhi.Model.FileUploader;
using QuanLyChiPhi.Model;

namespace QuanLyChiPhi.Controllers
{
    [Route("FileUploader")]
    public class FileUploaderController : Controller
    {
        //private const string UploadFolder = "uploads";
        //private const string DownloadFolder = "uploaded";

        //[HttpPost("PostFile")]
        //public async Task<IActionResult> SubmitPost([FromForm] HttpRequest postRequest)
        //{
        //    if (!postRequest.Form.Files.Any())
        //    {
        //        return BadRequest("Không có file nào được đính kèm");
        //    }
        //    foreach (var item in postRequest.Form.Files)
        //    {
        //        using (var stream = new FileStream(@"c:\uploader\App_Data\uploads\" + item.FileName, FileMode.Create))
        //        {
        //            item.CopyTo(stream);
        //        }
        //    }
        //    return Ok("Tải lên thành công!");
        //}
        [HttpGet("DownloadFile")]
        public IActionResult DownloadFile(string FileName)
        {
            var memory = DownloadSinghFile(FileName, @"C:\uploader\App_Data\uploads\");
            return File(memory.ToArray(), "application/*", FileName);
        }

        private MemoryStream DownloadSinghFile(string filename, string uploadPath)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), uploadPath, filename);
            var memory = new MemoryStream();
            if (System.IO.File.Exists(path))
            {
                var net = new System.Net.WebClient();
                var data = net.DownloadData(path);
                var content = new System.IO.MemoryStream(data);
                memory = content;
            }
            memory.Position = 0;
            return memory;
        }
    }

}
