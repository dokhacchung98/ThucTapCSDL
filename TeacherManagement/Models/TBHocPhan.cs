namespace TeacherManagement.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TBHocPhan")]
    public partial class TBHocPhan
    {
       
        public TBHocPhan()
        {
            TBLopMonHocGiangDays = new HashSet<TBLopMonHocGiangDay>();
        }

        [Key]
        public int MaHocPhan { get; set; }
        
        public string TenHocPhan { get; set; }

        public int? SoTinChi { get; set; }

        public int? SoTiet { get; set; }

        public int? MaLoaiHocPhan { get; set; }

        public virtual TBLoaiHocPhan TBLoaiHocPhan { get; set; }
        
        public virtual ICollection<TBLopMonHocGiangDay> TBLopMonHocGiangDays { get; set; }
    }
}