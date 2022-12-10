using QuanLyChiPhi.Common;
using QuanLyChiPhi.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;
using static QuanLyChiPhi.Common.DefineData;
using QuanLyChiPhi.Model;

namespace QuanLyChiPhi.Common
{

    public class AppSettings
    {
        public int AutoUpdate { get; set; }
        public string DuongDanUpload { get; set; }
        public string SmartEOSUrl { get; set; }
        public string SCMUrl { get; set; }
        public string QLTDUrl { get; set; }

    }

    public class TrangThaiQuyTrinh
    {
        public string IdTrangThai { get; set; }
        public string TenTrangThai { get; set; }
        public int LoaiTrangThai { set; get; }
    }
    public class ErrorMessage
    {
        public enum eState : int
        {
            KhongThanhCong = 500,
            ThanhCong = 200,
            TaoQuyTrinhThanhCong = 1,
            VanDangSuDung = 2,
            QuaSoLuongDangCo = 3,
            CapNhatThanhCong = 5,
            XoaThanhCong = 6,
            ThemMoiDuLieu = 7,
            MaBiTrung = 11,
            ImportDuLieuThanhCong = 13,
            ExportDuLieuThanhCong = 15,
            ChuyenTiepThanhCong = 16,
            ChuaDangNhap = 18,
            QuyTrinhKhongTonTai = 20,
            QuyTrinhDaChuyenTruocDo = 21,
            KhongTimThayTrangThai = 22,
            LoiKhac = 99,
            KhongCoDuLieu = 23,
        }
        public ErrorMessage(eState nState)
        {
            Status = nState;
        }

        [JsonProperty("Message")]
        public string Message { get; set; }

        [JsonProperty("StatusCode")]
        public int StatusCode { get; set; }
        [JsonProperty("Status")]
        public eState Status
        {
            //get { return (eState)StatusCode; }
            set
            {
                StatusCode = (int)value;
                switch (value)
                {
                    case eState.QuaSoLuongDangCo:
                        Message = "Nhiều hơn số lượng đang có";
                        StatusCode = (int)eState.KhongThanhCong;
                        break;
                    case eState.TaoQuyTrinhThanhCong:
                        Message = "Tạo quy trình thành công";
                        StatusCode = (int)eState.ThanhCong;
                        break;
                    case eState.CapNhatThanhCong:
                        Message = "Cập nhật dữ liệu thành công!";
                        StatusCode = (int)eState.ThanhCong;
                        break;
                    case eState.XoaThanhCong:
                        Message = "Xóa dữ liệu thành công!";
                        StatusCode = (int)eState.ThanhCong;
                        break;
                    case eState.ThemMoiDuLieu:
                        Message = "Thêm mới thành công";
                        StatusCode = (int)eState.ThanhCong;
                        break;
                    case eState.ChuyenTiepThanhCong:
                        Message = "Chuyển tiếp thành công!";
                        StatusCode = (int)eState.ThanhCong;
                        break;
                    case eState.ImportDuLieuThanhCong:
                        Message = "Nhận dữ liệu thành công!";
                        StatusCode = (int)eState.ThanhCong;
                        break;
                    case eState.ExportDuLieuThanhCong:
                        Message = "Xuất dữ liệu thành công!";
                        StatusCode = (int)eState.ThanhCong;
                        break;
                    case eState.MaBiTrung:
                        Message = "Mã bị trùng!";
                        StatusCode = (int)eState.KhongThanhCong;
                        break;
                    case eState.VanDangSuDung:
                        Message = Message;
                        Message = "Danh mục vẫn đang sử dụng!";
                        StatusCode = (int)eState.KhongThanhCong;
                        break;
                    case eState.ChuaDangNhap:
                        Message = "Đăng nhập không thành công vui lòng kiểm tra lại!";
                        StatusCode = (int)eState.KhongThanhCong;
                        break;

                    case eState.QuyTrinhKhongTonTai:
                        Message = "Quy trình không tồn tại vui lòng kiểm tra!";
                        StatusCode = (int)eState.KhongThanhCong;
                        break;
                    case eState.QuyTrinhDaChuyenTruocDo:
                        Message = "Quy trình đã được chuyển trước đó vui lòng kiểm tra!";
                        StatusCode = (int)eState.KhongThanhCong;
                        break;
                    case eState.KhongTimThayTrangThai:
                        Message = "Không tìm thấy trạng thái, vui lòng kiểm tra cài đặt quy trình!";
                        StatusCode = (int)eState.KhongThanhCong;
                        break;
                    case eState.KhongThanhCong:
                        this.Message = "Có lỗi trong quá trình xử lý!" + Message;
                        //this.message = "Không kết nối được với máy chủ!";
                        StatusCode = (int)eState.KhongThanhCong;
                        break;
                    case eState.ThanhCong:
                        Message = "Xử lý thành công!";
                        StatusCode = (int)eState.ThanhCong;
                        break;

                    case eState.LoiKhac:
                        //Message = Message;
                        StatusCode = (int)eState.KhongThanhCong;
                        break;
                    case eState.KhongCoDuLieu:
                        Message = "Chưa được bão dưỡng ! Vui lòng chọn loại bão dưỡng .";
                        StatusCode = (int)eState.ThanhCong;
                        break;
                }
            }
        }
        [JsonProperty("Data")]
        public dynamic Data { set; get; }
        public void SetDanhMucDangSuDung(string sMess)
        {
            Message = sMess;
            Status = eState.VanDangSuDung;
        }

        public void SetLoi(string sMess)
        {
            Message = sMess;
            Status = eState.LoiKhac;
            Data = sMess;
        }

        public void SetVang(string sMess)
        {
            Message = "Xảy ra lỗi!";
            Status = eState.LoiKhac;
            Data = sMess;
        }

        public void SetThanhCong(string sMess)
        {
            Message = sMess;
            Status = eState.ThanhCong;
        }
    }


    public class ErrorMessages<T>

    {
        [JsonProperty("Message")]
        public string Message { get; set; }

        [JsonProperty("StatusCode")]
        public int StatusCode { set; get; }

        [JsonProperty("Data")]
        public List<T> Data { set; get; }
    }

    public class CurrentUser
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string TenNhanVien { get; set; }
        public string MaNhanVien { get; set; }
        public string Email { get; set; }
        public string DienThoai { get; set; }
        public bool IsLocked { get; set; }
        public int Level { get; set; }
        public CurrentUser() { }
        public CurrentUser(string Id)
        {
            this.Id = Id;
        }
    }

    public static class Dungchung
    {
        public static DateTime? UnixTimeStampToDateTime(double unixTimeStamp)
        {
            if (unixTimeStamp == 0)
                return null;
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }

        public static double DateTimeToUnixTimeStamp(DateTime? time)
        {
            if (time == null)
                return 0;
            DateTime dt = time ?? DateTime.Now;
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).ToLocalTime();
            var epoch = (dt - dtDateTime).TotalSeconds;
            return epoch;
        }

        public static DateTime UnixTimeStampToDateTime_NotNull(double unixTimeStamp)
        {
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public static string GetNextSoQuyTrinhChungBanDau(DefineData.eTable eTable)
        {
            string sTT = "";
            switch (eTable)
            {
                case DefineData.eTable.QUANLYDONGPHI:
                    sTT = "QLDP";
                    break;
            }

            DateTime dt = DateTime.Now;
            if (dt.Month < 10)
                sTT += "0" + dt.Month.ToString() + dt.Year.ToString() + "_";
            else
                sTT += dt.Month.ToString() + dt.Year.ToString() + "_";
            return sTT;
        }
        public static string GetNextSoQuyTrinhChungKetThuc(string sTT, string SoQuyTrinh)
        {
            int nID = 1;
            if (!string.IsNullOrEmpty(SoQuyTrinh))
                nID = int.Parse(SoQuyTrinh.Split("_")[1].ToString() ?? "1") + 1;

            string s = nID.ToString();
            while (s.Length < 4)
            {
                s = "0" + s;
            }
            return sTT + s;
        }
        public static bool KiemTraMaTrungExcel(ExcelWorksheet sheet1, ErrorMessage err)
        {
            List<string> Mas = new List<string>();
            string sMaTrung = "";
            for (int row = 4; row <= sheet1.Cells.End.Row; row++)
            {
                string sMa = GetCell(sheet1, row, 2);
                if (sMa == "")
                    break;
                string sMaFind = Mas.Find(x => x == sMa);
                if (sMaFind != null)
                    sMaTrung += sMaFind + "; ";
                else
                    Mas.Add(sMa);
            }
            if (sMaTrung != "")
            {
                sMaTrung = "Mã trong tệp excel bị trùng: " + sMaTrung;
                err.SetLoi(sMaTrung);
                return false;
            }
            return true;
        }
        public static bool KiemTraMaTrungDb(ExcelWorksheet sheet1, ErrorMessage err, List<string> Mas)
        {
            string sMaTrung = "";
            for (int row = 4; row <= sheet1.Cells.End.Row; row++)
            {
                string sMa = GetCell(sheet1, row, 2);
                if (sMa == "")
                    break;
                var Ma = Mas.Find(x => x == sMa);
                if (!String.IsNullOrEmpty(Ma))
                {
                    string sMaFind = Ma;
                    sMaTrung += sMaFind + "; ";
                }
            }
            if (sMaTrung != "")
            {
                sMaTrung = "Mã bị trùng: " + sMaTrung;
                err.SetLoi(sMaTrung);
                return false;
            }
            return true;
        }
        public static bool KiemTraTempExcel(ExcelWorksheet sheet1, ErrorMessage err, List<string> listColumnName, string tieuDe, int totalCol)
        {
            if (sheet1 != null)
            {
                string TieuDeExcel = GetCell(sheet1, 1, 1);
                if (TieuDeExcel != tieuDe)
                {
                    err.SetLoi("Tiêu đề sai định dạng: " + TieuDeExcel);
                    return false;
                }
                string ColumnSai = "";
                for (int col = 1; col <= totalCol; col++)
                {
                    var colName = GetCell(sheet1, 2, col);
                    if (!listColumnName.Contains(colName) && colName != "")
                    {
                        ColumnSai += colName + ',';
                    }
                }
                if (ColumnSai != "")
                {
                    err.SetLoi("Sai định dạng cột: " + ColumnSai);
                    return false;
                }
                return true;
            }
            return false;
        }
        public static string GetCell(ExcelWorksheet sheet, int nRow, int nCol)
        {
            string sValue = "";
            if (sheet.Cells[nRow, nCol].Value != null)
                sValue = sheet.Cells[nRow, nCol].Value.ToString();
            return sValue;
        }
        public static int GetCellToInt(ExcelWorksheet sheet, int nRow, int nCol)
        {
            if (sheet.Cells[nRow, nCol].Value != null)
                return (int)sheet.Cells[nRow, nCol].Value;
            return 0;
        }

        public static double GetCellToDouble(ExcelWorksheet sheet, int nRow, int nCol)
        {
            if (sheet.Cells[nRow, nCol].Value != null)
                return (double)sheet.Cells[nRow, nCol].Value;
            return 0;
        }
        public static bool IsValidDecimalNumber(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return false;
            return !s.Any(c => !(char.IsDigit(c) || c == '.')) && !(s.Count(c => c == '.') > 1);
        }
        public static bool KiemTraInsertOrUpdate(string Id)
        {
            if (!string.IsNullOrEmpty(Id) && Id.Length > 5)
                return false;
            return true;
        }

        public static void DrawTableExcel(ExcelWorksheet sheet1, int nRowBegin, int nRowEnd, int nColBegin, int nColEnd)
        {
            sheet1.Cells[nRowBegin, nColBegin, nRowEnd, nColEnd].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Medium;
            sheet1.Cells[nRowBegin, nColBegin, nRowEnd, nColEnd].Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Medium;
            sheet1.Cells[nRowBegin, nColBegin, nRowEnd, nColEnd].Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Medium;
            sheet1.Cells[nRowBegin, nColBegin, nRowEnd, nColEnd].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Medium;

            sheet1.Cells[nRowBegin, nColBegin, nRowEnd, nColEnd].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            sheet1.Cells[nRowBegin, nColBegin, nRowEnd, nColEnd].Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            sheet1.Cells[nRowBegin, nColBegin, nRowEnd, nColEnd].Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            sheet1.Cells[nRowBegin, nColBegin, nRowEnd, nColEnd].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
        }
        public static string Capitalize(string str)
        {
            if (str.Length == 0)
                return "";
            else if (str.Length == 1)
                return str.ToUpper();
            else
                return char.ToUpper(str[0]) + str.Substring(1);
        }
        public static string NumberToText(double inputNumber, bool suffix = true)
        {
            string[] unitNumbers = new string[] { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string[] placeValues = new string[] { "", "nghìn", "triệu", "tỷ" };
            bool isNegative = false;

            // -12345678.3445435 => "-12345678"
            string sNumber = inputNumber.ToString("#");
            double number = Convert.ToDouble(sNumber);
            if (number < 0)
            {
                number = -number;
                sNumber = number.ToString();
                isNegative = true;
            }


            int ones, tens, hundreds;

            int positionDigit = sNumber.Length;   // last -> first

            string result = " ";


            if (positionDigit == 0)
                result = unitNumbers[0] + result;
            else
            {
                // 0:       ###
                // 1: nghìn ###,###
                // 2: triệu ###,###,###
                // 3: tỷ    ###,###,###,###
                int placeValue = 0;

                while (positionDigit > 0)
                {
                    // Check last 3 digits remain ### (hundreds tens ones)
                    tens = hundreds = -1;
                    ones = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                    positionDigit--;
                    if (positionDigit > 0)
                    {
                        tens = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                        positionDigit--;
                        if (positionDigit > 0)
                        {
                            hundreds = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                            positionDigit--;
                        }
                    }

                    if ((ones > 0) || (tens > 0) || (hundreds > 0) || (placeValue == 3))
                        result = placeValues[placeValue] + result;

                    placeValue++;
                    if (placeValue > 3) placeValue = 1;

                    if ((ones == 1) && (tens > 1))
                        result = "một " + result;
                    else
                    {
                        if ((ones == 5) && (tens > 0))
                            result = "lăm " + result;
                        else if (ones > 0)
                            result = unitNumbers[ones] + " " + result;
                    }
                    if (tens < 0)
                        break;
                    else
                    {
                        if ((tens == 0) && (ones > 0)) result = "lẻ " + result;
                        if (tens == 1) result = "mười " + result;
                        if (tens > 1) result = unitNumbers[tens] + " mươi " + result;
                    }
                    if (hundreds < 0) break;
                    else
                    {
                        if ((hundreds > 0) || (tens > 0) || (ones > 0))
                            result = unitNumbers[hundreds] + " trăm " + result;
                    }
                    result = " " + result;
                }
            }
            result = result.Trim();
            if (isNegative) result = "Âm " + result;
            return result + (suffix ? " đồng chẵn" : "");
        }
    }
    public static class FileDinhKem
    {
        //public static void SetFileDinhKem(ApplicationContext db, List<PSM_FileDinhKem> listFile, DefineData.eTable eTable, string nIDBang, string IdTrangThai)
        //{
        //    var dinhKem_TrangThais = db.PSM_FileDinhKem_TrangThai;
        //    if (listFile != null)
        //        foreach (var item in listFile)
        //        {
        //            item.IdBang = nIDBang;
        //            item.TenBang = eTable.ToString();
        //            item.Created = item.Modified = DateTime.Now;
        //            if (item.isXoa)
        //            {
        //                if (!string.IsNullOrEmpty(item.Id))
        //                {
        //                    PSM_FileDinhKem_TrangThai dinhKem_TrangThai = dinhKem_TrangThais.AsNoTracking().FirstOrDefault(x => x.IdFileDinhKem == item.Id);
        //                    if (dinhKem_TrangThai != null)
        //                        db.Remove(dinhKem_TrangThai);
        //                    db.PSM_FileDinhKem.Remove(item);
        //                    string sFile = (Path.Combine(Directory.GetCurrentDirectory(), "uploaded") ?? "") + item.FileNameGUI;
        //                    if (File.Exists(sFile))
        //                        File.Delete(sFile);
        //                }
        //            }
        //            else
        //            {
        //                if (string.IsNullOrEmpty(item.Id))
        //                {
        //                    PSM_FileDinhKem itemFind = db.PSM_FileDinhKem.FirstOrDefault(x => x.TenBang == item.TenBang && x.IdBang == nIDBang && x.FileNameGUI == item.FileNameGUI);
        //                    if (itemFind != null)
        //                        return;
        //                    item.Id = Guid.NewGuid().ToString();
        //                    db.PSM_FileDinhKem.Add(item);
        //                    PSM_FileDinhKem_TrangThai dinhKem_TrangThai = new PSM_FileDinhKem_TrangThai() { Id = Guid.NewGuid().ToString(), IdTrangThai = IdTrangThai, IdFileDinhKem = item.Id };
        //                    db.PSM_FileDinhKem_TrangThai.Add(dinhKem_TrangThai);
        //                }
        //                else
        //                    db.PSM_FileDinhKem.Update(item);
        //            }
        //        }
        //}
        public static List<PSM_FileDinhKem> GetListFileDinhKem(ApplicationContext db, string TableName, string IdTable)
        {
            List<PSM_FileDinhKem> TepDinhKems = db.PSM_FileDinhKem.Where(x => x.TenBang == TableName && x.IdBang == IdTable).ToList();
            foreach (PSM_FileDinhKem item in TepDinhKems)
            {
                string sFileName = Path.Combine(Directory.GetCurrentDirectory(), "uploaded") + item.FileNameGUI;
                if (item.FileNameGUI != null)
                    item.Link = "/uploader/api/hdfiles?filename=" + Dungchung.Base64Encode(item.FileNameGUI)
                            + "&path=" + Dungchung.Base64Encode(sFileName);
            }
            return TepDinhKems;
        }
    }

}



