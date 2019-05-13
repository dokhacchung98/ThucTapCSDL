namespace TeacherManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBLoaiHocPhan")]
    public partial class TBLoaiHocPhan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLoaiHocPhan()
        {
            TBHocPhans = new HashSet<TBHocPhan>();
        }

        [Key]
        public int MaLoaiHocPhan { get; set; }

        [StringLength(255)]
        public string TenLoaiHocPhan { get; set; }

        public double? QuyRaGioChuan { get; set; }

        [StringLength(255)]
        public string DonViTinh { get; set; }

        [StringLength(255)]
        public string GhiChu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBHocPhan> TBHocPhans { get; set; }
    }
}
