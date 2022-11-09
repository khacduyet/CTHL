using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuanLyChiPhi.Common;
using QuanLyChiPhi.Model;
using RestSharp;

namespace QuanLyChiPhi.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
        }


        [HttpGet]
        public CurrentUser GetRequest(string FuntionName)
        {
            CurrentUser User = new CurrentUser();
            string domain = Request.Scheme + Uri.SchemeDelimiter + Request.Host;

            //if (domain.Contains("localhost"))
            //{
            User.Id = "CONGTYHOALU";
            if (User.TenNhanVien == null)
                User.TenNhanVien = "Công ty Hoa Lư";
            return User;
            //}
            //string Cookies = Request.Headers["cookie"];

            //try
            //{
            //    string ApiBaseUrl = domain;
            //    // Define a resource path
            //    string resourcePath = "/SmartEOSAPI/QuanTri/GetCurrentUser";
            //    // Define a client
            //    var client = new RestClient(ApiBaseUrl);
            //    // Define a request
            //    var request = new RestRequest(resourcePath, Method.GET);
            //    // Add headers
            //    request.AddHeader("Content-Type", "application/json");

            //    request.AddHeader("Accept", "application/json");
            //    request.AddHeader("cookie", Cookies);
            //    request.AddParameter("application/json", ParameterType.RequestBody);
            //    var response = client.Execute(request);

            //    string Response = response.Content.ToString();
            //    User = JsonConvert.DeserializeObject<CurrentUser>(Response);

            //    return User;
            //}
            //catch
            //{
            //    return User;
            //}
        }
    }
}
