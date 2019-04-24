namespace TeacherManagement.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TBChiTietHoatDongNghienCuuKH")]
    public partial class TBChiTietHoatDongNghienCuuKH
    {
        [Key]
        public int Ma { get; set; }

        public int? MaGV { get; set; }

        public int? MaHoatDongNghienCuuKH { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NamHoatDong { get; set; }

        public virtual TBGiaoVien TBGiaoVien { get; set; }

        public virtual TBHoatDongNghienCuuKH TBHoatDongNghienCuuKH { get; set; }
    }
}