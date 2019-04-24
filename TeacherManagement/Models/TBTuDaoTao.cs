namespace TeacherManagement.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TBTuDaoTao")]
    public partial class TBTuDaoTao
    {
        [Key]
        public int MaTuDaoTao { get; set; }
        
        public string NoiDung { get; set; }

        public int? MaGv { get; set; }

        public virtual TBGiaoVien TBGiaoVien { get; set; }
    }
}