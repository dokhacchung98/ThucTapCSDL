namespace TeacherManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBChucVuDang")]
    public partial class TBChucVuDang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBChucVuDang()
        {
            TBDKMienGiams = new HashSet<TBDKMienGiam>();
            TBGiaoViens = new HashSet<TBGiaoVien>();
        }

        [Key]
        public int MaChucVuDang { get; set; }

        [StringLength(255)]
        public string TenChucVuDang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBDKMienGiam> TBDKMienGiams { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBGiaoVien> TBGiaoViens { get; set; }
    }
}
