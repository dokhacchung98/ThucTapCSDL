namespace TeacherManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBChucVuChuyenMon")]
    public partial class TBChucVuChuyenMon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBChucVuChuyenMon()
        {
            TBChiTietChuVuChuyenMons = new HashSet<TBChiTietChuVuChuyenMon>();
            TBChiTietDinhMucGiangDays = new HashSet<TBChiTietDinhMucGiangDay>();
            TBChiTietDinhMucNghienCuus = new HashSet<TBChiTietDinhMucNghienCuu>();
        }

        [Key]
        public int MaChucVuCM { get; set; }

        [StringLength(255)]
        public string TenChuVuCM { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBChiTietChuVuChuyenMon> TBChiTietChuVuChuyenMons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBChiTietDinhMucGiangDay> TBChiTietDinhMucGiangDays { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBChiTietDinhMucNghienCuu> TBChiTietDinhMucNghienCuus { get; set; }
    }
}
