﻿using System;
namespace QuanLyChiPhi.Entities
{
    public class TimKiem
    {
        public string Keyword { get; set; }
        public string IdPhuongTien { get; set; }
        public string IdLoaiXe { get; set; }
        public string IdChungCu { get; set; }
    }

    public class TimKiemPhieu
    {
        public string Keyword { get; set; }
        public string IdChungCu { get; set; }
        public int Thang { get; set; }
        public string IdLoaiXe { get; set; }
        public int DaDongPhi { get; set; }
        public int LoaiNguoiDung { get; set; }
    }

    public class TaoNhanhPhieu
    {
        public string IdChungCu { get; set; }
    }
}

