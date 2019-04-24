namespace TeacherManagement.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TBChucVuChinhQuyen")]
    public partial class TBChucVuChinhQuyen
    {
        public TBChucVuChinhQuyen()
        {
            TBChiTietChucVuChinhQuyens = new HashSet<TBChiTietChucVuChinhQuyen>();
            TBDKMienGiams = new HashSet<TBDKMienGiam>();
        }

        [Key]
        public int MaChucVuChinhQuyen { get; set; }
        
        public string TenChucVuChinhQuyen { get; set; }
        
        public virtual ICollection<TBChiTietChucVuChinhQuyen> TBChiTietChucVuChinhQuyens { get; set; }
        
        public virtual ICollection<TBDKMienGiam> TBDKMienGiams { get; set; }
    }
}