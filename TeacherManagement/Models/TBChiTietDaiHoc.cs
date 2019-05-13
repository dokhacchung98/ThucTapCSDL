namespace TeacherManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBChiTietDaiHoc")]
    public partial class TBChiTietDaiHoc
    {
        [Key]
        public int MaChiTiet { get; set; }

        public int? MaGV { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NamTotNghiep { get; set; }

        [StringLength(255)]
        public string HeDaoTao { get; set; }

        [StringLength(255)]
        public string NoiDaoTao { get; set; }

        [StringLength(255)]
        public string NganhHoc { get; set; }

        [StringLength(255)]
        public string NuocDaoTao { get; set; }

        public virtual TBGiaoVien TBGiaoVien { get; set; }
    }
}
