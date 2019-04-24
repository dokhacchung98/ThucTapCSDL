namespace TeacherManagement.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TBLoaiDoiTuongDaoTao")]
    public partial class TBLoaiDoiTuongDaoTao
    {
        public TBLoaiDoiTuongDaoTao()
        {
            TBHeDaoTaos = new HashSet<TBHeDaoTao>();
            TBLopMonHocGiangDays = new HashSet<TBLopMonHocGiangDay>();
        }

        [Key]
        public int MaLoaiDoiTuongDaoTao { get; set; }
        
        public string TenLoaiDoiTuongDaoTao { get; set; }
        
        public virtual ICollection<TBHeDaoTao> TBHeDaoTaos { get; set; }
        
        public virtual ICollection<TBLopMonHocGiangDay> TBLopMonHocGiangDays { get; set; }
    }
}