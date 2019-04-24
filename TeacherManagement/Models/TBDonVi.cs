namespace TeacherManagement.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TBDonVi")]
    public partial class TBDonVi
    {
        public TBDonVi()
        {
            TBChiTietChucVuChinhQuyens = new HashSet<TBChiTietChucVuChinhQuyen>();
        }

        [Key]
        public int MaDonVi { get; set; }
        
        public string TenDonVi { get; set; }
        
        public virtual ICollection<TBChiTietChucVuChinhQuyen> TBChiTietChucVuChinhQuyens { get; set; }
    }
}