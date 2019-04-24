namespace TeacherManagement.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TBLopHuongDan")]
    public partial class TBLopHuongDan
    {
        public TBLopHuongDan()
        {
            TBHocVienHuongDans = new HashSet<TBHocVienHuongDan>();
        }

        [Key]
        public int MaLop { get; set; }
        
        public string TenLopHuongDan { get; set; }
        
        public virtual ICollection<TBHocVienHuongDan> TBHocVienHuongDans { get; set; }
    }
}