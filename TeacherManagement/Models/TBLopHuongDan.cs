namespace TeacherManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBLopHuongDan")]
    public partial class TBLopHuongDan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLopHuongDan()
        {
            TBHocVienHuongDans = new HashSet<TBHocVienHuongDan>();
        }

        [Key]
        public int MaLop { get; set; }

        [StringLength(255)]
        public string TenLopHuongDan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBHocVienHuongDan> TBHocVienHuongDans { get; set; }
    }
}
