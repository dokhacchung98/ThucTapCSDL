namespace TeacherManagement.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TBLoaiDeTaiKH")]
    public partial class TBLoaiDeTaiKH
    {
        public TBLoaiDeTaiKH()
        {
            TBDeTaiKhoaHocs = new HashSet<TBDeTaiKhoaHoc>();
        }

        [Key]
        public int MaLoaiDeTaiKH { get; set; }
        
        public string TenLoaiDeTaiKH { get; set; }

        public double? QuyRaGioChuan { get; set; }
        
        public string DonVitinh { get; set; }
        
        public string GhiChu { get; set; }
        
        public virtual ICollection<TBDeTaiKhoaHoc> TBDeTaiKhoaHocs { get; set; }
    }
}