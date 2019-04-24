namespace TeacherManagement.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TBChiTietKyLuat")]
    public partial class TBChiTietKyLuat
    {
        [Key]
        public int Ma { get; set; }

        public int? MaGV { get; set; }

        public int? MaKyLuat { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NamKyLuat { get; set; }

        public virtual TBGiaoVien TBGiaoVien { get; set; }

        public virtual TBKyLuat TBKyLuat { get; set; }
    }
}