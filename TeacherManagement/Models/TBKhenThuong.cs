namespace TeacherManagement.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TBKhenThuong")]
    public partial class TBKhenThuong
    {
        public TBKhenThuong()
        {
            TBChiTietKhenThuongs = new HashSet<TBChiTietKhenThuong>();
        }

        [Key]
        public int MaKhenThuong { get; set; }
        
        public string NoiDung { get; set; }
        
        public virtual ICollection<TBChiTietKhenThuong> TBChiTietKhenThuongs { get; set; }
    }
}