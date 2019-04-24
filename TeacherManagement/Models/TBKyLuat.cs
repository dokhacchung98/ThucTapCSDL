namespace TeacherManagement.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TBKyLuat")]
    public partial class TBKyLuat
    {
        public TBKyLuat()
        {
            TBChiTietKyLuats = new HashSet<TBChiTietKyLuat>();
        }

        [Key]
        public int MaKyLuat { get; set; }
        
        public string NoiDung { get; set; }
        
        public virtual ICollection<TBChiTietKyLuat> TBChiTietKyLuats { get; set; }
    }
}