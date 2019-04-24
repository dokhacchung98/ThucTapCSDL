namespace TeacherManagement.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TBDKMienGiam")]
    public partial class TBDKMienGiam
    {
        [Key]
        public int MaDK { get; set; }

        public int? MaChucVuDang { get; set; }

        public int? MaChucVuChinhQuyen { get; set; }

        public double? TyLe { get; set; }
        
        public string NoiDung { get; set; }

        public virtual TBChucVuChinhQuyen TBChucVuChinhQuyen { get; set; }

        public virtual TBChucVuDang TBChucVuDang { get; set; }
    }
}