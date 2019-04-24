namespace TeacherManagement.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TBNghienCuuKhoaHoc")]
    public partial class TBNghienCuuKhoaHoc
    {
        public TBNghienCuuKhoaHoc()
        {
            TBChiTietNghienCuus = new HashSet<TBChiTietNghienCuu>();
        }

        [Key]
        public int MaNghienCuu { get; set; }
        
        public string TenNghienCuu { get; set; }

        public int? MaLoaiCongTrinh { get; set; }
        
        public virtual ICollection<TBChiTietNghienCuu> TBChiTietNghienCuus { get; set; }

        public virtual TBLoaiCongTrinhNgienCuu TBLoaiCongTrinhNgienCuu { get; set; }
    }
}