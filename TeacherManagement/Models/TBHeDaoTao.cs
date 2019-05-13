namespace TeacherManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBHeDaoTao")]
    public partial class TBHeDaoTao
    {
        [Key]
        public int MaHeDaoTao { get; set; }

        [StringLength(255)]
        public string TenHeDaoTao { get; set; }

        public int? MaLoaiDoiTuongDaoTao { get; set; }

        public virtual TBLoaiDoiTuongDaoTao TBLoaiDoiTuongDaoTao { get; set; }
    }
}
