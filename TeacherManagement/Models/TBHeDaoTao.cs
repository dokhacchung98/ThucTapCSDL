namespace TeacherManagement.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TBHeDaoTao")]
    public partial class TBHeDaoTao
    {
        [Key]
        public int MaHeDaoTao { get; set; }
        
        public string TenHeDaoTao { get; set; }

        public int? MaLoaiDoiTuongDaoTao { get; set; }

        public virtual TBLoaiDoiTuongDaoTao TBLoaiDoiTuongDaoTao { get; set; }
    }
}