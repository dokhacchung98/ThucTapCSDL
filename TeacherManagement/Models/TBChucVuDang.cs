namespace TeacherManagement.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TBChucVuDang")]
    public partial class TBChucVuDang
    {
        public TBChucVuDang()
        {
            TBDKMienGiams = new HashSet<TBDKMienGiam>();
            TBGiaoViens = new HashSet<TBGiaoVien>();
        }

        [Key]
        public int MaChucVuDang { get; set; }
        
        public string TenChucVuDang { get; set; }
        
        public virtual ICollection<TBDKMienGiam> TBDKMienGiams { get; set; }
        
        public virtual ICollection<TBGiaoVien> TBGiaoViens { get; set; }
    }
}