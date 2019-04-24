namespace TeacherManagement.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TBLoaiCongTacKhaoThi")]
    public partial class TBLoaiCongTacKhaoThi
    {
        public TBLoaiCongTacKhaoThi()
        {
            TBCongTacKhaoThis = new HashSet<TBCongTacKhaoThi>();
        }

        [Key]
        public int MaLoaiCongTacKT { get; set; }
        
        public string TenLoaiCongTacKT { get; set; }
        
        public virtual ICollection<TBCongTacKhaoThi> TBCongTacKhaoThis { get; set; }
    }
}