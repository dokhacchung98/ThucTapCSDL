namespace TeacherManagement.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TBHoatDongNghienCuuKH")]
    public partial class TBHoatDongNghienCuuKH
    {
        
        public TBHoatDongNghienCuuKH()
        {
            TBChiTietHoatDongNghienCuuKHs = new HashSet<TBChiTietHoatDongNghienCuuKH>();
        }

        [Key]
        public int MaHoatDongNghienCuuKH { get; set; }
        
        public string NoiDung { get; set; }
        
        public virtual ICollection<TBChiTietHoatDongNghienCuuKH> TBChiTietHoatDongNghienCuuKHs { get; set; }
    }
}