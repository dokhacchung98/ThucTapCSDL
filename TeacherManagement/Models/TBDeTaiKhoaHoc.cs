namespace TeacherManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TBDeTaiKhoaHoc")]
    public partial class TBDeTaiKhoaHoc
    {
        public TBDeTaiKhoaHoc()
        {
            TBDeTaiNghienCuuKHs = new HashSet<TBDeTaiNghienCuuKH>();
        }

        [Key]
        public int MaDeTaiKhoaHoc { get; set; }
        
        public string TenDeTaiKhoaHoc { get; set; }
        
        public string SoISBN { get; set; }

        public int? MaLoaiDeTai { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayXuatBan { get; set; }

        public virtual TBLoaiDeTaiKH TBLoaiDeTaiKH { get; set; }

        public virtual ICollection<TBDeTaiNghienCuuKH> TBDeTaiNghienCuuKHs { get; set; }
    }
}