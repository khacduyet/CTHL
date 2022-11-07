using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyChiPhi.Entities
{
    public class ChungCu : Auditable
    {
        public string? Ma { get; set; }
        public string? Ten { get; set; }
        public string? GhiChu { get; set; }
        public bool TrangThai { get; set; }
    }

    public class LoaiDichVu : Auditable
    {
        public string? Ma { get; set; }
        public string? Ten { get; set; }
        public double? DonGia { get; set; }
        public string? GhiChu { get; set; }
        public bool TrangThai { get; set; }
    }

    public class LoaiXe : Auditable
    {
        public string? Ma { get; set; }
        public string? Ten { get; set; }
        public double? DonGia { get; set; }
        public string? GhiChu { get; set; }
        public bool TrangThai { get; set; }
    }

    public class PhuongTien : Auditable
    {
        public string? Ma { get; set; }
        public string? Ten { get; set; }
        public string? GhiChu { get; set; }
        public bool TrangThai { get; set; }
    }

    public class LoaiDongPhi : Auditable
    {
        public string? Ma { get; set; }
        public string? Ten { get; set; }
        public string? GhiChu { get; set; }
        public bool TrangThai { get; set; }
    }

    // Quản lý dân cư
    public class CanHo : Auditable
    {
        public string? Ma { get; set; }
        public string? Ten { get; set; }
        public string? ChuSoHuu { get; set; }
        public string? SoDienThoai { get; set; }
        public double? DienTich { get; set; }
        public string? GhiChu { get; set; }
        public bool TrangThai { get; set; }
        public string? IdChungCu { get; set; }
        [NotMapped]
        public string? TenChungCu { get; set; }
        [NotMapped]
        public List<Model_PhuongTien> PhuongTiens { get; set; }
    }
    public class Model_PhuongTien
    {
        public string? IdPhuongTien { get; set; }
        public string MaPhuongTien { get; set; }
        public string TenPhuongTien { get; set; }
        public string BienKiemSoat { get; set; }
        public bool TrangThai { get; set; }
    }

    public class CanHo_PhuongTien : Auditable
    {
        public string? IdCanHo { get; set; }
        public string? IdPhuongTien { get; set; }
        public string? BienKiemSoat { get; set; }
        public bool TrangThai { get; set; }
    }

    // Quản lý xe ngoài 
    public class XeNgoai : Auditable
    {
        public string? Ma { get; set; }
        public string? Ten { get; set; }
        public string? BienKiemSoat { get; set; }
        public string? SoDienThoai { get; set; }
        public string? GhiChu { get; set; }
        public bool TrangThai { get; set; }
        public string? IdPhuongTien { get; set; }
        public string? IdLoaiXe { get; set; }
        public string? IdChungCu { get; set; }
        [NotMapped]
        public string? TenChungCu { get; set; }
        [NotMapped]
        public string? TenPhuongTien { get; set; }
        [NotMapped]
        public string? TenLoaiXe { get; set; }
    }


    // Quản lý đóng phi hàng tháng/quý/năm
    public class QuanLyPhi : Auditable
    {
        public string? NguoiDongPhi { get; set; }
        public int? Ngay { get; set; }
        public int? Thang { get; set; }
        public int? Nam { get; set; }
        public double? TongTien { get; set; }
        public string? GhiChu { get; set; }
        public bool TrangThai { get; set; }
        public string? IdCanHo { get; set; }
        public string? IdXeNgoai { get; set; }
        public string? IdLoaiXe { get; set; }
        public string? IdLoaiDongPhi { get; set; }
        public string? IdChungCu { get; set; }
        [NotMapped]
        public string? TenChungCu { get; set; }
        [NotMapped]
        public string? TenPhuongTien { get; set; }
        [NotMapped]
        public string? TenLoaiXe { get; set; }
        [NotMapped]
        public string? TenCanHo { get; set; }
    }

}
