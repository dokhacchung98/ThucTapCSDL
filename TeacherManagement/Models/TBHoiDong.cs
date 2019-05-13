namespace TeacherManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBHoiDong")]
    public partial class TBHoiDong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBHoiDong()
        {
            TBChiTietThamGiaHoiDongs = new HashSet<TBChiTietThamGiaHoiDong>();
        }

        [Key]
        public int MaHoiDong { get; set; }

        [StringLength(255)]
        public string TenHoiDong { get; set; }

        public int? MaLoaiHoiDong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBChiTietThamGiaHoiDong> TBChiTietThamGiaHoiDongs { get; set; }

        public virtual TBLoaiHoiDong TBLoaiHoiDong { get; set; }
    }
}
