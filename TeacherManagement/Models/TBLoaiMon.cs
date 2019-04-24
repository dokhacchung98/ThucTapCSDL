namespace TeacherManagement.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TBLoaiMon")]
    public partial class TBLoaiMon
    {
        public TBLoaiMon()
        {
            TBChiTietDinhMucGiangDays = new HashSet<TBChiTietDinhMucGiangDay>();
        }

        [Key]
        public int MaLoaiMon { get; set; }
        
        public string TenLoaiMon { get; set; }

        public int? DinhMuc { get; set; }
        
        public virtual ICollection<TBChiTietDinhMucGiangDay> TBChiTietDinhMucGiangDays { get; set; }
    }
}