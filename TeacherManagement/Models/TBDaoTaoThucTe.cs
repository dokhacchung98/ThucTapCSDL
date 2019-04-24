namespace TeacherManagement.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TBDaoTaoThucTe")]
    public partial class TBDaoTaoThucTe
    {
        public TBDaoTaoThucTe()
        {
            TBChiTietDaoTaoThucTes = new HashSet<TBChiTietDaoTaoThucTe>();
        }

        [Key]
        public int MaDaoTao { get; set; }
        
        public string NoiDung { get; set; }
        
        public string GhiChu { get; set; }
        
        public virtual ICollection<TBChiTietDaoTaoThucTe> TBChiTietDaoTaoThucTes { get; set; }
    }
}