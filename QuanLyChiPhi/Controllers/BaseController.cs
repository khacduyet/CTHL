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

            if (domain.Contains("localhost") || domain.Contains("10.0.5.25"))
            {
                User.Id = "TAPDOANDETMAY";
                User.Cookies = ".ASPXAUTH=8FFFE7A78EE285E5A9CF5D2B3A449C19976940156A77682CC47468AE9C6E958540C93808120630432BCE55B6EF89210A733121777A59B6966F03086E067D225CC068902AC129F3ECBAFC38145E463C41EA6234317D7937FAAA8F9D354B4F19B8; .AspNet.Cookies=YiSZ6k0Dn_EyCCYdxWaG4t5Oeac-u9ERFo46dT35Q_BRZV6WexkU8PP7U5-7mmOF8wZyvd1DwX3ywwgxSZ0a52HRxgh9z-Cx5HNVSrtcZ6i5nd8L0hnKjvkBQf21kBEHE2I-YL5rixdmfhJku9oCPZeS-VZTi97CPENmsFIzuruDO48jkc1kxi28V0ET7tWv0i0MjjYpa7UNcgPmha2TFSWmOlyUIxqjB_1bJUSlTRiBr5EY23R1P4t3qEiRLrenlgw4q7VMN3njgjMQQlwFly4y8558tFAbhZG1URZIVw3Z0v6a4kWhzGs9V5YUovcS5i0nPacpU0URntVTGuLDjKUxMtK_B48NBgLuAgeSzuPzyd_6GoIPe46qyR-7JimwT7GYd35NNsXN0fE_Mjt4zLRANa9FtKeMScymwPfj7sEsja5I3nm-c-r_M_D9-sL8sD0infam5IHw59Yf2Ofjew";
                if (User.TenNhanVien == null)
                    User.TenNhanVien = "Tập đoàn dệt may Vinatex";
                return User;
            }
            string Cookies = Request.Headers["cookie"];

            try
            {
                string ApiBaseUrl = domain;
                // Define a resource path
                string resourcePath = "/SmartEOSAPI/QuanTri/GetCurrentUser";
                // Define a client
                var client = new RestClient(ApiBaseUrl);
                // Define a request
                var request = new RestRequest(resourcePath, Method.GET);
                // Add headers
                request.AddHeader("Content-Type", "application/json");

                request.AddHeader("Accept", "application/json");
                request.AddHeader("cookie", Cookies);
                request.AddParameter("application/json", ParameterType.RequestBody);
                var response = client.Execute(request);

                string Response = response.Content.ToString();
                User = JsonConvert.DeserializeObject<CurrentUser>(Response);
                User.Cookies = Cookies.Trim();

                return User;
            }
            catch
            {
                return User;
            }
        }
    }
}
