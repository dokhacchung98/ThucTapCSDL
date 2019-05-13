namespace TeacherManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBChiTietHocHam")]
    public partial class TBChiTietHocHam
    {
        [Key]
        public int Ma { get; set; }

        public int? MaHocHam { get; set; }

        public int? MaGV { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ThoiDiemNhan { get; set; }

        public virtual TBGiaoVien TBGiaoVien { get; set; }

        public virtual TBHocHam TBHocHam { get; set; }
    }
}
