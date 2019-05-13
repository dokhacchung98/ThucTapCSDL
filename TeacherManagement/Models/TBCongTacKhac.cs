namespace TeacherManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBCongTacKhac")]
    public partial class TBCongTacKhac
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBCongTacKhac()
        {
            TBChiTietCongTacKhacs = new HashSet<TBChiTietCongTacKhac>();
        }

        [Key]
        public int MaCongTac { get; set; }

        [StringLength(255)]
        public string NoidungCongTac { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBChiTietCongTacKhac> TBChiTietCongTacKhacs { get; set; }
    }
}
