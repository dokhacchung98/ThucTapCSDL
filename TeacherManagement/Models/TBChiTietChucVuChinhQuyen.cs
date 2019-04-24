namespace TeacherManagement.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TBChiTietChucVuChinhQuyen")]
    public partial class TBChiTietChucVuChinhQuyen
    {
        [Key]
        public int Ma { get; set; }

        public int? MaDonVi { get; set; }

        public int? MaChucVuCQ { get; set; }

        public int? MaGV { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ThoiDiemNhan { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ThoiDiemKetThuc { get; set; }

        public virtual TBChucVuChinhQuyen TBChucVuChinhQuyen { get; set; }

        public virtual TBDonVi TBDonVi { get; set; }

        public virtual TBGiaoVien TBGiaoVien { get; set; }
    }
}