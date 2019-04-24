namespace TeacherManagement.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TBCongTacKhac")]
    public partial class TBCongTacKhac
    {
        public TBCongTacKhac()
        {
            TBChiTietCongTacKhacs = new HashSet<TBChiTietCongTacKhac>();
        }

        [Key]
        public int MaCongTac { get; set; }
        
        public string NoidungCongTac { get; set; }

        public virtual ICollection<TBChiTietCongTacKhac> TBChiTietCongTacKhacs { get; set; }
    }
}