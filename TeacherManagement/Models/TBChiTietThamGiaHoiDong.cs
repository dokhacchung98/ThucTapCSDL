namespace TeacherManagement.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TBChiTietThamGiaHoiDong")]
    public partial class TBChiTietThamGiaHoiDong
    {
        [Key]
        public int Ma { get; set; }

        public int? MaGV { get; set; }

        public int? MaHoiDong { get; set; }
        
        public string GhiChu { get; set; }

        public int? SoLanThamGia { get; set; }

        public virtual TBGiaoVien TBGiaoVien { get; set; }

        public virtual TBHoiDong TBHoiDong { get; set; }
    }
}