namespace TeacherManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBLoaiDoiTuongDaoTao")]
    public partial class TBLoaiDoiTuongDaoTao
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLoaiDoiTuongDaoTao()
        {
            TBHeDaoTaos = new HashSet<TBHeDaoTao>();
            TBLopMonHocGiangDays = new HashSet<TBLopMonHocGiangDay>();
        }

        [Key]
        public int MaLoaiDoiTuongDaoTao { get; set; }

        [StringLength(255)]
        public string TenLoaiDoiTuongDaoTao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBHeDaoTao> TBHeDaoTaos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLopMonHocGiangDay> TBLopMonHocGiangDays { get; set; }
    }
}
