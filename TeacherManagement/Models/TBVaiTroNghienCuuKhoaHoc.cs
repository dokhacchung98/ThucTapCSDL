namespace TeacherManagement.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TBVaiTroNghienCuuKhoaHoc")]
    public partial class TBVaiTroNghienCuuKhoaHoc
    {
        public TBVaiTroNghienCuuKhoaHoc()
        {
            TBLoaiCongTrinhNgienCuus = new HashSet<TBLoaiCongTrinhNgienCuu>();
        }

        [Key]
        public int MaVaiTro { get; set; }
        
        public string TenVaiTro { get; set; }
        
        public virtual ICollection<TBLoaiCongTrinhNgienCuu> TBLoaiCongTrinhNgienCuus { get; set; }
    }
}