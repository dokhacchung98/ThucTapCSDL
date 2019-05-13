namespace TeacherManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBChiTietHoatDongNghienCuuKH")]
    public partial class TBChiTietHoatDongNghienCuuKH
    {
        [Key]
        public int MaChiTiet { get; set; }

        public int? MaGV { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NamHoatDong { get; set; }

        [StringLength(255)]
        public string NoiDung { get; set; }

        public virtual TBGiaoVien TBGiaoVien { get; set; }
    }
}
