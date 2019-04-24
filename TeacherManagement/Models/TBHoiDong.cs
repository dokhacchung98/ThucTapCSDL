namespace TeacherManagement.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TBHoiDong")]
    public partial class TBHoiDong
    {
        public TBHoiDong()
        {
            TBChiTietThamGiaHoiDongs = new HashSet<TBChiTietThamGiaHoiDong>();
        }

        [Key]
        public int MaHoiDong { get; set; }
        
        public string TenHoiDong { get; set; }

        public int? MaLoaiHoiDong { get; set; }
        
        public virtual ICollection<TBChiTietThamGiaHoiDong> TBChiTietThamGiaHoiDongs { get; set; }

        public virtual TBLoaiHoiDong TBLoaiHoiDong { get; set; }
    }
}