namespace TeacherManagement.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TBChiTietTrinhDo")]
    public partial class TBChiTietTrinhDo
    {
        [Key]
        public int Ma { get; set; }

        public int? MaTrinhDo { get; set; }

        public int? MaGV { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NamCapBang { get; set; }

        public virtual TBGiaoVien TBGiaoVien { get; set; }

        public virtual TBTrinhDoNgoaiNgu TBTrinhDoNgoaiNgu { get; set; }
    }
}