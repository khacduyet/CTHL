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

        #region Chung cư
        [HttpGet("GetListChungCu")]
        public async Task<IActionResult> GetListChungCu()
        {
            CurrentUser currUser = GetRequest("GetListChungCu");
            if (!string.IsNullOrEmpty(currUser.Id))
            {
                _QuanLyChiPhi.SetCurrentUser(currUser);
                var listItem = _QuanLyChiPhi.GetListChungCu();
                return Ok(listItem);
            }
            else
                return Ok(new ErrorMessage(ErrorMessage.eState.ChuaDangNhap));
        }
        [HttpGet("GetChungCu")]
        public async Task<IActionResult> GetChungCu(string Id)
        {
            CurrentUser currUser = GetRequest("GetChungCu");
            if (!string.IsNullOrEmpty(currUser.Id))
            {
                _QuanLyChiPhi.SetCurrentUser(currUser);
                var listItem = _QuanLyChiPhi.GetChungCu(Id);
                return Ok(listItem);
            }
            else
                return Ok(new ErrorMessage(ErrorMessage.eState.ChuaDangNhap));
        }
        [HttpPost("SetChungCu")]
        public async Task<IActionResult> SetChungCu([FromBody] ChungCu data)
        {
            CurrentUser currUser = GetRequest("SetChungCu");
            if (!string.IsNullOrEmpty(currUser.Id))
            {
                _QuanLyChiPhi.SetCurrentUser(currUser);
                var listItem = _QuanLyChiPhi.SetChungCu(data);
                return Ok(listItem);
            }
            else
                return Ok(new ErrorMessage(ErrorMessage.eState.ChuaDangNhap));
        }
        [HttpGet("DeleteChungCu")]
        public async Task<IActionResult> DeleteChungCu(string Id)
        {
            CurrentUser currUser = GetRequest("DeleteChungCu");
            if (!string.IsNullOrEmpty(currUser.Id))
            {
                _QuanLyChiPhi.SetCurrentUser(currUser);
                var listItem = _QuanLyChiPhi.DeleteChungCu(Id);
                return Ok(listItem);
            }
            else
                return Ok(new ErrorMessage(ErrorMessage.eState.ChuaDangNhap));
        }
        #endregion

        #region Loại dịch vụ
        [HttpGet("GetListLoaiDichVu")]
        public async Task<IActionResult> GetListLoaiDichVu()
        {
            CurrentUser currUser = GetRequest("GetListLoaiDichVu");
            if (!string.IsNullOrEmpty(currUser.Id))
            {
                _QuanLyChiPhi.SetCurrentUser(currUser);
                var listItem = _QuanLyChiPhi.GetListLoaiDichVu();
                return Ok(listItem);
            }
            else
                return Ok(new ErrorMessage(ErrorMessage.eState.ChuaDangNhap));
        }
        [HttpGet("GetLoaiDichVu")]
        public async Task<IActionResult> GetLoaiDichVu(string Id)
        {
            CurrentUser currUser = GetRequest("GetLoaiDichVu");
            if (!string.IsNullOrEmpty(currUser.Id))
            {
                _QuanLyChiPhi.SetCurrentUser(currUser);
                var listItem = _QuanLyChiPhi.GetLoaiDichVu(Id);
                return Ok(listItem);
            }
            else
                return Ok(new ErrorMessage(ErrorMessage.eState.ChuaDangNhap));
        }
        [HttpPost("SetLoaiDichVu")]
        public async Task<IActionResult> SetLoaiDichVu([FromBody] LoaiDichVu data)
        {
            CurrentUser currUser = GetRequest("SetLoaiDichVu");
            if (!string.IsNullOrEmpty(currUser.Id))
            {
                _QuanLyChiPhi.SetCurrentUser(currUser);
                var listItem = _QuanLyChiPhi.SetLoaiDichVu(data);
                return Ok(listItem);
            }
            else
                return Ok(new ErrorMessage(ErrorMessage.eState.ChuaDangNhap));
        }
        [HttpGet("DeleteLoaiDichVu")]
        public async Task<IActionResult> DeleteLoaiDichVu(string Id)
        {
            CurrentUser currUser = GetRequest("DeleteLoaiDichVu");
            if (!string.IsNullOrEmpty(currUser.Id))
            {
                _QuanLyChiPhi.SetCurrentUser(currUser);
                var listItem = _QuanLyChiPhi.DeleteLoaiDichVu(Id);
                return Ok(listItem);
            }
            else
                return Ok(new ErrorMessage(ErrorMessage.eState.ChuaDangNhap));
        }
        #endregion

        #region   Loại xe
        [HttpGet("GetListLoaiXe")]
        public async Task<IActionResult> GetListLoaiXe()
        {
            CurrentUser currUser = GetRequest("GetListLoaiXe");
            if (!string.IsNullOrEmpty(currUser.Id))
            {
                _QuanLyChiPhi.SetCurrentUser(currUser);
                var listItem = _QuanLyChiPhi.GetListLoaiXe();
                return Ok(listItem);
            }
            else
                return Ok(new ErrorMessage(ErrorMessage.eState.ChuaDangNhap));
        }
        [HttpGet("GetLoaiXe")]
        public async Task<IActionResult> GetLoaiXe(string Id)
        {
            CurrentUser currUser = GetRequest("GetLoaiXe");
            if (!string.IsNullOrEmpty(currUser.Id))
            {
                _QuanLyChiPhi.SetCurrentUser(currUser);
                var listItem = _QuanLyChiPhi.GetLoaiXe(Id);
                return Ok(listItem);
            }
            else
                return Ok(new ErrorMessage(ErrorMessage.eState.ChuaDangNhap));
        }
        [HttpPost("SetLoaiXe")]
        public async Task<IActionResult> SetLoaiXe([FromBody] LoaiXe data)
        {
            CurrentUser currUser = GetRequest("SetLoaiXe");
            if (!string.IsNullOrEmpty(currUser.Id))
            {
                _QuanLyChiPhi.SetCurrentUser(currUser);
                var listItem = _QuanLyChiPhi.SetLoaiXe(data);
                return Ok(listItem);
            }
            else
                return Ok(new ErrorMessage(ErrorMessage.eState.ChuaDangNhap));
        }
        [HttpGet("DeleteLoaiXe")]
        public async Task<IActionResult> DeleteLoaiXe(string Id)
        {
            CurrentUser currUser = GetRequest("DeleteLoaiXe");
            if (!string.IsNullOrEmpty(currUser.Id))
            {
                _QuanLyChiPhi.SetCurrentUser(currUser);
                var listItem = _QuanLyChiPhi.DeleteLoaiXe(Id);
                return Ok(listItem);
            }
            else
                return Ok(new ErrorMessage(ErrorMessage.eState.ChuaDangNhap));
        }
        #endregion

        #region Phương tiện
        [HttpGet("GetListPhuongTien")]
        public async Task<IActionResult> GetListPhuongTien()
        {
            CurrentUser currUser = GetRequest("GetListPhuongTien");
            if (!string.IsNullOrEmpty(currUser.Id))
            {
                _QuanLyChiPhi.SetCurrentUser(currUser);
                var listItem = _QuanLyChiPhi.GetListPhuongTien();
                return Ok(listItem);
            }
            else
                return Ok(new ErrorMessage(ErrorMessage.eState.ChuaDangNhap));
        }
        [HttpGet("GetPhuongTien")]
        public async Task<IActionResult> GetPhuongTien(string Id)
        {
            CurrentUser currUser = GetRequest("GetPhuongTien");
            if (!string.IsNullOrEmpty(currUser.Id))
            {
                _QuanLyChiPhi.SetCurrentUser(currUser);
                var listItem = _QuanLyChiPhi.GetPhuongTien(Id);
                return Ok(listItem);
            }
            else
                return Ok(new ErrorMessage(ErrorMessage.eState.ChuaDangNhap));
        }
        [HttpPost("SetPhuongTien")]
        public async Task<IActionResult> SetPhuongTien([FromBody] PhuongTien data)
        {
            CurrentUser currUser = GetRequest("SetPhuongTien");
            if (!string.IsNullOrEmpty(currUser.Id))
            {
                _QuanLyChiPhi.SetCurrentUser(currUser);
                var listItem = _QuanLyChiPhi.SetPhuongTien(data);
                return Ok(listItem);
            }
            else
                return Ok(new ErrorMessage(ErrorMessage.eState.ChuaDangNhap));
        }
        [HttpGet("DeletePhuongTien")]
        public async Task<IActionResult> DeletePhuongTien(string Id)
        {
            CurrentUser currUser = GetRequest("DeletePhuongTien");
            if (!string.IsNullOrEmpty(currUser.Id))
            {
                _QuanLyChiPhi.SetCurrentUser(currUser);
                var listItem = _QuanLyChiPhi.DeleteLoaiXe(Id);
                return Ok(listItem);
            }
            else
                return Ok(new ErrorMessage(ErrorMessage.eState.ChuaDangNhap));
        }
        #endregion

        #region  Loại đóng phí
        [HttpGet("GetListLoaiDongPhi")]
        public async Task<IActionResult> GetListLoaiDongPhi()
        {
            CurrentUser currUser = GetRequest("GetListLoaiDongPhi");
            if (!string.IsNullOrEmpty(currUser.Id))
            {
                _QuanLyChiPhi.SetCurrentUser(currUser);
                var listItem = _QuanLyChiPhi.GetListLoaiDongPhi();
                return Ok(listItem);
            }
            else
                return Ok(new ErrorMessage(ErrorMessage.eState.ChuaDangNhap));
        }
        [HttpGet("GetLoaiDongPhi")]
        public async Task<IActionResult> GetLoaiDongPhi(string Id)
        {
            CurrentUser currUser = GetRequest("GetLoaiDongPhi");
            if (!string.IsNullOrEmpty(currUser.Id))
            {
                _QuanLyChiPhi.SetCurrentUser(currUser);
                var listItem = _QuanLyChiPhi.GetLoaiDongPhi(Id);
                return Ok(listItem);
            }
            else
                return Ok(new ErrorMessage(ErrorMessage.eState.ChuaDangNhap));
        }
        [HttpPost("SetLoaiDongPhi")]
        public async Task<IActionResult> SetLoaiDongPhi([FromBody] LoaiDongPhi data)
        {
            CurrentUser currUser = GetRequest("SetLoaiDongPhi");
            if (!string.IsNullOrEmpty(currUser.Id))
            {
                _QuanLyChiPhi.SetCurrentUser(currUser);
                var listItem = _QuanLyChiPhi.SetLoaiDongPhi(data);
                return Ok(listItem);
            }
            else
                return Ok(new ErrorMessage(ErrorMessage.eState.ChuaDangNhap));
        }
        [HttpGet("DeleteLoaiDongPhi")]
        public async Task<IActionResult> DeleteLoaiDongPhi(string Id)
        {
            CurrentUser currUser = GetRequest("DeleteLoaiDongPhi");
            if (!string.IsNullOrEmpty(currUser.Id))
            {
                _QuanLyChiPhi.SetCurrentUser(currUser);
                var listItem = _QuanLyChiPhi.DeleteLoaiDongPhi(Id);
                return Ok(listItem);
            }
            else
                return Ok(new ErrorMessage(ErrorMessage.eState.ChuaDangNhap));
        }
        #endregion

        #region  Căn hộ
        [HttpPost("GetListCanHo")]
        public async Task<IActionResult> GetListCanHo([FromBody] TimKiem timKiem)
        {
            CurrentUser currUser = GetRequest("GetListCanHo");
            if (!string.IsNullOrEmpty(currUser.Id))
            {
                _QuanLyChiPhi.SetCurrentUser(currUser);
                var listItem = _QuanLyChiPhi.GetListCanHo(timKiem);
                return Ok(listItem);
            }
            else
                return Ok(new ErrorMessage(ErrorMessage.eState.ChuaDangNhap));
        }
        [HttpGet("GetCanHo")]
        public async Task<IActionResult> GetCanHo(string Id)
        {
            CurrentUser currUser = GetRequest("GetCanHo");
            if (!string.IsNullOrEmpty(currUser.Id))
            {
                _QuanLyChiPhi.SetCurrentUser(currUser);
                var listItem = _QuanLyChiPhi.GetCanHo(Id);
                return Ok(listItem);
            }
            else
                return Ok(new ErrorMessage(ErrorMessage.eState.ChuaDangNhap));
        }
        [HttpPost("SetCanHo")]
        public async Task<IActionResult> SetCanHo([FromBody] CanHo data)
        {
            CurrentUser currUser = GetRequest("SetCanHo");
            if (!string.IsNullOrEmpty(currUser.Id))
            {
                _QuanLyChiPhi.SetCurrentUser(currUser);
                var listItem = _QuanLyChiPhi.SetCanHo(data);
                return Ok(listItem);
            }
            else
                return Ok(new ErrorMessage(ErrorMessage.eState.ChuaDangNhap));
        }
        [HttpGet("DeleteCanHo")]
        public async Task<IActionResult> DeleteCanHo(string Id)
        {
            CurrentUser currUser = GetRequest("DeleteCanHo");
            if (!string.IsNullOrEmpty(currUser.Id))
            {
                _QuanLyChiPhi.SetCurrentUser(currUser);
                var listItem = _QuanLyChiPhi.DeleteCanHo(Id);
                return Ok(listItem);
            }
            else
                return Ok(new ErrorMessage(ErrorMessage.eState.ChuaDangNhap));
        }
        #endregion

        #region  Xe ngoài
        [HttpPost("GetListXeNgoai")]
        public async Task<IActionResult> GetListXeNgoai([FromBody] TimKiem timKiem)
        {
            CurrentUser currUser = GetRequest("GetListXeNgoai");
            if (!string.IsNullOrEmpty(currUser.Id))
            {
                _QuanLyChiPhi.SetCurrentUser(currUser);
                var listItem = _QuanLyChiPhi.GetListXeNgoai(timKiem);
                return Ok(listItem);
            }
            else
                return Ok(new ErrorMessage(ErrorMessage.eState.ChuaDangNhap));
        }
        [HttpGet("GetXeNgoai")]
        public async Task<IActionResult> GetXeNgoai(string Id)
        {
            CurrentUser currUser = GetRequest("GetXeNgoai");
            if (!string.IsNullOrEmpty(currUser.Id))
            {
                _QuanLyChiPhi.SetCurrentUser(currUser);
                var listItem = _QuanLyChiPhi.GetXeNgoai(Id);
                return Ok(listItem);
            }
            else
                return Ok(new ErrorMessage(ErrorMessage.eState.ChuaDangNhap));
        }
        [HttpPost("SetXeNgoai")]
        public async Task<IActionResult> SetXeNgoai([FromBody] XeNgoai data)
        {
            CurrentUser currUser = GetRequest("SetCanHo");
            if (!string.IsNullOrEmpty(currUser.Id))
            {
                _QuanLyChiPhi.SetCurrentUser(currUser);
                var listItem = _QuanLyChiPhi.SetXeNgoai(data);
                return Ok(listItem);
            }
            else
                return Ok(new ErrorMessage(ErrorMessage.eState.ChuaDangNhap));
        }
        [HttpGet("DeleteXeNgoai")]
        public async Task<IActionResult> DeleteXeNgoai(string Id)
        {
            CurrentUser currUser = GetRequest("DeleteXeNgoai");
            if (!string.IsNullOrEmpty(currUser.Id))
            {
                _QuanLyChiPhi.SetCurrentUser(currUser);
                var listItem = _QuanLyChiPhi.DeleteXeNgoai(Id);
                return Ok(listItem);
            }
            else
                return Ok(new ErrorMessage(ErrorMessage.eState.ChuaDangNhap));
        }
        #endregion

        #region  Quản lý phí
        [HttpGet("GetListQuanLyPhi")]
        public async Task<IActionResult> GetListQuanLyPhi()
        {
            CurrentUser currUser = GetRequest("GetListQuanLyPhi");
            if (!string.IsNullOrEmpty(currUser.Id))
            {
                _QuanLyChiPhi.SetCurrentUser(currUser);
                var listItem = _QuanLyChiPhi.GetListQuanLyPhi();
                return Ok(listItem);
            }
            else
                return Ok(new ErrorMessage(ErrorMessage.eState.ChuaDangNhap));
        }
        [HttpGet("GetQuanLyPhi")]
        public async Task<IActionResult> GetQuanLyPhi(string Id)
        {
            CurrentUser currUser = GetRequest("GetQuanLyPhi");
            if (!string.IsNullOrEmpty(currUser.Id))
            {
                _QuanLyChiPhi.SetCurrentUser(currUser);
                var listItem = _QuanLyChiPhi.GetQuanLyPhi(Id);
                return Ok(listItem);
            }
            else
                return Ok(new ErrorMessage(ErrorMessage.eState.ChuaDangNhap));
        }
        [HttpPost("SetQuanLyPhi")]
        public async Task<IActionResult> SetQuanLyPhi([FromBody] QuanLyPhi data)
        {
            CurrentUser currUser = GetRequest("SetQuanLyPhi");
            if (!string.IsNullOrEmpty(currUser.Id))
            {
                _QuanLyChiPhi.SetCurrentUser(currUser);
                var listItem = _QuanLyChiPhi.SetQuanLyPhi(data);
                return Ok(listItem);
            }
            else
                return Ok(new ErrorMessage(ErrorMessage.eState.ChuaDangNhap));
        }
        
        [HttpGet("DeleteQuanLyPhi")]
        public async Task<IActionResult> DeleteQuanLyPhi(string Id)
        {
            CurrentUser currUser = GetRequest("DeleteQuanLyPhi");
            if (!string.IsNullOrEmpty(currUser.Id))
            {
                _QuanLyChiPhi.SetCurrentUser(currUser);
                var listItem = _QuanLyChiPhi.DeleteQuanLyPhi(Id);
                return Ok(listItem);
            }
            else
                return Ok(new ErrorMessage(ErrorMessage.eState.ChuaDangNhap));
        }

        [HttpPost("CreatePhieu")]
        public async Task<IActionResult> CreatePhieu([FromBody] TaoNhanhPhieu data)
        {
            CurrentUser currUser = GetRequest("CreatePhieu");
            if (!string.IsNullOrEmpty(currUser.Id))
            {
                _QuanLyChiPhi.SetCurrentUser(currUser);
                var listItem = _QuanLyChiPhi.CreatePhieu(data);
                return Ok(listItem);
            }
            else
                return Ok(new ErrorMessage(ErrorMessage.eState.ChuaDangNhap));
        }
        #endregion

    }
}
