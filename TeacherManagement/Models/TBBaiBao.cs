namespace TeacherManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBBaiBao")]
    public partial class TBBaiBao
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBBaiBao()
        {
            TBVietBaiBaoKhoaHocs = new HashSet<TBVietBaiBaoKhoaHoc>();
        }

        [Key]
        public int MaBaiBao { get; set; }

        [StringLength(255)]
        public string TenBaiBao { get; set; }

        [StringLength(1)]
        public string SoISBN { get; set; }

        [StringLength(255)]
        public string NoiXuatBan { get; set; }

        public int? MaLoaiBaiBao { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayXuatBan { get; set; }

        public virtual TBLoaiBaiBao TBLoaiBaiBao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBVietBaiBaoKhoaHoc> TBVietBaiBaoKhoaHocs { get; set; }
    }
}
