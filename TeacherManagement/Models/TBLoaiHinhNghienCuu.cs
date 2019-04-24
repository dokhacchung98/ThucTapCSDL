namespace TeacherManagement.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TBLoaiHinhNghienCuu")]
    public partial class TBLoaiHinhNghienCuu
    {
        public TBLoaiHinhNghienCuu()
        {
            TBLoaiCongTrinhNgienCuus = new HashSet<TBLoaiCongTrinhNgienCuu>();
        }

        [Key]
        public int MaLoaiHinh { get; set; }
        
        public string TenLoaiHinh { get; set; }
        
        public virtual ICollection<TBLoaiCongTrinhNgienCuu> TBLoaiCongTrinhNgienCuus { get; set; }
    }
}