namespace TeacherManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBVietBaiBaoKhoaHoc")]
    public partial class TBVietBaiBaoKhoaHoc
    {
        [Key]
        public int Ma { get; set; }

        public int? MaBaiBao { get; set; }

        public int? MaGV { get; set; }

        [StringLength(1)]
        public string SoBaiBao { get; set; }

        public int? MaVaiTro { get; set; }

        public int? MaLoaiHinhThucNghienCuu { get; set; }

        [StringLength(10)]
        public string NamHoc { get; set; }

        public virtual TBBaiBao TBBaiBao { get; set; }

        public virtual TBGiaoVien TBGiaoVien { get; set; }

        public virtual TBLoaiHinhNghienCuu TBLoaiHinhNghienCuu { get; set; }

        public virtual TBVaiTroNghienCuuKhoaHoc TBVaiTroNghienCuuKhoaHoc { get; set; }
    }
}
