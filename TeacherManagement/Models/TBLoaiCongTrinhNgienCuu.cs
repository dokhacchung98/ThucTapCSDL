namespace TeacherManagement.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TBLoaiCongTrinhNgienCuu")]
    public partial class TBLoaiCongTrinhNgienCuu
    {
        public TBLoaiCongTrinhNgienCuu()
        {
            TBNghienCuuKhoaHocs = new HashSet<TBNghienCuuKhoaHoc>();
        }

        [Key]
        public int MaLoaiCongTrinh { get; set; }
        
        public string TenLoaiCongTrinh { get; set; }

        public int? MaVaiTro { get; set; }

        public int? MaLoaiHinh { get; set; }

        public virtual TBLoaiHinhNghienCuu TBLoaiHinhNghienCuu { get; set; }

        public virtual TBVaiTroNghienCuuKhoaHoc TBVaiTroNghienCuuKhoaHoc { get; set; }
        
        public virtual ICollection<TBNghienCuuKhoaHoc> TBNghienCuuKhoaHocs { get; set; }
    }
}