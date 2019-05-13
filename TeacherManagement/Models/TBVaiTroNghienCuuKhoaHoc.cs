namespace TeacherManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBVaiTroNghienCuuKhoaHoc")]
    public partial class TBVaiTroNghienCuuKhoaHoc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBVaiTroNghienCuuKhoaHoc()
        {
            TBDeTaiNghienCuuKHs = new HashSet<TBDeTaiNghienCuuKH>();
            TBVietBaiBaoKhoaHocs = new HashSet<TBVietBaiBaoKhoaHoc>();
            TBVietSachChuyenKhaos = new HashSet<TBVietSachChuyenKhao>();
        }

        [Key]
        public int MaVaiTro { get; set; }

        public int? MaLoai { get; set; }

        [StringLength(255)]
        public string TenVaiTro { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBDeTaiNghienCuuKH> TBDeTaiNghienCuuKHs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBVietBaiBaoKhoaHoc> TBVietBaiBaoKhoaHocs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBVietSachChuyenKhao> TBVietSachChuyenKhaos { get; set; }
    }
}
