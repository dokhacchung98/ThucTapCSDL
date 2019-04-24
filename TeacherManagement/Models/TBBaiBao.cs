namespace TeacherManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TBBaiBao")]
    public partial class TBBaiBao
    {
        public TBBaiBao()
        {
            TBVietBaiBaoKhoaHocs = new HashSet<TBVietBaiBaoKhoaHoc>();
        }

        [Key]
        public int MaBaiBao { get; set; }

        public string TenBaiBao { get; set; }
        
        public string SoISBN { get; set; }

        public string NoiXuatBan { get; set; }

        public int? MaLoaiBaiBao { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayXuatBan { get; set; }

        public virtual TBLoaiBaiBao TBLoaiBaiBao { get; set; }

        public virtual ICollection<TBVietBaiBaoKhoaHoc> TBVietBaiBaoKhoaHocs { get; set; }
    }
}