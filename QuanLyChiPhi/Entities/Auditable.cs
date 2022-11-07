using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyChiPhi.Entities
{
    public class Auditable
    {
        [Key]
        [StringLength(36)]
        public string Id { get; set; }
        public DateTime Created { get; set; }
        [StringLength(36)]
        public string? CreatedBy { get; set; }

        [StringLength(200)]
        public string? CreatedByName { get; set; }

        public DateTime Modified { get; set; }

        [StringLength(36)]
        public string? ModifiedBy { get; set; }

        [StringLength(200)]
        public string? ModifiedByName { get; set; }
    }
}
