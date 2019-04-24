namespace TeacherManagement.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TBChiTietNghienCuu")]
    public partial class TBChiTietNghienCuu
    {
        [Key]
        public int Ma { get; set; }

        public int? MaGV { get; set; }

        public int? MaNghienCuu { get; set; }

        public double? GioChuan { get; set; }

        public virtual TBGiaoVien TBGiaoVien { get; set; }

        public virtual TBNghienCuuKhoaHoc TBNghienCuuKhoaHoc { get; set; }
    }
}