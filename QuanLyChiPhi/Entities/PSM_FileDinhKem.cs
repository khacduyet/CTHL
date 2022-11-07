using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyChiPhi.Entities
{
    public class PSM_FileDinhKem : Auditable
    {
        [StringLength(255)]
        public string? TenBang { get; set; }
        [StringLength(36)]
        public string? IdBang { set; get; }

        [StringLength(1000)]
        public string? TenTaiLieu { get; set; }
        [StringLength(1000)]
        public string? FileName { get; set; }
        public string? FileNameGUI { get; set; }
        [StringLength(1000)]
        public string? LinkName { get; set; }
        public bool? isPheDuyet { get; set; }
        public bool? isQuyTrinh { get; set; }
        public bool? isPhaiNop { get; set; }
        public string? GhiChu { get; set; }
        [StringLength(1000)]
        public string? Link { get; set; }
        [StringLength(1000)]
        public string? LinkMau { get; set; }
        [NotMapped]
        public bool isXoa { get; set; } = false;
    }
}
