namespace TeacherManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBChiTietChuVuChuyenMon")]
    public partial class TBChiTietChuVuChuyenMon
    {
        [Key]
        public int Ma { get; set; }

        public int? MaChucVuCM { get; set; }

        public int? MaGV { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ThoiDiemNhan { get; set; }

        public virtual TBChucVuChuyenMon TBChucVuChuyenMon { get; set; }

        public virtual TBGiaoVien TBGiaoVien { get; set; }
    }
}
