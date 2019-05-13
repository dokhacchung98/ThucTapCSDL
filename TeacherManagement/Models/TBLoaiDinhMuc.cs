namespace TeacherManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBLoaiDinhMuc")]
    public partial class TBLoaiDinhMuc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLoaiDinhMuc()
        {
            TBChiTietDinhMucNghienCuus = new HashSet<TBChiTietDinhMucNghienCuu>();
        }

        [Key]
        public int MaLoai { get; set; }

        public int? DinhMuc { get; set; }

        [StringLength(255)]
        public string TenLoaiDinhMuc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBChiTietDinhMucNghienCuu> TBChiTietDinhMucNghienCuus { get; set; }
    }
}
