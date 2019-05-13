namespace TeacherManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBChiTietTrinhDoNgoaiNgu")]
    public partial class TBChiTietTrinhDoNgoaiNgu
    {
        [Key]
        public int MaChiTiet { get; set; }

        public int? MaGV { get; set; }

        [StringLength(255)]
        public string TenTrinhDo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NamCapBang { get; set; }

        public virtual TBGiaoVien TBGiaoVien { get; set; }
    }
}
