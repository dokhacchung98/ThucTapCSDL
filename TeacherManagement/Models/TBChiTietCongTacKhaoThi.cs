namespace TeacherManagement.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TBChiTietCongTacKhaoThi")]
    public partial class TBChiTietCongTacKhaoThi
    {
        [Key]
        public int Ma { get; set; }

        public int? MaGV { get; set; }

        public int? MaCongTac { get; set; }

        public int? MaHocPhan { get; set; }

        public int? SoBai { get; set; }

        public double? SoGio { get; set; }

        public virtual TBCongTacKhaoThi TBCongTacKhaoThi { get; set; }

        public virtual TBGiaoVien TBGiaoVien { get; set; }
    }
}