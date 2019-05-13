namespace TeacherManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBChucVuChinhQuyen")]
    public partial class TBChucVuChinhQuyen
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBChucVuChinhQuyen()
        {
            TBChiTietChucVuChinhQuyens = new HashSet<TBChiTietChucVuChinhQuyen>();
            TBDKMienGiams = new HashSet<TBDKMienGiam>();
        }

        [Key]
        public int MaChucVuChinhQuyen { get; set; }

        [StringLength(255)]
        public string TenChucVuChinhQuyen { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBChiTietChucVuChinhQuyen> TBChiTietChucVuChinhQuyens { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBDKMienGiam> TBDKMienGiams { get; set; }
    }
}
