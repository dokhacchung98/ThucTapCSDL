namespace TeacherManagement.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TBHocHam")]
    public partial class TBHocHam
    {
        public TBHocHam()
        {
            TBChiTietDinhMucGiangDays = new HashSet<TBChiTietDinhMucGiangDay>();
            TBChiTietDinhMucNghienCuus = new HashSet<TBChiTietDinhMucNghienCuu>();
            TBChiTietHocHams = new HashSet<TBChiTietHocHam>();
        }

        [Key]
        public int MaHocHam { get; set; }
        
        public string TenHocHam { get; set; }
        
        public virtual ICollection<TBChiTietDinhMucGiangDay> TBChiTietDinhMucGiangDays { get; set; }
        
        public virtual ICollection<TBChiTietDinhMucNghienCuu> TBChiTietDinhMucNghienCuus { get; set; }
        
        public virtual ICollection<TBChiTietHocHam> TBChiTietHocHams { get; set; }
    }
}