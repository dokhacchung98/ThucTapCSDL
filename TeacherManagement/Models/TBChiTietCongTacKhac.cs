namespace TeacherManagement.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TBChiTietCongTacKhac")]
    public partial class TBChiTietCongTacKhac
    {
        [Key]
        public int Ma { get; set; }

        public int? MaGV { get; set; }

        public int? MaCongTac { get; set; }
        
        public string VaiTro { get; set; }
        
        public string GhiChu { get; set; }

        public virtual TBCongTacKhac TBCongTacKhac { get; set; }

        public virtual TBGiaoVien TBGiaoVien { get; set; }
    }
}