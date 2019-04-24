namespace TeacherManagement.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TBBienSoanSach")]
    public partial class TBBienSoanSach
    {
        public TBBienSoanSach()
        {
            TBSachChuyenKhaos = new HashSet<TBSachChuyenKhao>();
        }

        [Key]
        public int MaLoaiSach { get; set; }

        public string TenLoaiSach { get; set; }

        public double? QuyRaGioChuan { get; set; }
        
        public string DonViTinh { get; set; }
        
        public string GhiChu { get; set; }
        
        public virtual ICollection<TBSachChuyenKhao> TBSachChuyenKhaos { get; set; }
    }
}