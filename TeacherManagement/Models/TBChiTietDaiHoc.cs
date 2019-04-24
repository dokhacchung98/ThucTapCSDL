namespace TeacherManagement.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TBChiTietDaiHoc")]
    public partial class TBChiTietDaiHoc
    {
        [Key]
        public int Ma { get; set; }

        public int? MaNganh { get; set; }

        public int? MaGV { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NamTotNghiep { get; set; }

        public virtual TBGiaoVien TBGiaoVien { get; set; }

        public virtual TBNganhHoc TBNganhHoc { get; set; }
    }
}