namespace TeacherManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBChiTietThacSi")]
    public partial class TBChiTietThacSi
    {
        [Key]
        public int MaChiTiet { get; set; }

        public int? MaGV { get; set; }

        [StringLength(255)]
        public string TenLuanVan { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NamCapBang { get; set; }

        [StringLength(255)]
        public string ThacSyChuyenNganh { get; set; }

        [StringLength(255)]
        public string NoiDaoTao { get; set; }

        public virtual TBGiaoVien TBGiaoVien { get; set; }
    }
}
