namespace TeacherManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBBienSoanSach")]
    public partial class TBBienSoanSach
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBBienSoanSach()
        {
            TBSachChuyenKhaos = new HashSet<TBSachChuyenKhao>();
        }

        [Key]
        public int MaLoaiSach { get; set; }

        [StringLength(255)]
        public string TenLoaiSach { get; set; }

        public double? QuyRaGioChuan { get; set; }

        [StringLength(255)]
        public string DonViTinh { get; set; }

        [StringLength(255)]
        public string GhiChu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBSachChuyenKhao> TBSachChuyenKhaos { get; set; }
    }
}
