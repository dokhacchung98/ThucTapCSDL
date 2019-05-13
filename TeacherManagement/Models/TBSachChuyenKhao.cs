namespace TeacherManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBSachChuyenKhao")]
    public partial class TBSachChuyenKhao
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBSachChuyenKhao()
        {
            TBVietSachChuyenKhaos = new HashSet<TBVietSachChuyenKhao>();
        }

        [Key]
        public int MaSach { get; set; }

        [StringLength(255)]
        public string TenSach { get; set; }

        [StringLength(1)]
        public string SoISBN { get; set; }

        [StringLength(255)]
        public string NoiXuatBan { get; set; }

        public int? MaLoaiSach { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NamXuatBan { get; set; }

        public int? TongTrang { get; set; }

        public virtual TBBienSoanSach TBBienSoanSach { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBVietSachChuyenKhao> TBVietSachChuyenKhaos { get; set; }
    }
}
