namespace QuanLyChiPhi.Common
{
    public class DefineData
    {
        public enum eLoaiThoiGian
        {
            NGAY = 0,
            TUAN = 1,
            THANG = 2,
            NAM = 3,
        }
        public enum eLoaiDongPhi
        {
            THANG = 0,
            QUY = 1,
            NAM = 2
        }
        public enum eAction
        {

        }
        public enum ePay
        {
            TIENMAT,
            CHUYENKHOAN
        }
        public enum eLoai
        {
            DANCU,
            XENGOAI
        }
        public enum eTable
        {
            QUANLYDONGPHI
        };
        public enum eModify
        {
            Them,
            Sua,
            Xoa,
            ChuyenTiep,
            KhongDuyet,
            Import,
            Export,
        }
    }
}
