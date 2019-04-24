namespace TeacherManagement.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TBCongTacKhaoThi")]
    public partial class TBCongTacKhaoThi
    {
        public TBCongTacKhaoThi()
        {
            TBChiTietCongTacKhaoThis = new HashSet<TBChiTietCongTacKhaoThi>();
        }

        [Key]
        public int MaCongTacKT { get; set; }
        
        public string TenCongTacKhaoThi { get; set; }

        public int? MaLoaiCongTac { get; set; }
        
        public virtual ICollection<TBChiTietCongTacKhaoThi> TBChiTietCongTacKhaoThis { get; set; }

        public virtual TBLoaiCongTacKhaoThi TBLoaiCongTacKhaoThi { get; set; }
    }
}