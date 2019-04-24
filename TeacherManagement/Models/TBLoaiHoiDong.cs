namespace TeacherManagement.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TBLoaiHoiDong")]
    public partial class TBLoaiHoiDong
    {
        public TBLoaiHoiDong()
        {
            TBHoiDongs = new HashSet<TBHoiDong>();
        }

        [Key]
        public int MaLoaiHoiDong { get; set; }
        
        public string TenLoaiHoiDong { get; set; }
        
        public virtual ICollection<TBHoiDong> TBHoiDongs { get; set; }
    }
}