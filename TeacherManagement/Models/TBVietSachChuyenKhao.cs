namespace TeacherManagement.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TBVietSachChuyenKhao")]
    public partial class TBVietSachChuyenKhao
    {
        [Key]
        public int Ma { get; set; }

        public int? MaSach { get; set; }

        public int? MaGV { get; set; }

        public int? SoTrang { get; set; }

        public virtual TBGiaoVien TBGiaoVien { get; set; }

        public virtual TBSachChuyenKhao TBSachChuyenKhao { get; set; }
    }
}