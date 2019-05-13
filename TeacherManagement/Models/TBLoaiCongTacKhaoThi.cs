namespace TeacherManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBLoaiCongTacKhaoThi")]
    public partial class TBLoaiCongTacKhaoThi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLoaiCongTacKhaoThi()
        {
            TBCongTacKhaoThis = new HashSet<TBCongTacKhaoThi>();
        }

        [Key]
        public int MaLoaiCongTacKT { get; set; }

        [StringLength(255)]
        public string TenLoaiCongTacKT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBCongTacKhaoThi> TBCongTacKhaoThis { get; set; }
    }
}
