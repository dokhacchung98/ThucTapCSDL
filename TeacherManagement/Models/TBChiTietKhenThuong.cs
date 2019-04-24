namespace TeacherManagement.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TBChiTietKhenThuong")]
    public partial class TBChiTietKhenThuong
    {
        [Key]
        public int Ma { get; set; }

        public int? MaGV { get; set; }

        public int? MaKhenThuong { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NamKhenThuong { get; set; }

        public virtual TBGiaoVien TBGiaoVien { get; set; }

        public virtual TBKhenThuong TBKhenThuong { get; set; }
    }
}