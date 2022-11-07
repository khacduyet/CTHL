namespace QuanLyChiPhi.Model
{
    public class TimKiemChung
    {
        public int? CurrentPage { get; set; } = 1;
        public int? PageSize { get; set; } = 25;
        public string Keyword { get; set; } = "";
      
    }

    public class TimKiemPhanKhu : TimKiemChung
    {
        public long? IdDuAn { get; set; }
    }

    public class TimKiemQuyTrinh : TimKiemChung
    {
        public long IdDuAn { get; set; }
        public string SoQuyTrinh { get; set; }
        public int TabTrangThai { get; set; }
        public double TuNgay { get; set; }
        public double DenNgay { get; set; }
    }

    public class TimKiemTraoDoi
    {
        public string eAction { get; set; }
        public string IdTable { get; set; }
    }
}
