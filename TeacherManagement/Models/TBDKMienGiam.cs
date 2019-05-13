namespace TeacherManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBDKMienGiam")]
    public partial class TBDKMienGiam
    {
        [Key]
        public int MaDK { get; set; }

        public int? MaChucVuDang { get; set; }

        public int? MaChucVuChinhQuyen { get; set; }

        public double? TyLe { get; set; }

        [StringLength(255)]
        public string NoiDung { get; set; }

        public virtual TBChucVuChinhQuyen TBChucVuChinhQuyen { get; set; }

        public virtual TBChucVuDang TBChucVuDang { get; set; }
    }
}
