namespace TeacherManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBLoaiHuongDan")]
    public partial class TBLoaiHuongDan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLoaiHuongDan()
        {
            TBHocVienHuongDans = new HashSet<TBHocVienHuongDan>();
        }

        [Key]
        public int MaLoaiHD { get; set; }

        [StringLength(255)]
        public string TenLoaiHD { get; set; }

        [StringLength(255)]
        public string TenDeDaoTao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBHocVienHuongDan> TBHocVienHuongDans { get; set; }
    }
}
