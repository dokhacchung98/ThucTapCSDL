namespace TeacherManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBLoaiMon")]
    public partial class TBLoaiMon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLoaiMon()
        {
            TBChiTietDinhMucGiangDays = new HashSet<TBChiTietDinhMucGiangDay>();
        }

        [Key]
        public int MaLoaiMon { get; set; }

        [StringLength(255)]
        public string TenLoaiMon { get; set; }

        public int? DinhMuc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBChiTietDinhMucGiangDay> TBChiTietDinhMucGiangDays { get; set; }
    }
}
