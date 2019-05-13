namespace TeacherManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBLoaiBaiBao")]
    public partial class TBLoaiBaiBao
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLoaiBaiBao()
        {
            TBBaiBaos = new HashSet<TBBaiBao>();
        }

        [Key]
        public int MaLoaiBaiBao { get; set; }

        [StringLength(255)]
        public string TenLoaiBao { get; set; }

        public double? QuyRaGioChuan { get; set; }

        [StringLength(255)]
        public string DonVitinh { get; set; }

        [StringLength(255)]
        public string GhiChu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBBaiBao> TBBaiBaos { get; set; }
    }
}
