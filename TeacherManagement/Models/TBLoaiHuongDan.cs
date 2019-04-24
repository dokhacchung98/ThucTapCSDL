namespace TeacherManagement.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TBLoaiHuongDan")]
    public partial class TBLoaiHuongDan
    {
        public TBLoaiHuongDan()
        {
            TBHocVienHuongDans = new HashSet<TBHocVienHuongDan>();
        }

        [Key]
        public int MaLoaiHD { get; set; }
        
        public string TenLoaiHD { get; set; }
        
        public string TenDeDaoTao { get; set; }
        
        public virtual ICollection<TBHocVienHuongDan> TBHocVienHuongDans { get; set; }
    }
}