namespace TeacherManagement.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TBTruongDaiHoc")]
    public partial class TBTruongDaiHoc
    {
        public TBTruongDaiHoc()
        {
            TBHes = new HashSet<TBHe>();
        }

        [Key]
        public int MaTruong { get; set; }
        
        public string TenTruong { get; set; }
        
        public string Nuoc { get; set; }
        
        public virtual ICollection<TBHe> TBHes { get; set; }
    }
}