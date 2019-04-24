namespace TeacherManagement.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TBChiTietDinhMucNghienCuu")]
    public partial class TBChiTietDinhMucNghienCuu
    {
        [Key]
        public int Ma { get; set; }

        public int? MaLoaiDinhMuc { get; set; }

        public int? MaChuyenMon { get; set; }

        public int? MaHocHam { get; set; }

        public virtual TBChucVuChuyenMon TBChucVuChuyenMon { get; set; }

        public virtual TBHocHam TBHocHam { get; set; }

        public virtual TBLoaiDinhMuc TBLoaiDinhMuc { get; set; }
    }
}