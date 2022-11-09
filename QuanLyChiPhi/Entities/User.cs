namespace QuanLyChiPhi.Entities
{
    public class User : Auditable
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string TenNhanVien { get; set; }
        public string MaNhanVien { get; set; }
        public string Email { get; set; }
        public string DienThoai { get; set; }
        public bool IsLocked { get; set; }
    }
}
