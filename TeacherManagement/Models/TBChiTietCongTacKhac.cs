namespace TeacherManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBChiTietCongTacKhac")]
    public partial class TBChiTietCongTacKhac
    {
        [Key]
        public int Ma { get; set; }

        public int? MaGV { get; set; }

        public int? MaCongTac { get; set; }

        [StringLength(255)]
        public string VaiTro { get; set; }

        [StringLength(255)]
        public string GhiChu { get; set; }

        public virtual TBCongTacKhac TBCongTacKhac { get; set; }

        public virtual TBGiaoVien TBGiaoVien { get; set; }
    }
}
