namespace TeacherManagement.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TBVietBaiBaoKhoaHoc")]
    public partial class TBVietBaiBaoKhoaHoc
    {
        [Key]
        public int Ma { get; set; }

        public int? MaBaiBao { get; set; }

        public int? MaGV { get; set; }
        
        public string SoBaiBao { get; set; }

        public virtual TBBaiBao TBBaiBao { get; set; }

        public virtual TBGiaoVien TBGiaoVien { get; set; }
    }
}