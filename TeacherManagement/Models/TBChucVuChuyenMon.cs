namespace TeacherManagement.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TBChucVuChuyenMon")]
    public partial class TBChucVuChuyenMon
    {
        public TBChucVuChuyenMon()
        {
            TBChiTietChuVuChuyenMons = new HashSet<TBChiTietChuVuChuyenMon>();
            TBChiTietDinhMucGiangDays = new HashSet<TBChiTietDinhMucGiangDay>();
            TBChiTietDinhMucNghienCuus = new HashSet<TBChiTietDinhMucNghienCuu>();
        }

        [Key]
        public int MaChucVuCM { get; set; }
        
        public string TenChuVuCM { get; set; }
        
        public virtual ICollection<TBChiTietChuVuChuyenMon> TBChiTietChuVuChuyenMons { get; set; }
        
        public virtual ICollection<TBChiTietDinhMucGiangDay> TBChiTietDinhMucGiangDays { get; set; }
        
        public virtual ICollection<TBChiTietDinhMucNghienCuu> TBChiTietDinhMucNghienCuus { get; set; }
    }
}