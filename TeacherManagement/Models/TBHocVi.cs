namespace TeacherManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBHocVi")]
    public partial class TBHocVi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBHocVi()
        {
            TBChiTietHocVis = new HashSet<TBChiTietHocVi>();
        }

        [Key]
        public int MaHocVi { get; set; }

        [StringLength(255)]
        public string TenHocVi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBChiTietHocVi> TBChiTietHocVis { get; set; }
    }
}
