namespace TeacherManagement.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TBHe")]
    public partial class TBHe
    {
        public TBHe()
        {
            TBNganhHocs = new HashSet<TBNganhHoc>();
        }

        [Key]
        public int MaHe { get; set; }

        public int? MaTruong { get; set; }
        
        public string TenHe { get; set; }

        public virtual TBTruongDaiHoc TBTruongDaiHoc { get; set; }
        
        public virtual ICollection<TBNganhHoc> TBNganhHocs { get; set; }
    }
}