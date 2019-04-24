namespace TeacherManagement.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TBLoaiDinhMuc")]
    public partial class TBLoaiDinhMuc
    {
        public TBLoaiDinhMuc()
        {
            TBChiTietDinhMucNghienCuus = new HashSet<TBChiTietDinhMucNghienCuu>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaLoai { get; set; }

        public int? DinhMuc { get; set; }

        public string TenLoaiDinhMuc { get; set; }
        
        public virtual ICollection<TBChiTietDinhMucNghienCuu> TBChiTietDinhMucNghienCuus { get; set; }
    }
}