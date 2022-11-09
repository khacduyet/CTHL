using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OfficeOpenXml;
using QuanLyChiPhi.Common;
using QuanLyChiPhi.Entities;
using static QuanLyChiPhi.Common.DefineData;

namespace QuanLyChiPhi.Model
{
    public class QuanLyChiPhi
    {
        private readonly ApplicationContext _dbContext;
        private readonly AppSettings _appSettings;

        public QuanLyChiPhi(ApplicationContext dbContext, IOptions<AppSettings> appSettings)
        {
            _dbContext = dbContext;
            _appSettings = appSettings.Value;
        }

        public void SetCurrentUser(CurrentUser currentUser)
        {
            _dbContext.currentUser = currentUser;
        }

        #region Chung cư
        public ErrorMessage GetListChungCu()
        {
            ErrorMessage msg = new ErrorMessage(ErrorMessage.eState.ThanhCong);
            var data = _dbContext.ChungCu.ToList();
            msg.Data = data;
            return msg;
        }
        public ErrorMessage GetChungCu(string Id)
        {
            ErrorMessage msg = new ErrorMessage(ErrorMessage.eState.ThanhCong);
            var data = _dbContext.ChungCu.Find(Id);
            if (data != null)
            {
                msg.Data = data;
            }
            else
            {
                msg.SetLoi("Không tồn tại chung cư này!");
            }
            return msg;
        }
        public ErrorMessage SetChungCu(ChungCu data)
        {
            using (var trans = _dbContext.Database.BeginTransaction())
            {
                ErrorMessage msg = new ErrorMessage(ErrorMessage.eState.ThanhCong);
                try
                {
                    var checkMa = _dbContext.ChungCu.AsNoTracking().FirstOrDefault(x => x.Ma == data.Ma);
                    if (checkMa != null)
                    {
                        msg.SetLoi("Đã tồn tại mã: " + checkMa.Ma);
                        trans.Rollback();
                        return msg;
                    }
                    if (string.IsNullOrEmpty(data.Id))
                    {
                        data.Id = Guid.NewGuid().ToString();
                        _dbContext.Add(data);
                    }
                    else
                        _dbContext.Update(data);
                    _dbContext.SaveChanges();
                    trans.Commit();
                    return msg;
                }
                catch (Exception)
                {
                    msg.SetLoi("Đã có lỗi xảy ra!");
                    trans.Rollback();
                    return msg;
                }
            }
        }
        public ErrorMessage DeleteChungCu(string Id)
        {
            ErrorMessage msg = new ErrorMessage(ErrorMessage.eState.ThanhCong);
            var data = _dbContext.ChungCu.Find(Id);
            if (data != null)
            {
                _dbContext.Remove(data);
                _dbContext.SaveChanges();
            }
            else
            {
                msg.SetLoi("Không tồn tại chung cư này!");
            }
            return msg;
        }
        #endregion

        #region Loại dịch vụ
        public ErrorMessage GetListLoaiDichVu()
        {
            ErrorMessage msg = new ErrorMessage(ErrorMessage.eState.ThanhCong);
            var data = _dbContext.LoaiDichVu.ToList();
            msg.Data = data;
            return msg;
        }
        public ErrorMessage GetLoaiDichVu(string Id)
        {
            ErrorMessage msg = new ErrorMessage(ErrorMessage.eState.ThanhCong);
            var data = _dbContext.LoaiDichVu.Find(Id);
            if (data != null)
            {
                msg.Data = data;
            }
            else
            {
                msg.SetLoi("Không tồn tại!");
            }
            return msg;
        }
        public ErrorMessage SetLoaiDichVu(LoaiDichVu data)
        {
            using (var trans = _dbContext.Database.BeginTransaction())
            {
                ErrorMessage msg = new ErrorMessage(ErrorMessage.eState.ThanhCong);
                try
                {
                    var checkMa = _dbContext.LoaiDichVu.AsNoTracking().FirstOrDefault(x => x.Ma == data.Ma);
                    if (checkMa != null)
                    {
                        msg.SetLoi("Đã tồn tại mã: " + checkMa.Ma);
                        trans.Rollback();
                        return msg;
                    }
                    if (string.IsNullOrEmpty(data.Id))
                    {
                        data.Id = Guid.NewGuid().ToString();
                        _dbContext.Add(data);
                    }
                    else
                        _dbContext.Update(data);
                    _dbContext.SaveChanges();
                    trans.Commit();
                    return msg;
                }
                catch (Exception)
                {
                    msg.SetLoi("Đã có lỗi xảy ra!");
                    trans.Rollback();
                    return msg;
                }
            }
        }
        public ErrorMessage DeleteLoaiDichVu(string Id)
        {
            ErrorMessage msg = new ErrorMessage(ErrorMessage.eState.ThanhCong);
            var data = _dbContext.LoaiDichVu.Find(Id);
            if (data != null)
            {
                _dbContext.Remove(data);
                _dbContext.SaveChanges();
            }
            else
            {
                msg.SetLoi("Không tồn tại!");
            }
            return msg;
        }
        #endregion

        #region Loại xe
        public ErrorMessage GetListLoaiXe()
        {
            ErrorMessage msg = new ErrorMessage(ErrorMessage.eState.ThanhCong);
            var data = _dbContext.LoaiXe.ToList();
            msg.Data = data;
            return msg;
        }
        public ErrorMessage GetLoaiXe(string Id)
        {
            ErrorMessage msg = new ErrorMessage(ErrorMessage.eState.ThanhCong);
            var data = _dbContext.LoaiXe.Find(Id);
            if (data != null)
            {
                msg.Data = data;
            }
            else
            {
                msg.SetLoi("Không tồn tại!");
            }
            return msg;
        }
        public ErrorMessage SetLoaiXe(LoaiXe data)
        {
            using (var trans = _dbContext.Database.BeginTransaction())
            {
                ErrorMessage msg = new ErrorMessage(ErrorMessage.eState.ThanhCong);
                try
                {
                    var checkMa = _dbContext.LoaiXe.AsNoTracking().FirstOrDefault(x => x.Ma == data.Ma);
                    if (checkMa != null)
                    {
                        msg.SetLoi("Đã tồn tại mã: " + checkMa.Ma);
                        trans.Rollback();
                        return msg;
                    }
                    if (string.IsNullOrEmpty(data.Id))
                    {
                        data.Id = Guid.NewGuid().ToString();
                        _dbContext.Add(data);
                    }
                    else
                        _dbContext.Update(data);
                    _dbContext.SaveChanges();
                    trans.Commit();
                    return msg;
                }
                catch (Exception)
                {
                    msg.SetLoi("Đã có lỗi xảy ra!");
                    trans.Rollback();
                    return msg;
                }
            }
        }
        public ErrorMessage DeleteLoaiXe(string Id)
        {
            ErrorMessage msg = new ErrorMessage(ErrorMessage.eState.ThanhCong);
            var data = _dbContext.LoaiXe.Find(Id);
            if (data != null)
            {
                _dbContext.Remove(data);
                _dbContext.SaveChanges();
            }
            else
            {
                msg.SetLoi("Không tồn tại!");
            }
            return msg;
        }
        #endregion

        #region Phương tiện
        public ErrorMessage GetListPhuongTien()
        {
            ErrorMessage msg = new ErrorMessage(ErrorMessage.eState.ThanhCong);
            var data = _dbContext.PhuongTien.ToList();
            msg.Data = data;
            return msg;
        }
        public ErrorMessage GetPhuongTien(string Id)
        {
            ErrorMessage msg = new ErrorMessage(ErrorMessage.eState.ThanhCong);
            var data = _dbContext.PhuongTien.Find(Id);
            if (data != null)
            {
                msg.Data = data;
            }
            else
            {
                msg.SetLoi("Không tồn tại!");
            }
            return msg;
        }
        public ErrorMessage SetPhuongTien(PhuongTien data)
        {
            using (var trans = _dbContext.Database.BeginTransaction())
            {
                ErrorMessage msg = new ErrorMessage(ErrorMessage.eState.ThanhCong);
                try
                {
                    var checkMa = _dbContext.PhuongTien.AsNoTracking().FirstOrDefault(x => x.Ma == data.Ma);
                    if (checkMa != null)
                    {
                        msg.SetLoi("Đã tồn tại mã: " + checkMa.Ma);
                        trans.Rollback();
                        return msg;
                    }
                    if (string.IsNullOrEmpty(data.Id))
                    {
                        data.Id = Guid.NewGuid().ToString();
                        _dbContext.Add(data);
                    }
                    else
                        _dbContext.Update(data);
                    _dbContext.SaveChanges();
                    trans.Commit();
                    return msg;
                }
                catch (Exception)
                {
                    msg.SetLoi("Đã có lỗi xảy ra!");
                    trans.Rollback();
                    return msg;
                }
            }
        }
        public ErrorMessage DeletePhuongTien(string Id)
        {
            ErrorMessage msg = new ErrorMessage(ErrorMessage.eState.ThanhCong);
            var data = _dbContext.PhuongTien.Find(Id);
            if (data != null)
            {
                _dbContext.Remove(data);
                _dbContext.SaveChanges();
            }
            else
            {
                msg.SetLoi("Không tồn tại!");
            }
            return msg;
        }
        #endregion

        #region Loại đóng phí
        public ErrorMessage GetListLoaiDongPhi()
        {
            ErrorMessage msg = new ErrorMessage(ErrorMessage.eState.ThanhCong);
            var data = _dbContext.LoaiDongPhi.ToList();
            msg.Data = data;
            return msg;
        }
        public ErrorMessage GetLoaiDongPhi(string Id)
        {
            ErrorMessage msg = new ErrorMessage(ErrorMessage.eState.ThanhCong);
            var data = _dbContext.LoaiDongPhi.Find(Id);
            if (data != null)
            {
                msg.Data = data;
            }
            else
            {
                msg.SetLoi("Không tồn tại!");
            }
            return msg;
        }
        public ErrorMessage SetLoaiDongPhi(LoaiDongPhi data)
        {
            using (var trans = _dbContext.Database.BeginTransaction())
            {
                ErrorMessage msg = new ErrorMessage(ErrorMessage.eState.ThanhCong);
                try
                {
                    var checkMa = _dbContext.LoaiDongPhi.AsNoTracking().FirstOrDefault(x => x.Ma == data.Ma);
                    if (checkMa != null)
                    {
                        msg.SetLoi("Đã tồn tại mã: " + checkMa.Ma);
                        trans.Rollback();
                        return msg;
                    }
                    if (string.IsNullOrEmpty(data.Id))
                    {
                        data.Id = Guid.NewGuid().ToString();
                        _dbContext.Add(data);
                    }
                    else
                        _dbContext.Update(data);
                    _dbContext.SaveChanges();
                    trans.Commit();
                    return msg;
                }
                catch (Exception)
                {
                    msg.SetLoi("Đã có lỗi xảy ra!");
                    trans.Rollback();
                    return msg;
                }
            }
        }
        public ErrorMessage DeleteLoaiDongPhi(string Id)
        {
            ErrorMessage msg = new ErrorMessage(ErrorMessage.eState.ThanhCong);
            var data = _dbContext.LoaiDongPhi.Find(Id);
            if (data != null)
            {
                _dbContext.Remove(data);
                _dbContext.SaveChanges();
            }
            else
            {
                msg.SetLoi("Không tồn tại!");
            }
            return msg;
        }
        #endregion

        #region Căn hộ
        public ErrorMessage GetListCanHo()
        {
            ErrorMessage msg = new ErrorMessage(ErrorMessage.eState.ThanhCong);
            var data = _dbContext.CanHo.ToList();
            msg.Data = data;
            return msg;
        }
        public ErrorMessage GetCanHo(string Id)
        {
            ErrorMessage msg = new ErrorMessage(ErrorMessage.eState.ThanhCong);
            var data = _dbContext.CanHo.Find(Id);
            if (data != null)
            {
                var phuongtiens = _dbContext.PhuongTien.ToList();
                var canho_phuongtiens = _dbContext.CanHo_PhuongTien.Where(x => x.IdCanHo == data.Id).ToList();
                List<Model_PhuongTien> models = new List<Model_PhuongTien>();
                foreach (var item in canho_phuongtiens)
                {
                    Model_PhuongTien model = new Model_PhuongTien();
                    var phuongtien = phuongtiens.Find(x => x.Id == item.IdPhuongTien);
                    if (phuongtien != null)
                    {
                        model.IdPhuongTien = phuongtien.Id;
                        model.MaPhuongTien = phuongtien.Ma ?? "";
                        model.TenPhuongTien = phuongtien.Ten ?? "";
                        model.BienKiemSoat = item.BienKiemSoat ?? "";
                        model.TrangThai = item.TrangThai;
                        models.Add(model);
                    }
                }
                data.PhuongTiens = models;
                msg.Data = data;
            }
            else
                msg.SetLoi("Không tồn tại!");
            return msg;
        }
        public ErrorMessage SetCanHo(CanHo data)
        {
            using (var trans = _dbContext.Database.BeginTransaction())
            {
                ErrorMessage msg = new ErrorMessage(ErrorMessage.eState.ThanhCong);
                try
                {
                    var checkMa = _dbContext.CanHo.AsNoTracking().FirstOrDefault(x => x.Ma == data.Ma);
                    if (checkMa != null)
                    {
                        msg.SetLoi("Đã tồn tại mã: " + checkMa.Ma);
                        trans.Rollback();
                        return msg;
                    }

                    if (string.IsNullOrEmpty(data.Id))
                    {
                        data.Id = Guid.NewGuid().ToString();
                        _dbContext.Add(data);
                        List<CanHo_PhuongTien> News = data.PhuongTiens.Select(x =>
                        new CanHo_PhuongTien
                        {
                            Id = Guid.NewGuid().ToString(),
                            IdCanHo = data.Id,
                            IdPhuongTien = x.IdPhuongTien,
                            BienKiemSoat = x.BienKiemSoat,
                            TrangThai = x.TrangThai
                        }).ToList();
                        _dbContext.AddRange(News);
                    }
                    else
                    {
                        var canho_phuongtien = _dbContext.CanHo_PhuongTien.Where(x => x.IdCanHo == data.Id).ToList();
                        _dbContext.RemoveRange(canho_phuongtien);
                        List<CanHo_PhuongTien> News = data.PhuongTiens.Select(x =>
                        new CanHo_PhuongTien
                        {
                            Id = Guid.NewGuid().ToString(),
                            IdCanHo = data.Id,
                            IdPhuongTien = x.IdPhuongTien,
                            BienKiemSoat = x.BienKiemSoat,
                            TrangThai = x.TrangThai
                        }).ToList();
                        _dbContext.AddRange(News);
                        _dbContext.Update(data);
                    }
                    _dbContext.SaveChanges();
                    trans.Commit();
                    return msg;
                }
                catch (Exception)
                {
                    msg.SetLoi("Đã có lỗi xảy ra!");
                    trans.Rollback();
                    return msg;
                }
            }
        }
        public ErrorMessage DeleteCanHo(string Id)
        {
            ErrorMessage msg = new ErrorMessage(ErrorMessage.eState.ThanhCong);
            var data = _dbContext.CanHo.Find(Id);
            if (data != null)
            {
                var canho_phuongtiens = _dbContext.CanHo_PhuongTien.Where(x => x.IdCanHo == data.Id);
                _dbContext.RemoveRange(canho_phuongtiens);
                _dbContext.Remove(data);
                _dbContext.SaveChanges();
            }
            else
            {
                msg.SetLoi("Không tồn tại!");
            }
            return msg;
        }
        #endregion

        #region Xe ngoài
        public ErrorMessage GetListXeNgoai()
        {
            ErrorMessage msg = new ErrorMessage(ErrorMessage.eState.ThanhCong);
            var data = _dbContext.XeNgoai.ToList();
            var chungcus = _dbContext.ChungCu.ToList();
            var phuongtiens = _dbContext.PhuongTien.ToList();
            var loaixes = _dbContext.LoaiXe.ToList();
            foreach (var item in data)
            {
                var chungcu = chungcus.Find(x => x.Id == item.IdChungCu);
                var phuongtien = phuongtiens.Find(x => x.Id == item.IdPhuongTien);
                var loaixe = loaixes.Find(x => x.Id == item.IdLoaiXe);
                if (chungcu != null)
                {
                    item.TenChungCu = chungcu.Ten;
                }
                if (phuongtien != null)
                {
                    item.TenPhuongTien = phuongtien.Ten;
                }
                if (loaixe != null)
                {
                    item.TenLoaiXe = loaixe.Ten;
                }
            }
            msg.Data = data;
            return msg;
        }
        public ErrorMessage GetXeNgoai(string Id)
        {
            ErrorMessage msg = new ErrorMessage(ErrorMessage.eState.ThanhCong);
            var data = _dbContext.XeNgoai.Find(Id);
            if (data != null)
            {
                msg.Data = data;
            }
            else
                msg.SetLoi("Không tồn tại!");
            return msg;
        }
        public ErrorMessage SetXeNgoai(XeNgoai data)
        {
            using (var trans = _dbContext.Database.BeginTransaction())
            {
                ErrorMessage msg = new ErrorMessage(ErrorMessage.eState.ThanhCong);
                try
                {
                    var checkMa = _dbContext.XeNgoai.AsNoTracking().FirstOrDefault(x => x.Ma == data.Ma);
                    if (checkMa != null)
                    {
                        msg.SetLoi("Đã tồn tại mã: " + checkMa.Ma);
                        trans.Rollback();
                        return msg;
                    }

                    if (string.IsNullOrEmpty(data.Id))
                    {
                        data.Id = Guid.NewGuid().ToString();
                        _dbContext.Add(data);
                    }
                    else
                    {
                        _dbContext.Update(data);
                    }
                    _dbContext.SaveChanges();
                    trans.Commit();
                    return msg;
                }
                catch (Exception)
                {
                    msg.SetLoi("Đã có lỗi xảy ra!");
                    trans.Rollback();
                    return msg;
                }
            }
        }
        public ErrorMessage DeleteXeNgoai(string Id)
        {
            ErrorMessage msg = new ErrorMessage(ErrorMessage.eState.ThanhCong);
            var data = _dbContext.XeNgoai.Find(Id);
            if (data != null)
            {
                _dbContext.Remove(data);
                _dbContext.SaveChanges();
            }
            else
            {
                msg.SetLoi("Không tồn tại!");
            }
            return msg;
        }
        #endregion

        #region Quản lý phí
        public ErrorMessage GetListQuanLyPhi()
        {
            ErrorMessage msg = new ErrorMessage(ErrorMessage.eState.ThanhCong);
            var data = _dbContext.XeNgoai.ToList();
            var chungcus = _dbContext.ChungCu.ToList();
            var phuongtiens = _dbContext.PhuongTien.ToList();
            var loaixes = _dbContext.LoaiXe.ToList();
            foreach (var item in data)
            {
                var chungcu = chungcus.Find(x => x.Id == item.IdChungCu);
                var phuongtien = phuongtiens.Find(x => x.Id == item.IdPhuongTien);
                var loaixe = loaixes.Find(x => x.Id == item.IdLoaiXe);
                if (chungcu != null)
                {
                    item.TenChungCu = chungcu.Ten;
                }
                if (phuongtien != null)
                {
                    item.TenPhuongTien = phuongtien.Ten;
                }
                if (loaixe != null)
                {
                    item.TenLoaiXe = loaixe.Ten;
                }
            }
            msg.Data = data;
            return msg;
        }
        public ErrorMessage GetQuanLyPhi(string Id)
        {
            ErrorMessage msg = new ErrorMessage(ErrorMessage.eState.ThanhCong);
            var data = _dbContext.XeNgoai.Find(Id);
            if (data != null)
            {
                msg.Data = data;
            }
            else
                msg.SetLoi("Không tồn tại!");
            return msg;
        }
        public ErrorMessage SetQuanLyPhi(QuanLyPhi data)
        {
            using (var trans = _dbContext.Database.BeginTransaction())
            {
                ErrorMessage msg = new ErrorMessage(ErrorMessage.eState.ThanhCong);
                try
                {
                    //var checkMa = _dbContext.QuanLyPhi.AsNoTracking().FirstOrDefault(x => x.Ma == data.Ma);
                    //if (checkMa != null)
                    //{
                    //    msg.SetLoi("Đã tồn tại mã: " + checkMa.Ma);
                    //    trans.Rollback();
                    //    return msg;
                    //}

                    if (string.IsNullOrEmpty(data.Id))
                    {
                        data.Id = Guid.NewGuid().ToString();
                        _dbContext.Add(data);
                    }
                    else
                    {
                        _dbContext.Update(data);
                    }
                    _dbContext.SaveChanges();
                    trans.Commit();
                    return msg;
                }
                catch (Exception)
                {
                    msg.SetLoi("Đã có lỗi xảy ra!");
                    trans.Rollback();
                    return msg;
                }
            }
        }
        public ErrorMessage DeleteQuanLyPhi(string Id)
        {
            ErrorMessage msg = new ErrorMessage(ErrorMessage.eState.ThanhCong);
            var data = _dbContext.XeNgoai.Find(Id);
            if (data != null)
            {
                _dbContext.Remove(data);
                _dbContext.SaveChanges();
            }
            else
            {
                msg.SetLoi("Không tồn tại!");
            }
            return msg;
        }
        #endregion
    }
}
