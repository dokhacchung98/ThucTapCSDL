namespace TeacherManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBCongTacKhaoThi")]
    public partial class TBCongTacKhaoThi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBCongTacKhaoThi()
        {
            TBChiTietCongTacKhaoThis = new HashSet<TBChiTietCongTacKhaoThi>();
        }

        [Key]
        public int MaCongTacKT { get; set; }

        [StringLength(255)]
        public string TenCongTacKhaoThi { get; set; }

        public int? MaLoaiCongTac { get; set; }

        public double? QuyRaGioChuan { get; set; }

        [StringLength(1)]
        public string DonViTinh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBChiTietCongTacKhaoThi> TBChiTietCongTacKhaoThis { get; set; }

        public virtual TBLoaiCongTacKhaoThi TBLoaiCongTacKhaoThi { get; set; }
    }
}
