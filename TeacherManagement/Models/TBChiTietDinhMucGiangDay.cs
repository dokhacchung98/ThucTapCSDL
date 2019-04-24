namespace TeacherManagement.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TBChiTietDinhMucGiangDay")]
    public partial class TBChiTietDinhMucGiangDay
    {
        [Key]
        public int Ma { get; set; }

        public int? MaDinhMuc { get; set; }

        public int? MaHocHam { get; set; }

        public int? MaChuyenMon { get; set; }

        public int? MaLoaichuyenMon { get; set; }

        public virtual TBChucVuChuyenMon TBChucVuChuyenMon { get; set; }

        public virtual TBHocHam TBHocHam { get; set; }

        public virtual TBLoaiMon TBLoaiMon { get; set; }
    }
}