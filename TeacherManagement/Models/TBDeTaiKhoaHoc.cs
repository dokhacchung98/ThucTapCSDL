namespace TeacherManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBDeTaiKhoaHoc")]
    public partial class TBDeTaiKhoaHoc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBDeTaiKhoaHoc()
        {
            TBDeTaiNghienCuuKHs = new HashSet<TBDeTaiNghienCuuKH>();
        }

        [Key]
        public int MaDeTaiKhoaHoc { get; set; }

        [StringLength(255)]
        public string TenDeTaiKhoaHoc { get; set; }

        [StringLength(1)]
        public string SoISBN { get; set; }

        public int? MaLoaiDeTai { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayXuatBan { get; set; }

        public virtual TBLoaiDeTaiKH TBLoaiDeTaiKH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBDeTaiNghienCuuKH> TBDeTaiNghienCuuKHs { get; set; }
    }
}
