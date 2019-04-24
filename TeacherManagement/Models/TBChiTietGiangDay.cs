namespace TeacherManagement.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TBChiTietGiangDay")]
    public partial class TBChiTietGiangDay
    {
        [Key]
        public int Ma { get; set; }

        public int? MaGV { get; set; }

        public int? MaLop { get; set; }

        public int? SoTiet { get; set; }

        public int? MaLoaiGiangDay { get; set; }

        public virtual TBGiaoVien TBGiaoVien { get; set; }

        public virtual TBLopMonHocGiangDay TBLopMonHocGiangDay { get; set; }
    }
}