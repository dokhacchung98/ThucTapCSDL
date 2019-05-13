namespace TeacherManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBHocPhan")]
    public partial class TBHocPhan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBHocPhan()
        {
            TBLopMonHocGiangDays = new HashSet<TBLopMonHocGiangDay>();
        }

        [Key]
        public int MaHocPhan { get; set; }

        [StringLength(255)]
        public string TenHocPhan { get; set; }

        public int? SoTinChi { get; set; }

        public int? SoTiet { get; set; }

        public int? MaLoaiHocPhan { get; set; }

        public virtual TBLoaiHocPhan TBLoaiHocPhan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLopMonHocGiangDay> TBLopMonHocGiangDays { get; set; }
    }
}
