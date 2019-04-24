namespace TeacherManagement.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TBChiTietDaoTaoThucTe")]
    public partial class TBChiTietDaoTaoThucTe
    {
        [Key]
        public int Ma { get; set; }

        public int? MaGV { get; set; }

        public int? MaDaoTao { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NamDaoTao { get; set; }

        public virtual TBDaoTaoThucTe TBDaoTaoThucTe { get; set; }

        public virtual TBGiaoVien TBGiaoVien { get; set; }
    }
}