namespace TeacherManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBLoaiDeTaiKH")]
    public partial class TBLoaiDeTaiKH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLoaiDeTaiKH()
        {
            TBDeTaiKhoaHocs = new HashSet<TBDeTaiKhoaHoc>();
        }

        [Key]
        public int MaLoaiDeTaiKH { get; set; }

        [StringLength(255)]
        public string TenLoaiDeTaiKH { get; set; }

        public double? QuyRaGioChuan { get; set; }

        [StringLength(255)]
        public string DonVitinh { get; set; }

        [StringLength(255)]
        public string GhiChu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBDeTaiKhoaHoc> TBDeTaiKhoaHocs { get; set; }
    }
}
