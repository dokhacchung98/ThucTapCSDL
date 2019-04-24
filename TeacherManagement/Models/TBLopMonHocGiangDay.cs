namespace TeacherManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TBLopMonHocGiangDay")]
    public partial class TBLopMonHocGiangDay
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLopMonHocGiangDay()
        {
            TBChiTietGiangDays = new HashSet<TBChiTietGiangDay>();
        }

        [Key]
        public int MaLopMonHocGiangDay { get; set; }
        
        public string TenLopMonHocGiangDay { get; set; }

        public int? MaHocPhan { get; set; }

        public int? MaLoaiDoituongDaoTao { get; set; }

        public int? SiSo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ThoiDiem { get; set; }
        
        public virtual ICollection<TBChiTietGiangDay> TBChiTietGiangDays { get; set; }

        public virtual TBHocPhan TBHocPhan { get; set; }

        public virtual TBLoaiDoiTuongDaoTao TBLoaiDoiTuongDaoTao { get; set; }
    }
}