namespace TeacherManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBLoaiHoiDong")]
    public partial class TBLoaiHoiDong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLoaiHoiDong()
        {
            TBHoiDongs = new HashSet<TBHoiDong>();
        }

        [Key]
        public int MaLoaiHoiDong { get; set; }

        [StringLength(255)]
        public string TenLoaiHoiDong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBHoiDong> TBHoiDongs { get; set; }
    }
}
