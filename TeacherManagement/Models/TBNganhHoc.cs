namespace TeacherManagement.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TBNganhHoc")]
    public partial class TBNganhHoc
    {
        public TBNganhHoc()
        {
            TBChiTietDaiHocs = new HashSet<TBChiTietDaiHoc>();
            TBChiTietThacSis = new HashSet<TBChiTietThacSi>();
            TBChiTietTienSis = new HashSet<TBChiTietTienSi>();
        }

        [Key]
        public int MaNganh { get; set; }
        
        public string TenNganh { get; set; }

        public int? MaHe { get; set; }

        public virtual ICollection<TBChiTietDaiHoc> TBChiTietDaiHocs { get; set; }
        
        public virtual ICollection<TBChiTietThacSi> TBChiTietThacSis { get; set; }
        
        public virtual ICollection<TBChiTietTienSi> TBChiTietTienSis { get; set; }

        public virtual TBHe TBHe { get; set; }
    }
}