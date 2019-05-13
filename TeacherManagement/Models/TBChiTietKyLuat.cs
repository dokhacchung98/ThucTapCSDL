namespace TeacherManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBChiTietKyLuat")]
    public partial class TBChiTietKyLuat
    {
        [Key]
        public int MaChiTiet { get; set; }

        public int? MaGV { get; set; }

        [StringLength(255)]
        public string NoiDung { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NamKyLuat { get; set; }

        public virtual TBGiaoVien TBGiaoVien { get; set; }
    }
}
