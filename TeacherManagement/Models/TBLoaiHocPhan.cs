namespace TeacherManagement.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TBLoaiHocPhan")]
    public partial class TBLoaiHocPhan
    {
        public TBLoaiHocPhan()
        {
            TBHocPhans = new HashSet<TBHocPhan>();
        }

        [Key]
        public int MaLoaiHocPhan { get; set; }
        
        public string TenLoaiHocPhan { get; set; }

        public double? QuyRaGioChuan { get; set; }
        
        public string DonViTinh { get; set; }
        
        public string GhiChu { get; set; }
        
        public virtual ICollection<TBHocPhan> TBHocPhans { get; set; }
    }
}