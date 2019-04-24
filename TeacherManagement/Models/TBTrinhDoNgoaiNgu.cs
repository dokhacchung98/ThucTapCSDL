namespace TeacherManagement.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TBTrinhDoNgoaiNgu")]
    public partial class TBTrinhDoNgoaiNgu
    {
        public TBTrinhDoNgoaiNgu()
        {
            TBChiTietTrinhDoes = new HashSet<TBChiTietTrinhDo>();
        }

        [Key]
        public int MaTrinhDo { get; set; }

        public string TenTrinhDo { get; set; }
        
        public virtual ICollection<TBChiTietTrinhDo> TBChiTietTrinhDoes { get; set; }
    }
}