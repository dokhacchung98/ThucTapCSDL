namespace TeacherManagement.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TBHocVi")]
    public partial class TBHocVi
    {
        public TBHocVi()
        {
            TBChiTietHocVis = new HashSet<TBChiTietHocVi>();
        }

        [Key]
        public int MaHocVi { get; set; }
        
        public string TenHocVi { get; set; }
        
        public virtual ICollection<TBChiTietHocVi> TBChiTietHocVis { get; set; }
    }
}