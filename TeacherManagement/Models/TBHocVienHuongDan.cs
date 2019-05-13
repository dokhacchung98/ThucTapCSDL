namespace TeacherManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBHocVienHuongDan")]
    public partial class TBHocVienHuongDan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBHocVienHuongDan()
        {
            TBChiTietHuongDans = new HashSet<TBChiTietHuongDan>();
        }

        [Key]
        public int MaHocVien { get; set; }

        [StringLength(255)]
        public string TenHocVien { get; set; }

        public int? MaLopHuongDan { get; set; }

        public int? MaLoaiHuongDan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBChiTietHuongDan> TBChiTietHuongDans { get; set; }

        public virtual TBLoaiHuongDan TBLoaiHuongDan { get; set; }

        public virtual TBLopHuongDan TBLopHuongDan { get; set; }
    }
}
