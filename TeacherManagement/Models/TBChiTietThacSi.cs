namespace TeacherManagement.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TBChiTietThacSi")]
    public partial class TBChiTietThacSi
    {
        [Key]
        public int Ma { get; set; }

        public int? MaNganh { get; set; }

        public int? MaGV { get; set; }
        
        public string TenLuanVan { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NamCapBang { get; set; }

        public virtual TBGiaoVien TBGiaoVien { get; set; }

        public virtual TBNganhHoc TBNganhHoc { get; set; }
    }
}