namespace TeacherManagement.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TBChiTietHuongDan")]
    public partial class TBChiTietHuongDan
    {
        [Key]
        public int Ma { get; set; }

        public int? MaGV { get; set; }

        public int? MaHocVien { get; set; }
        
        public string TenDeTai { get; set; }

        public virtual TBGiaoVien TBGiaoVien { get; set; }

        public virtual TBHocVienHuongDan TBHocVienHuongDan { get; set; }
    }
}