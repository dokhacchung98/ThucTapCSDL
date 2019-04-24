namespace TeacherManagement.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TBHocVienHuongDan")]
    public partial class TBHocVienHuongDan
    {
        public TBHocVienHuongDan()
        {
            TBChiTietHuongDans = new HashSet<TBChiTietHuongDan>();
        }

        [Key]
        public int MaHocVien { get; set; }
        
        public string TenHocVien { get; set; }

        public int? MaLopHuongDan { get; set; }

        public int? MaLoaiHuongDan { get; set; }
        
        public virtual ICollection<TBChiTietHuongDan> TBChiTietHuongDans { get; set; }

        public virtual TBLoaiHuongDan TBLoaiHuongDan { get; set; }

        public virtual TBLopHuongDan TBLopHuongDan { get; set; }
    }
}