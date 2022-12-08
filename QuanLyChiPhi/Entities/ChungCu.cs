﻿using QuanLyChiPhi.Common;
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
        public string? IdLoaiXe { get; set; }
        public string MaPhuongTien { get; set; }
        public string TenPhuongTien { get; set; }
        public string TenLoaiXe { get; set; }
        public string BienKiemSoat { get; set; }
        public bool TrangThai { get; set; }
    }

    public class CanHo_PhuongTien : Auditable
    {
        public string? IdCanHo { get; set; }
        public string? IdPhuongTien { get; set; }
        public string? IdLoaiXe { get; set; }
        public string? BienKiemSoat { get; set; }
        public bool TrangThai { get; set; }
        public string? IdChungCu { get; set; }
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
        public string? SoPhieu { get; set; }
        public string? NguoiDongPhi { get; set; }
        public int? Ngay { get; set; }
        public int? Thang { get; set; }
        public int? Nam { get; set; }
        public double? TongTien { get; set; }
        public string? GhiChu { get; set; }
        public bool TrangThai { get; set; }
        public string? SoDienThoai { get; set; }

        // Căn hộ
        public string? IdCanHo { get; set; }
        // End căn hộ

        // Xe ngoài
        public string? IdXeNgoai { get; set; }
        public string? IdLoaiXe { get; set; }
        // End xe ngoài

        public string? LoaiDongPhi { get; set; } = DefineData.eLoaiDongPhi.THANG.ToString();

        public string? IdChungCu { get; set; }
        public bool isXeNgoai { get; set; }
        public bool isGanNhat { get; set; } = true;
        public string? Pay { get; set; }
        [NotMapped]
        public string? TenChungCu { get; set; }
        [NotMapped]
        public string? TenPhuongTien { get; set; }
        [NotMapped]
        public string? TenLoaiXe { get; set; }
        [NotMapped]
        public string? TenCanHo { get; set; }
        [NotMapped]
        public List<ModelQuanLyPhi> ListPhi { get; set; }
    }

    public class ModelQuanLyPhi
    {
        public string TenDichVu { get; set; }
        public string PhuongTien { get; set; }
        public string LoaiXe { get; set; }
        public string BienKiemSoat { get; set; }
        public double SoLuong { get; set; }
        public double Gia { get; set; }
        public double ThanhTien { get; set; }
    }

}
