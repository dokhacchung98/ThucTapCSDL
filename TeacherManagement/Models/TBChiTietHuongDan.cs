namespace TeacherManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBChiTietHuongDan")]
    public partial class TBChiTietHuongDan
    {
        [Key]
        public int Ma { get; set; }

        public int? MaGV { get; set; }

        public int? MaHocVien { get; set; }

        [StringLength(255)]
        public string TenDeTai { get; set; }

        public virtual TBGiaoVien TBGiaoVien { get; set; }

        public virtual TBHocVienHuongDan TBHocVienHuongDan { get; set; }
    }
}
