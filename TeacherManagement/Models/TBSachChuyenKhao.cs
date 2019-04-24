namespace TeacherManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TBSachChuyenKhao")]
    public partial class TBSachChuyenKhao
    {
        public TBSachChuyenKhao()
        {
            TBVietSachChuyenKhaos = new HashSet<TBVietSachChuyenKhao>();
        }

        [Key]
        public int MaSach { get; set; }
        
        public string TenSach { get; set; }
        
        public string SoISBN { get; set; }
        
        public string NoiXuatBan { get; set; }

        public int? MaLoaiSach { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NamXuatBan { get; set; }

        public int? TongTrang { get; set; }

        public virtual TBBienSoanSach TBBienSoanSach { get; set; }
        
        public virtual ICollection<TBVietSachChuyenKhao> TBVietSachChuyenKhaos { get; set; }
    }
}