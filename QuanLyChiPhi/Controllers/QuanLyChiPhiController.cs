using Microsoft.AspNetCore.Mvc;
using QuanLyChiPhi.Common;
using QuanLyChiPhi.Entities;
using QuanLyChiPhi.Model;
using static QuanLyChiPhi.Common.DefineData;

namespace QuanLyChiPhi.Controllers
{
    [Route("QuanLyChiPhi")]
    public class QuanLyChiPhiController : BaseController
    {
        private readonly Model.QuanLyChiPhi _QuanLyChiPhi;

        public QuanLyChiPhiController(Model.QuanLyChiPhi QuanLyChiPhi)
        {
            _QuanLyChiPhi = QuanLyChiPhi;
        }
       
    }
}
