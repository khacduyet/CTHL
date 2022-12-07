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

                    if (string.IsNullOrEmpty(data.Id))
                    {
                        var checkMa = _dbContext.ChungCu.AsNoTracking().FirstOrDefault(x => x.Ma == data.Ma);
                        if (checkMa != null)
                        {
                            msg.SetLoi("Đã tồn tại mã: " + checkMa.Ma);
                            trans.Rollback();
                            return msg;
                        }
                        data.Id = Guid.NewGuid().ToString();
                        _dbContext.Add(data);
                    }
                    else
                    {
                        var checkMa = _dbContext.ChungCu.AsNoTracking().FirstOrDefault(x => x.Ma == data.Ma && x.Id != data.Id);
                        if (checkMa != null)
                        {
                            msg.SetLoi("Đã tồn tại mã: " + checkMa.Ma);
                            trans.Rollback();
                            return msg;
                        }
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
                    if (string.IsNullOrEmpty(data.Id))
                    {
                        var checkMa = _dbContext.LoaiDichVu.AsNoTracking().FirstOrDefault(x => x.Ma == data.Ma);
                        if (checkMa != null)
                        {
                            msg.SetLoi("Đã tồn tại mã: " + checkMa.Ma);
                            trans.Rollback();
                            return msg;
                        }
                        data.Id = Guid.NewGuid().ToString();
                        _dbContext.Add(data);
                    }
                    else
                    {
                        var checkMa = _dbContext.LoaiDichVu.AsNoTracking().FirstOrDefault(x => x.Ma == data.Ma && x.Id != data.Id);
                        if (checkMa != null)
                        {
                            msg.SetLoi("Đã tồn tại mã: " + checkMa.Ma);
                            trans.Rollback();
                            return msg;
                        }
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

                    if (string.IsNullOrEmpty(data.Id))
                    {
                        var checkMa = _dbContext.LoaiXe.AsNoTracking().FirstOrDefault(x => x.Ma == data.Ma);
                        if (checkMa != null)
                        {
                            msg.SetLoi("Đã tồn tại mã: " + checkMa.Ma);
                            trans.Rollback();
                            return msg;
                        }
                        data.Id = Guid.NewGuid().ToString();
                        _dbContext.Add(data);
                    }
                    else
                    {
                        var checkMa = _dbContext.LoaiXe.AsNoTracking().FirstOrDefault(x => x.Ma == data.Ma && x.Id != data.Id);
                        if (checkMa != null)
                        {
                            msg.SetLoi("Đã tồn tại mã: " + checkMa.Ma);
                            trans.Rollback();
                            return msg;
                        }
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

                    if (string.IsNullOrEmpty(data.Id))
                    {
                        var checkMa = _dbContext.PhuongTien.AsNoTracking().FirstOrDefault(x => x.Ma == data.Ma);
                        if (checkMa != null)
                        {
                            msg.SetLoi("Đã tồn tại mã: " + checkMa.Ma);
                            trans.Rollback();
                            return msg;
                        }
                        data.Id = Guid.NewGuid().ToString();
                        _dbContext.Add(data);
                    }
                    else
                    {
                        var checkMa = _dbContext.PhuongTien.AsNoTracking().FirstOrDefault(x => x.Ma == data.Ma && x.Id != data.Id);
                        if (checkMa != null)
                        {
                            msg.SetLoi("Đã tồn tại mã: " + checkMa.Ma);
                            trans.Rollback();
                            return msg;
                        }
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
                    if (string.IsNullOrEmpty(data.Id))
                    {
                        var checkMa = _dbContext.LoaiDongPhi.AsNoTracking().FirstOrDefault(x => x.Ma == data.Ma);
                        if (checkMa != null)
                        {
                            msg.SetLoi("Đã tồn tại mã: " + checkMa.Ma);
                            trans.Rollback();
                            return msg;
                        }
                        data.Id = Guid.NewGuid().ToString();
                        _dbContext.Add(data);
                    }
                    else
                    {
                        var checkMa = _dbContext.LoaiDongPhi.AsNoTracking().FirstOrDefault(x => x.Ma == data.Ma && x.Id != data.Id);
                        if (checkMa != null)
                        {
                            msg.SetLoi("Đã tồn tại mã: " + checkMa.Ma);
                            trans.Rollback();
                            return msg;
                        }
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
        public ErrorMessage GetListCanHo(TimKiem timKiem)
        {
            ErrorMessage msg = new ErrorMessage(ErrorMessage.eState.ThanhCong);
            var data = _dbContext.CanHo.ToList();
            if (!String.IsNullOrEmpty(timKiem.IdChungCu))
            {
                data = data.FindAll(x => timKiem.IdChungCu == x.IdChungCu);
            }
            if (!String.IsNullOrEmpty(timKiem.Keyword))
            {
                data = data.FindAll(x =>
                (x.Ma.ToLower().Trim().Contains(timKiem.Keyword.ToLower().Trim()) ||
                 x.Ten.ToLower().Trim().Contains(timKiem.Keyword.ToLower().Trim()) ||
                (!String.IsNullOrEmpty(x.ChuSoHuu) && x.ChuSoHuu.ToLower().Trim().Contains(timKiem.Keyword.ToLower().Trim())) ||
                 x.SoDienThoai.ToLower().Trim().Contains(timKiem.Keyword.ToLower().Trim())));
            }
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
                var loaixes = _dbContext.LoaiXe.ToList();
                var canho_phuongtiens = _dbContext.CanHo_PhuongTien.Where(x => x.IdCanHo == data.Id).ToList();
                List<Model_PhuongTien> models = new List<Model_PhuongTien>();
                foreach (var item in canho_phuongtiens)
                {
                    Model_PhuongTien model = new Model_PhuongTien();
                    var phuongtien = phuongtiens.Find(x => x.Id == item.IdPhuongTien);
                    var loaixe = loaixes.Find(x => x.Id == item.IdLoaiXe);
                    if (phuongtien != null)
                    {
                        model.IdPhuongTien = phuongtien.Id;
                        model.MaPhuongTien = phuongtien.Ma ?? "";
                        model.TenPhuongTien = phuongtien.Ten ?? "";
                        model.BienKiemSoat = item.BienKiemSoat ?? "";
                        model.IdLoaiXe = item.IdLoaiXe;
                        model.TrangThai = item.TrangThai;
                    }
                    if (loaixe != null)
                    {
                        model.TenLoaiXe = loaixe.Ten;
                    }
                    models.Add(model);
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
                    if (string.IsNullOrEmpty(data.Id))
                    {
                        var checkMa = _dbContext.CanHo.AsNoTracking().FirstOrDefault(x => x.Ma == data.Ma);
                        if (checkMa != null)
                        {
                            msg.SetLoi("Đã tồn tại mã: " + checkMa.Ma);
                            trans.Rollback();
                            return msg;
                        }
                        data.Id = Guid.NewGuid().ToString();
                        _dbContext.Add(data);
                        List<CanHo_PhuongTien> News = data.PhuongTiens.Select(x =>
                        new CanHo_PhuongTien
                        {
                            Id = Guid.NewGuid().ToString(),
                            IdCanHo = data.Id,
                            IdLoaiXe = x.IdLoaiXe,
                            IdPhuongTien = x.IdPhuongTien,
                            BienKiemSoat = x.BienKiemSoat,
                            TrangThai = x.TrangThai,
                            IdChungCu = data.IdChungCu
                        }).ToList();
                        _dbContext.AddRange(News);
                    }
                    else
                    {
                        var checkMa = _dbContext.CanHo.AsNoTracking().FirstOrDefault(x => x.Ma == data.Ma && x.Id != data.Id);
                        if (checkMa != null)
                        {
                            msg.SetLoi("Đã tồn tại mã: " + checkMa.Ma);
                            trans.Rollback();
                            return msg;
                        }

                        var canho_phuongtien = _dbContext.CanHo_PhuongTien.Where(x => x.IdCanHo == data.Id).ToList();
                        _dbContext.RemoveRange(canho_phuongtien);
                        List<CanHo_PhuongTien> News = data.PhuongTiens.Select(x =>
                        new CanHo_PhuongTien
                        {
                            Id = Guid.NewGuid().ToString(),
                            IdCanHo = data.Id,
                            IdLoaiXe = x.IdLoaiXe,
                            IdPhuongTien = x.IdPhuongTien,
                            BienKiemSoat = x.BienKiemSoat,
                            TrangThai = x.TrangThai,
                            IdChungCu = data.IdChungCu
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

        public int getRowMerge(ExcelWorksheet sheet, int row, int rs)
        {
            string Ma = Dungchung.GetCell(sheet, row, 2);
            string MaPT = Dungchung.GetCell(sheet, row, 7);
            string MaLX = Dungchung.GetCell(sheet, row, 8);
            if (Ma == "" && MaPT == "" && MaLX == "")
            {
                return rs;
            }
            if (Ma == "" && MaPT != "" && MaLX != "")
            {
                rs++;
                int _row = row + 1;
                rs = getRowMerge(sheet, _row, rs);
            }
            return rs;
        }

        public ErrorMessage ImportCanHo(string FileName, string IdChungCu)
        {
            ErrorMessage err = new ErrorMessage(ErrorMessage.eState.ThanhCong);
            try
            {
                string sFileName = _appSettings.DuongDanUpload + FileName;
                Stream s = File.OpenRead(sFileName);
                ExcelPackage package = new ExcelPackage(s);
                ExcelWorksheet sheet1 = package.Workbook.Worksheets.First();
                List<string> Mas = _dbContext.CanHo.Select(x => x.Ma).ToList();
                var listDanhMuc = new List<CanHo>();
                if (!Dungchung.KiemTraMaTrungExcel(sheet1, err))
                {
                    err.Data = listDanhMuc;
                    return err;
                }

                var listColumnName = new List<string>();
                String[] ColumnNames = new String[] { "STT", "Mã", "Tên", "Chủ sở hữu", "Số điện thoại", "Diện tích", "Mã phương tiện", "Mã loại xe", "Biển kiểm soát", "Ghi Chú" };
                listColumnName.AddRange(ColumnNames);
                if (!Dungchung.KiemTraTempExcel(sheet1, err, listColumnName, "DANH SÁCH CƯ DÂN", 10))
                    return err;

                if (!Dungchung.KiemTraMaTrungDb(sheet1, err, Mas))
                {
                    err.Data = listDanhMuc;
                    return err;
                }

                var phuongtiens = _dbContext.PhuongTien.ToList();
                var loaixes = _dbContext.LoaiXe.ToList();

                List<CanHo_PhuongTien> canho_pts = new List<CanHo_PhuongTien>();
                bool checkMaExist = false;

                for (int row = 3; row <= sheet1.Cells.End.Row; row++)
                {
                    CanHo dm = new CanHo();
                    dm.Ma = Dungchung.GetCell(sheet1, row, 2);
                    string MaPT = Dungchung.GetCell(sheet1, row, 7);
                    string MaLX = Dungchung.GetCell(sheet1, row, 8);
                    string BKS = Dungchung.GetCell(sheet1, row, 9);
                    if (dm.Ma == "" && MaPT == "" && MaLX == "")
                        break;
                    int _row = row + 1;
                    int rowMerge = getRowMerge(sheet1, _row, 1);

                    dm.Id = Guid.NewGuid().ToString();
                    dm.Ten = Dungchung.GetCell(sheet1, row, 3);
                    dm.ChuSoHuu = Dungchung.GetCell(sheet1, row, 4);
                    dm.SoDienThoai = Dungchung.GetCell(sheet1, row, 5);
                    if (Dungchung.IsValidDecimalNumber(Dungchung.GetCell(sheet1, row, 6)))
                    {
                        dm.DienTich = Double.Parse(Dungchung.GetCell(sheet1, row, 6));
                    }
                    dm.GhiChu = Dungchung.GetCell(sheet1, row, 10);
                    dm.IdChungCu = IdChungCu;
                    dm.TrangThai = true;
                    listDanhMuc.Add(dm);
                    if (rowMerge > 1)
                    {
                        for (int i = 0; i < rowMerge; i++)
                        {
                            string MaPT_merge = Dungchung.GetCell(sheet1, row + i, 7);
                            string MaLX_merge = Dungchung.GetCell(sheet1, row + i, 8);
                            string BKS_merge = Dungchung.GetCell(sheet1, row + i, 9);
                            var phuongtien = phuongtiens.Find(x => x.Ma == MaPT_merge);
                            var loaixe = loaixes.Find(x => x.Ma == MaLX_merge);
                            if (phuongtien != null && loaixe != null)
                            {
                                canho_pts.Add(new CanHo_PhuongTien()
                                {
                                    Id = Guid.NewGuid().ToString(),
                                    IdPhuongTien = phuongtien.Id,
                                    IdLoaiXe = loaixe.Id,
                                    BienKiemSoat = BKS_merge,
                                    TrangThai = true,
                                    IdCanHo = dm.Id,
                                    IdChungCu = IdChungCu
                                });
                            }
                            else
                            {
                                checkMaExist = true;
                            }
                        }
                        row += rowMerge - 1;
                    }
                    else
                    {
                        var phuongtien = phuongtiens.Find(x => x.Ma == MaPT);
                        var loaixe = loaixes.Find(x => x.Ma == MaLX);
                        if (phuongtien != null && loaixe != null)
                        {
                            canho_pts.Add(new CanHo_PhuongTien()
                            {
                                Id = Guid.NewGuid().ToString(),
                                IdPhuongTien = phuongtien.Id,
                                IdLoaiXe = loaixe.Id,
                                BienKiemSoat = BKS,
                                TrangThai = true,
                                IdCanHo = dm.Id,
                                IdChungCu = IdChungCu
                            });
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(MaPT) && !string.IsNullOrEmpty(MaLX))
                            {
                                checkMaExist = true;
                            }
                        }
                    }
                }

                if (checkMaExist)
                {
                    err.SetLoi("Mã phương tiện hoặc mã loại xe không tồn tại, vui lòng kiểm tra lại!");
                    return err;
                }

                var danhMucs = _dbContext.CanHo.ToList();
                foreach (var item in listDanhMuc)
                {
                    CanHo dm = danhMucs.FirstOrDefault(x => x.Ma == item.Ma);
                    if (dm == null)
                        _dbContext.CanHo.Add(item);
                    else
                    {
                        dm.Ten = item.Ten;
                        dm.GhiChu = item.GhiChu;
                        _dbContext.CanHo.Update(dm);
                    }
                }
                _dbContext.AddRange(canho_pts);
                _dbContext.SaveChanges();
                s.Close();
                err.Data = _dbContext.CanHo.OrderByDescending(x => x.Created).ToList();
                return err;
            }
            catch (Exception e)
            {
                err.SetLoi("Importdm " + e.ToString());
                return err;
            }
        }
        public ErrorMessage ExportCanHo(TimKiem itemTimKiem)
        {
            ErrorMessage err = new ErrorMessage(ErrorMessage.eState.ImportDuLieuThanhCong);
            try
            {
                string sFileName = Path.Combine(Directory.GetCurrentDirectory(), "MauBaoCao/" + "CuDan.xlsx");
                DateTime dt = DateTime.Now;
                string sFileNameCopy = _appSettings.DuongDanUpload + "CuDanDownload_" + dt.ToOADate() + ".xlsx";
                File.Copy(sFileName, sFileNameCopy, true);
                Stream s = File.OpenRead(sFileNameCopy);
                ExcelPackage package = new ExcelPackage(s);
                ExcelWorksheet sheet1 = package.Workbook.Worksheets.First();

                var danhmucs = _dbContext.CanHo.Where(x => x.IdChungCu == itemTimKiem.IdChungCu).OrderBy(x => x.Ma).ToList();
                var ch_pts = _dbContext.CanHo_PhuongTien.Where(x => x.IdChungCu == itemTimKiem.IdChungCu).ToList();
                var phuongtiens = _dbContext.PhuongTien.ToList();
                var loaixes = _dbContext.LoaiXe.ToList();

                int nRow = 3;
                int i = 1;
                foreach (var danhmuc in danhmucs)
                {
                    var _ch_pts = ch_pts.FindAll(x => x.IdCanHo == danhmuc.Id);
                    if (_ch_pts.Count > 1)
                    {
                        int rowMerge = _ch_pts.Count;
                        sheet1.Cells[nRow, 1].Value = i;
                        sheet1.Cells[nRow, 2].Value = danhmuc.Ma;
                        sheet1.Cells[nRow, 3].Value = danhmuc.Ten;
                        sheet1.Cells[nRow, 4].Value = danhmuc.ChuSoHuu;
                        sheet1.Cells[nRow, 5].Value = danhmuc.SoDienThoai;
                        sheet1.Cells[nRow, 6].Value = danhmuc.DienTich;
                        sheet1.Cells[nRow, 10].Value = danhmuc.GhiChu;

                        for (int j = 0; j < rowMerge; j++)
                        {
                            var phuongtien = phuongtiens.Find(x => x.Id == _ch_pts[j].IdPhuongTien);
                            var loaixe = loaixes.Find(x => x.Id == _ch_pts[j].IdLoaiXe);
                            if (phuongtien != null)
                            {
                                sheet1.Cells[nRow + j, 7].Value = phuongtien.Ma;
                            }
                            if (loaixe != null)
                            {
                                sheet1.Cells[nRow + j, 8].Value = loaixe.Ma;
                            }
                            sheet1.Cells[nRow + j, 9].Value = _ch_pts[j].BienKiemSoat;
                        }

                        sheet1.Cells[nRow, 1, nRow + rowMerge - 1, 1].Merge = true;
                        sheet1.Cells[nRow, 2, nRow + rowMerge - 1, 2].Merge = true;
                        sheet1.Cells[nRow, 3, nRow + rowMerge - 1, 3].Merge = true;
                        sheet1.Cells[nRow, 4, nRow + rowMerge - 1, 4].Merge = true;
                        sheet1.Cells[nRow, 5, nRow + rowMerge - 1, 5].Merge = true;
                        sheet1.Cells[nRow, 6, nRow + rowMerge - 1, 6].Merge = true;
                        sheet1.Cells[nRow, 10, nRow + rowMerge - 1, 10].Merge = true;
                        if (_ch_pts.Count == 0)
                        {
                            nRow++;
                        }
                        else
                        {
                            nRow += _ch_pts.Count;
                        }
                        i++;
                    }
                    else
                    {
                        sheet1.Cells[nRow, 1].Value = i;
                        sheet1.Cells[nRow, 2].Value = danhmuc.Ma;
                        sheet1.Cells[nRow, 3].Value = danhmuc.Ten;
                        sheet1.Cells[nRow, 4].Value = danhmuc.ChuSoHuu;
                        sheet1.Cells[nRow, 5].Value = danhmuc.SoDienThoai;
                        sheet1.Cells[nRow, 6].Value = danhmuc.DienTich;
                        if (_ch_pts.Count > 0)
                        {
                            var phuongtien = phuongtiens.Find(x => x.Id == _ch_pts[0].IdPhuongTien);
                            var loaixe = loaixes.Find(x => x.Id == _ch_pts[0].IdLoaiXe);
                            if (phuongtien != null)
                            {
                                sheet1.Cells[nRow, 7].Value = phuongtien.Ma;
                            }
                            if (loaixe != null)
                            {
                                sheet1.Cells[nRow, 8].Value = loaixe.Ma;
                            }
                            sheet1.Cells[nRow, 9].Value = _ch_pts[0].BienKiemSoat;
                        }
                        sheet1.Cells[nRow, 10].Value = danhmuc.GhiChu;
                        nRow++;
                        i++;
                    }

                }
                if (nRow > 3)
                {
                    nRow--;
                    //sheet1.Cells[2, 3, nRow, 3].Style.WrapText = true;
                    //sheet1.Cells[2, 4, nRow, 4].Style.WrapText = true;
                    //sheet1.Cells[2, 5, nRow, 5].Style.WrapText = true;
                    Dungchung.DrawTableExcel(sheet1, 3, nRow, 1, 10);
                }
                s.Close();

                byte[] bytee = package.GetAsByteArray();
                File.WriteAllBytes(sFileNameCopy, bytee);
                err.Data = "/uploader/DownloadFile?filename=" + Dungchung.Base64Encode("CuDan.xlsx")
                                + "&path=" + Dungchung.Base64Encode(sFileNameCopy);
                return err;
            }
            catch (Exception e)
            {
                err.SetLoi("ExportDanhMuc " + e.ToString());
                return err;
            }
        }
        #endregion

        #region Xe ngoài
        public ErrorMessage GetListXeNgoai(TimKiem timKiem)
        {
            ErrorMessage msg = new ErrorMessage(ErrorMessage.eState.ThanhCong);
            var data = _dbContext.XeNgoai.ToList();
            if (!String.IsNullOrEmpty(timKiem.IdChungCu))
            {
                data = data.FindAll(x => timKiem.IdChungCu == x.IdChungCu);
            }
            if (!String.IsNullOrEmpty(timKiem.Keyword))
            {
                data = data.FindAll(x =>
                ((!String.IsNullOrEmpty(timKiem.Keyword) && (x.Ma.ToLower().Trim().Contains(timKiem.Keyword.ToLower().Trim()) ||
                 x.Ten.ToLower().Trim().Contains(timKiem.Keyword.ToLower().Trim()) ||
                x.BienKiemSoat.ToLower().Trim().Contains(timKiem.Keyword.ToLower().Trim()) ||
                 x.SoDienThoai.ToLower().Trim().Contains(timKiem.Keyword.ToLower().Trim())))));
            }
            if (!String.IsNullOrEmpty(timKiem.IdLoaiXe))
            {
                data = data.FindAll(x => x.IdLoaiXe == timKiem.IdLoaiXe);
            }
            if (!String.IsNullOrEmpty(timKiem.IdPhuongTien))
            {
                data = data.FindAll(x => x.IdPhuongTien == timKiem.IdPhuongTien);
            }
            //var chungcus = _dbContext.ChungCu.ToList();
            var phuongtiens = _dbContext.PhuongTien.ToList();
            var loaixes = _dbContext.LoaiXe.ToList();
            foreach (var item in data)
            {
                //var chungcu = chungcus.Find(x => x.Id == item.IdChungCu);
                var phuongtien = phuongtiens.Find(x => x.Id == item.IdPhuongTien);
                var loaixe = loaixes.Find(x => x.Id == item.IdLoaiXe);
                //if (chungcu != null)
                //{
                //    item.TenChungCu = chungcu.Ten;
                //}
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
                var LoaiXe = _dbContext.LoaiXe.Find(data.IdLoaiXe);
                if (LoaiXe != null)
                {
                    data.TenLoaiXe = LoaiXe.Ten;
                }
                var PhuongTien = _dbContext.PhuongTien.Find(data.IdPhuongTien);
                if (PhuongTien != null)
                {
                    data.TenPhuongTien = PhuongTien.Ten;
                }
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
                    if (string.IsNullOrEmpty(data.Id))
                    {
                        var checkMa = _dbContext.XeNgoai.AsNoTracking().FirstOrDefault(x => x.Ma == data.Ma);
                        if (checkMa != null)
                        {
                            msg.SetLoi("Đã tồn tại mã: " + checkMa.Ma);
                            trans.Rollback();
                            return msg;
                        }
                        data.Id = Guid.NewGuid().ToString();
                        _dbContext.Add(data);
                    }
                    else
                    {
                        var checkMa = _dbContext.XeNgoai.AsNoTracking().FirstOrDefault(x => x.Ma == data.Ma && x.Id != data.Id);
                        if (checkMa != null)
                        {
                            msg.SetLoi("Đã tồn tại mã: " + checkMa.Ma);
                            trans.Rollback();
                            return msg;
                        }
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

        public ErrorMessage ImportXeNgoai(string FileName, string IdChungCu)
        {
            ErrorMessage err = new ErrorMessage(ErrorMessage.eState.ThanhCong);
            try
            {
                string sFileName = _appSettings.DuongDanUpload + FileName;
                Stream s = File.OpenRead(sFileName);
                ExcelPackage package = new ExcelPackage(s);
                ExcelWorksheet sheet1 = package.Workbook.Worksheets.First();
                List<string> Mas = _dbContext.XeNgoai.Select(x => x.Ma).ToList();
                var listDanhMuc = new List<XeNgoai>();
                if (!Dungchung.KiemTraMaTrungExcel(sheet1, err))
                {
                    err.Data = listDanhMuc;
                    return err;
                }

                var listColumnName = new List<string>();
                String[] ColumnNames = new String[] { "STT", "Mã", "Tên", "Số điện thoại", "Mã phương tiện", "Mã loại xe", "Biển kiểm soát", "Ghi Chú" };
                listColumnName.AddRange(ColumnNames);
                if (!Dungchung.KiemTraTempExcel(sheet1, err, listColumnName, "DANH SÁCH XE NGOÀI", 10))
                    return err;

                if (!Dungchung.KiemTraMaTrungDb(sheet1, err, Mas))
                {
                    err.Data = listDanhMuc;
                    return err;
                }

                var phuongtiens = _dbContext.PhuongTien.ToList();
                var loaixes = _dbContext.LoaiXe.ToList();

                bool checkMaExist = false;

                for (int row = 3; row <= sheet1.Cells.End.Row; row++)
                {
                    XeNgoai dm = new XeNgoai();
                    dm.Ma = Dungchung.GetCell(sheet1, row, 2);

                    if (dm.Ma == "")
                        break;

                    dm.Id = Guid.NewGuid().ToString();
                    dm.Ten = Dungchung.GetCell(sheet1, row, 3);
                    dm.SoDienThoai = Dungchung.GetCell(sheet1, row, 4);
                    string MaPT = Dungchung.GetCell(sheet1, row, 5);
                    string MaLX = Dungchung.GetCell(sheet1, row, 6);
                    string BKS = Dungchung.GetCell(sheet1, row, 7);
                    dm.BienKiemSoat = BKS;
                    var phuongtien = phuongtiens.Find(x => x.Ma == MaPT);
                    var loaixe = loaixes.Find(x => x.Ma == MaLX);
                    if (phuongtien != null && loaixe != null)
                    {
                        dm.IdPhuongTien = phuongtien.Id;
                        dm.IdLoaiXe = loaixe.Id;
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(MaPT) && !string.IsNullOrEmpty(MaLX))
                        {
                            checkMaExist = true;
                        }
                    }
                    dm.GhiChu = Dungchung.GetCell(sheet1, row, 8);
                    dm.IdChungCu = IdChungCu;
                    dm.TrangThai = true;
                    listDanhMuc.Add(dm);
                }

                if (checkMaExist)
                {
                    err.SetLoi("Mã phương tiện hoặc mã loại xe không tồn tại, vui lòng kiểm tra lại!");
                    return err;
                }

                var danhMucs = _dbContext.XeNgoai.ToList();
                foreach (var item in listDanhMuc)
                {
                    XeNgoai dm = danhMucs.FirstOrDefault(x => x.Ma == item.Ma);
                    if (dm == null)
                        _dbContext.Add(item);
                    else
                    {
                        dm.Ten = item.Ten;
                        dm.GhiChu = item.GhiChu;
                        _dbContext.Update(dm);
                    }
                }
                _dbContext.SaveChanges();
                s.Close();
                err.Data = _dbContext.XeNgoai.OrderByDescending(x => x.Created).ToList();
                return err;
            }
            catch (Exception e)
            {
                err.SetLoi("Importdm " + e.ToString());
                return err;
            }
        }
        public ErrorMessage ExportXeNgoai(TimKiem itemTimKiem)
        {
            ErrorMessage err = new ErrorMessage(ErrorMessage.eState.ImportDuLieuThanhCong);
            try
            {
                string sFileName = Path.Combine(Directory.GetCurrentDirectory(), "MauBaoCao/" + "XeNgoai.xlsx");
                DateTime dt = DateTime.Now;
                string sFileNameCopy = _appSettings.DuongDanUpload + "XeNgoaiDownload_" + dt.ToOADate() + ".xlsx";
                File.Copy(sFileName, sFileNameCopy, true);
                Stream s = File.OpenRead(sFileNameCopy);
                ExcelPackage package = new ExcelPackage(s);
                ExcelWorksheet sheet1 = package.Workbook.Worksheets.First();

                var danhmucs = _dbContext.XeNgoai.Where(x => x.IdChungCu == itemTimKiem.IdChungCu).OrderBy(x => x.Ma).ToList();
                if (!String.IsNullOrEmpty(itemTimKiem.IdPhuongTien))
                {
                    danhmucs = danhmucs.FindAll(x => x.IdPhuongTien == itemTimKiem.IdPhuongTien);
                }
                if (!String.IsNullOrEmpty(itemTimKiem.IdLoaiXe))
                {
                    danhmucs = danhmucs.FindAll(x => x.IdLoaiXe == itemTimKiem.IdLoaiXe);
                }
                var ch_pts = _dbContext.CanHo_PhuongTien.Where(x => x.IdChungCu == itemTimKiem.IdChungCu).ToList();
                var phuongtiens = _dbContext.PhuongTien.ToList();
                var loaixes = _dbContext.LoaiXe.ToList();

                int nRow = 3;
                int i = 1;
                foreach (var danhmuc in danhmucs)
                {
                    sheet1.Cells[nRow, 1].Value = i;
                    sheet1.Cells[nRow, 2].Value = danhmuc.Ma;
                    sheet1.Cells[nRow, 3].Value = danhmuc.Ten;
                    sheet1.Cells[nRow, 4].Value = danhmuc.SoDienThoai;
                    var phuongtien = phuongtiens.Find(x => x.Id == danhmuc.IdPhuongTien);
                    var loaixe = loaixes.Find(x => x.Id == danhmuc.IdLoaiXe);
                    if (phuongtien != null)
                    {
                        sheet1.Cells[nRow, 5].Value = phuongtien.Ma;
                    }
                    if (loaixe != null)
                    {
                        sheet1.Cells[nRow, 6].Value = loaixe.Ma;
                    }
                    sheet1.Cells[nRow, 7].Value = danhmuc.BienKiemSoat;
                    sheet1.Cells[nRow, 8].Value = danhmuc.GhiChu;
                    nRow++;
                    i++;
                }
                if (nRow > 3)
                {
                    nRow--;
                    //sheet1.Cells[2, 3, nRow, 3].Style.WrapText = true;
                    //sheet1.Cells[2, 4, nRow, 4].Style.WrapText = true;
                    //sheet1.Cells[2, 5, nRow, 5].Style.WrapText = true;
                    Dungchung.DrawTableExcel(sheet1, 3, nRow, 1, 8);
                }
                s.Close();

                byte[] bytee = package.GetAsByteArray();
                File.WriteAllBytes(sFileNameCopy, bytee);
                err.Data = "/uploader/DownloadFile?filename=" + Dungchung.Base64Encode("XeNgoai.xlsx")
                                + "&path=" + Dungchung.Base64Encode(sFileNameCopy);
                return err;
            }
            catch (Exception e)
            {
                err.SetLoi("ExportDanhMuc " + e.ToString());
                return err;
            }
        }
        #endregion

        #region Quản lý phí
        public ErrorMessage GetNextSoPhieu()
        {
            ErrorMessage msg = new ErrorMessage(ErrorMessage.eState.CapNhatThanhCong);
            string sTT = Dungchung.GetNextSoQuyTrinhChungBanDau(DefineData.eTable.QUANLYDONGPHI);
            string SoPhieu = _dbContext.QuanLyPhi.Where(d => d.SoPhieu.Contains(sTT)).OrderByDescending(x => x.Created).Select(x => x.SoPhieu).FirstOrDefault();
            msg.Data = Dungchung.GetNextSoQuyTrinhChungKetThuc(sTT, SoPhieu);
            return msg;
        }
        public ErrorMessage GetListQuanLyPhi(TimKiemPhieu timKiem)
        {
            ErrorMessage msg = new ErrorMessage(ErrorMessage.eState.ThanhCong);
            List<QuanLyPhi> data = new List<QuanLyPhi>();
            switch (timKiem.DaDongPhi)
            {
                case 0:
                    data.AddRange(_dbContext.QuanLyPhi.Where(x => x.IdChungCu == timKiem.IdChungCu && !x.TrangThai).OrderByDescending(x => x.SoPhieu).ToList());
                    break;
                case 1:
                    data.AddRange(_dbContext.QuanLyPhi.Where(x => x.IdChungCu == timKiem.IdChungCu && x.TrangThai).OrderByDescending(x => x.SoPhieu).ToList());
                    break;
                default:
                    data.AddRange(_dbContext.QuanLyPhi.Where(x => x.IdChungCu == timKiem.IdChungCu).OrderByDescending(x => x.SoPhieu).ToList());
                    break;
            }
            switch (timKiem.LoaiNguoiDung)
            {
                case 1:
                    data = data.FindAll(x => !x.isXeNgoai);
                    break;

                case 2:
                    data = data.FindAll(x => x.isXeNgoai);
                    break;
            }
            var chungcus = _dbContext.ChungCu.ToList();
            var phuongtiens = _dbContext.PhuongTien.ToList();
            var loaixes = _dbContext.LoaiXe.ToList();

            if (!String.IsNullOrEmpty(timKiem.Keyword))
            {
                data = data.FindAll(x =>
                    x.SoPhieu.ToLower().Trim().Contains(timKiem.Keyword.ToLower().Trim()) ||
                    x.NguoiDongPhi.ToLower().Trim().Contains(timKiem.Keyword.ToLower().Trim())
                );
            }
            if (!String.IsNullOrEmpty(timKiem.IdLoaiXe))
            {
                if (timKiem.LoaiNguoiDung != 1)
                    data = data.FindAll(x => x.IdLoaiXe == timKiem.IdLoaiXe);
            }
            if (timKiem.Thang != null && timKiem.Thang != 0)
            {
                data = data.FindAll(x => x.Created.Month == timKiem.Thang);
            }

            foreach (var item in data)
            {
                var chungcu = chungcus.Find(x => x.Id == item.IdChungCu);
                var loaixe = loaixes.Find(x => x.Id == item.IdLoaiXe);
                if (chungcu != null)
                {
                    item.TenChungCu = chungcu.Ten;
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
            var data = _dbContext.QuanLyPhi.Find(Id);
            if (data != null)
            {
                data.ListPhi = GetThongTinPhieuThu(data.isXeNgoai ? data.IdXeNgoai : data.IdCanHo, data.isXeNgoai).Data;
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
                    msg.Data = data.Id;
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
            var data = _dbContext.QuanLyPhi.Find(Id);
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
        // Lọc dữ liệu căn hộ và xe ngoài để tạo phiếu
        public ErrorMessage GetListFilterCreated(TaoNhanhPhieu taoNhanh)
        {
            ErrorMessage msg = new ErrorMessage(ErrorMessage.eState.ThanhCong);
            if (taoNhanh.isXeNgoai)
            {
                var data = _dbContext.XeNgoai.ToList();
                if (!String.IsNullOrEmpty(taoNhanh.IdChungCu))
                {
                    data = data.FindAll(x => taoNhanh.IdChungCu == x.IdChungCu);
                }
                var current_time = DateTime.Now;
                var current_month = current_time.Month;
                var current_year = current_time.Year;

                List<XeNgoai> DaCoPhieus = new List<XeNgoai>();
                // Phiếu xe ngoài
                var phieus = _dbContext.QuanLyPhi.Where(x => x.isGanNhat && x.IdChungCu == taoNhanh.IdChungCu && !x.isXeNgoai).ToList();
                foreach (var item in data)
                {
                    var phieu = phieus.Find(x => x.IdCanHo == item.Id);
                    if (phieu != null)
                    {
                        if (phieu.Created.Month == current_month && phieu.Created.Year == current_year)
                        {
                            DaCoPhieus.Add(item);
                        }
                    }
                }
                foreach (var item in DaCoPhieus)
                {
                    data.Remove(item);
                }
                msg.Data = data;
            }
            else
            {
                var data = _dbContext.CanHo.ToList();
                if (!String.IsNullOrEmpty(taoNhanh.IdChungCu))
                {
                    data = data.FindAll(x => taoNhanh.IdChungCu == x.IdChungCu);
                }
                var current_time = DateTime.Now;
                var current_month = current_time.Month;
                var current_year = current_time.Year;

                List<CanHo> DaCoPhieus = new List<CanHo>();
                // Phiếu căn hộ
                var phieus = _dbContext.QuanLyPhi.Where(x => x.isGanNhat && x.IdChungCu == taoNhanh.IdChungCu && !x.isXeNgoai).ToList();
                foreach (var item in data)
                {
                    var phieu = phieus.Find(x => x.IdCanHo == item.Id);
                    if (phieu != null)
                    {
                        if (phieu.Created.Month == current_month && phieu.Created.Year == current_year)
                        {
                            DaCoPhieus.Add(item);
                        }
                    }
                }
                foreach (var item in DaCoPhieus)
                {
                    data.Remove(item);
                }
                msg.Data = data;
            }
            return msg;
        }

        // Tạo nhanh phiếu thu
        public string GetNextSoPhieuInList(List<QuanLyPhi> QuanLyPhi)
        {
            string sTT = Dungchung.GetNextSoQuyTrinhChungBanDau(DefineData.eTable.QUANLYDONGPHI);
            string SoPhieu = QuanLyPhi.Where(d => d.SoPhieu.Contains(sTT)).OrderByDescending(x => x.Created).Select(x => x.SoPhieu).FirstOrDefault();
            return Dungchung.GetNextSoQuyTrinhChungKetThuc(sTT, SoPhieu);
        }
        public ErrorMessage CreatePhieu(TaoNhanhPhieu taoNhanh)
        {
            using (var trans = _dbContext.Database.BeginTransaction())
            {
                ErrorMessage msg = new ErrorMessage(ErrorMessage.eState.ThanhCong);
                try
                {
                    var canhos = _dbContext.CanHo.Where(x => x.IdChungCu == taoNhanh.IdChungCu).ToList();
                    var canho_phuongtiens = _dbContext.CanHo_PhuongTien.Where(x => x.IdChungCu == taoNhanh.IdChungCu).ToList();
                    var xengoais = _dbContext.XeNgoai.Where(x => x.IdChungCu == taoNhanh.IdChungCu).ToList();

                    string soPhieu = GetNextSoPhieu().Data;

                    var loaixes = _dbContext.LoaiXe.ToList();
                    var phuongtiens = _dbContext.PhuongTien.ToList();
                    var loaidichvus = _dbContext.LoaiDichVu.ToList();

                    var phieus = _dbContext.QuanLyPhi.Where(x => x.isGanNhat && x.IdChungCu == taoNhanh.IdChungCu).ToList();
                    var current_time = DateTime.Now;
                    var current_month = current_time.Month;
                    var current_year = current_time.Year;

                    var phieucanhos = phieus.FindAll(x => !x.isXeNgoai);
                    var phieuxengoais = phieus.FindAll(x => x.isXeNgoai);
                    List<QuanLyPhi> phieuNew = new List<QuanLyPhi>();
                    List<QuanLyPhi> phieuUpdate = new List<QuanLyPhi>();
                    foreach (var item in canhos)
                    {
                        var phieu = phieucanhos.Find(x => x.IdCanHo == item.Id);
                        string SP = "";
                        if (phieuNew.Count() > 0)
                        {
                            SP = GetNextSoPhieuInList(phieuNew);
                        }
                        else
                        {
                            SP = soPhieu;
                        }
                        if (phieu != null)
                        {
                            if (phieu.Created.Month < current_month && phieu.Created.Year == current_year)
                            {
                                var ch_pts = canho_phuongtiens.FindAll(x => x.IdCanHo == item.Id);
                                string _ghiChu = "Phí dịch vụ T" + current_month + "/" + current_year + ", ";
                                double _tongTien = 0;
                                foreach (var _item in ch_pts)
                                {
                                    var _i = phuongtiens.Find(x => x.Id == _item.IdPhuongTien);
                                    var _lx = loaixes.Find(x => x.Id == _item.IdLoaiXe);
                                    if (_i != null)
                                    {
                                        _ghiChu += _i.Ten + " " + _item.BienKiemSoat + "; ";
                                    }
                                    if (_lx != null)
                                    {
                                        _tongTien += _lx.DonGia.Value;
                                    }
                                }
                                foreach (var _ldv in loaidichvus)
                                {
                                    _tongTien += (_ldv.DonGia.Value * item.DienTich.Value);
                                }
                                phieuNew.Add(new QuanLyPhi()
                                {
                                    Id = Guid.NewGuid().ToString(),
                                    SoPhieu = SP,
                                    isGanNhat = true,
                                    isXeNgoai = false,
                                    NguoiDongPhi = item.ChuSoHuu,
                                    IdCanHo = item.Id,
                                    IdChungCu = taoNhanh.IdChungCu,
                                    LoaiDongPhi = DefineData.eLoaiDongPhi.THANG.ToString(),
                                    TrangThai = false,
                                    GhiChu = _ghiChu,
                                    TongTien = _tongTien,
                                });
                                // Set Phiếu cũ 
                                phieu.isGanNhat = false;
                                phieuUpdate.Add(phieu);
                            }
                        }
                        else
                        {
                            var ch_pts = canho_phuongtiens.FindAll(x => x.IdCanHo == item.Id);
                            string _ghiChu = "Phí dịch vụ T" + current_month + "/" + current_year + ", ";
                            double _tongTien = 0;
                            foreach (var _item in ch_pts)
                            {
                                var _i = phuongtiens.Find(x => x.Id == _item.IdPhuongTien);
                                var _lx = loaixes.Find(x => x.Id == _item.IdLoaiXe);
                                if (_i != null)
                                {
                                    _ghiChu += _i.Ten + " " + _item.BienKiemSoat + "; ";
                                }
                                if (_lx != null)
                                {
                                    _tongTien += _lx.DonGia.Value;
                                }
                            }
                            foreach (var _ldv in loaidichvus)
                            {
                                _tongTien += (_ldv.DonGia.Value * item.DienTich.Value);
                            }
                            phieuNew.Add(new QuanLyPhi()
                            {
                                Id = Guid.NewGuid().ToString(),
                                SoPhieu = SP,
                                isGanNhat = true,
                                isXeNgoai = false,
                                NguoiDongPhi = item.ChuSoHuu,
                                IdCanHo = item.Id,
                                IdChungCu = taoNhanh.IdChungCu,
                                LoaiDongPhi = DefineData.eLoaiDongPhi.THANG.ToString(),
                                TrangThai = false,
                                GhiChu = _ghiChu,
                                TongTien = _tongTien,
                            });
                        }
                    }

                    foreach (var item in xengoais)
                    {
                        var phieu = phieuxengoais.Find(x => x.IdXeNgoai == item.Id);
                        string SP = "";
                        if (phieuNew.Count() > 0)
                        {
                            SP = GetNextSoPhieuInList(phieuNew);
                        }
                        else
                        {
                            SP = soPhieu;
                        }
                        if (phieu != null)
                        {
                            if (phieu.Created.Month < current_month)
                            {
                                string _ghiChu = "Phí gửi ";
                                double _tongTien = 0;
                                var _i = phuongtiens.Find(x => x.Id == item.IdPhuongTien);
                                var _lx = loaixes.Find(x => x.Id == item.IdLoaiXe);
                                if (_i != null)
                                {
                                    _ghiChu += _i.Ten + " " + item.BienKiemSoat + " T" + current_month + "/" + current_year;
                                }
                                if (_lx != null)
                                {
                                    _tongTien += _lx.DonGia.Value;
                                }
                                phieuNew.Add(new QuanLyPhi()
                                {
                                    Id = Guid.NewGuid().ToString(),
                                    SoPhieu = SP,
                                    isGanNhat = true,
                                    isXeNgoai = true,
                                    NguoiDongPhi = item.Ten,
                                    IdXeNgoai = item.Id,
                                    IdChungCu = taoNhanh.IdChungCu,
                                    IdLoaiXe = item.IdLoaiXe,
                                    LoaiDongPhi = DefineData.eLoaiDongPhi.THANG.ToString(),
                                    TrangThai = false,
                                    GhiChu = _ghiChu,
                                    TongTien = _tongTien,
                                });

                                // Set Phiếu cũ 
                                phieu.isGanNhat = false;
                                phieuUpdate.Add(phieu);
                            }
                        }
                        else
                        {
                            string _ghiChu = "Phí gửi ";
                            double _tongTien = 0;
                            var _i = phuongtiens.Find(x => x.Id == item.IdPhuongTien);
                            var _lx = loaixes.Find(x => x.Id == item.IdLoaiXe);
                            if (_i != null)
                            {
                                _ghiChu += _i.Ten + " " + item.BienKiemSoat + " T" + current_month + "/" + current_year;
                            }
                            if (_lx != null)
                            {
                                _tongTien += _lx.DonGia.Value;
                            }
                            phieuNew.Add(new QuanLyPhi()
                            {
                                Id = Guid.NewGuid().ToString(),
                                SoPhieu = SP,
                                isGanNhat = true,
                                isXeNgoai = true,
                                NguoiDongPhi = item.Ten,
                                IdXeNgoai = item.Id,
                                IdChungCu = taoNhanh.IdChungCu,
                                IdLoaiXe = item.IdLoaiXe,
                                LoaiDongPhi = DefineData.eLoaiDongPhi.THANG.ToString(),
                                TrangThai = false,
                                GhiChu = _ghiChu,
                                TongTien = _tongTien,
                            });
                        }
                    }
                    _dbContext.UpdateRange(phieuUpdate);
                    _dbContext.AddRange(phieuNew);
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
        public ErrorMessage GetThongTinPhieuThu(string Id, bool isXeNgoai)
        {
            string tPhi = "Phí ";
            ErrorMessage msg = new ErrorMessage(ErrorMessage.eState.ThanhCong);
            var loaixes = _dbContext.LoaiXe.ToList();
            List<ModelQuanLyPhi> rs = new List<ModelQuanLyPhi>();
            if (isXeNgoai)
            {
                var XeNgoai = GetXeNgoai(Id).Data;
                if (XeNgoai != null)
                {
                    ModelQuanLyPhi obj = new ModelQuanLyPhi();
                    var loaixe = loaixes.Find(x => x.Id == XeNgoai.IdLoaiXe);
                    obj.TenDichVu = tPhi + XeNgoai.TenPhuongTien;
                    obj.PhuongTien = XeNgoai.TenPhuongTien;
                    obj.LoaiXe = XeNgoai.TenLoaiXe;
                    obj.BienKiemSoat = XeNgoai.BienKiemSoat;
                    if (loaixe != null)
                    {
                        obj.Gia = loaixe.DonGia ?? 0;
                    }
                    obj.SoLuong = 1;
                    obj.ThanhTien = obj.SoLuong * obj.Gia;
                    rs.Add(obj);
                }
            }
            else
            {
                CanHo CanHo = GetCanHo(Id).Data;
                if (CanHo != null)
                {
                    var LoaiDichVus = _dbContext.LoaiDichVu.Where(x => x.TrangThai).ToList();
                    foreach (var item in LoaiDichVus)
                    {
                        ModelQuanLyPhi obj = new ModelQuanLyPhi();
                        var loaidichvu = LoaiDichVus.Find(x => x.Id == item.Id && x.TrangThai);
                        if (loaidichvu != null)
                        {
                            obj.TenDichVu = tPhi + loaidichvu.Ten;
                            obj.Gia = loaidichvu.DonGia ?? 0;
                        }
                        obj.PhuongTien = "-";
                        obj.LoaiXe = "-";
                        obj.BienKiemSoat = "-";
                        obj.SoLuong = CanHo.DienTich ?? 1;
                        obj.ThanhTien = obj.SoLuong * obj.Gia;
                        rs.Add(obj);
                    }
                    foreach (var item in CanHo.PhuongTiens)
                    {
                        ModelQuanLyPhi obj = new ModelQuanLyPhi();
                        var loaixe = loaixes.Find(x => x.Id == item.IdLoaiXe);
                        obj.TenDichVu = tPhi + item.TenPhuongTien;
                        obj.PhuongTien = item.TenPhuongTien;
                        obj.LoaiXe = item.TenLoaiXe;
                        obj.BienKiemSoat = item.BienKiemSoat;
                        if (loaixe != null)
                        {
                            obj.Gia = loaixe.DonGia ?? 0;
                        }
                        obj.SoLuong = 1;
                        obj.ThanhTien = obj.SoLuong * obj.Gia;
                        rs.Add(obj);
                    }
                }
            }
            msg.Data = rs;
            return msg;
        }
        // Xác nhận đóng phí

        #endregion
    }
}
