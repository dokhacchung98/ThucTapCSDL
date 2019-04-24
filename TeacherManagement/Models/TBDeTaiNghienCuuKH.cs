namespace TeacherManagement.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TBDeTaiNghienCuuKH")]
    public partial class TBDeTaiNghienCuuKH
    {
        [Key]
        public int Ma { get; set; }

        public int? MaDeTaiKH { get; set; }

        public int? MaGV { get; set; }

        public int? SoDeTai { get; set; }

        public virtual TBDeTaiKhoaHoc TBDeTaiKhoaHoc { get; set; }

        public virtual TBGiaoVien TBGiaoVien { get; set; }
    }
}