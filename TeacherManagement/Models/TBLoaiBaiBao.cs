namespace TeacherManagement.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TBLoaiBaiBao")]
    public partial class TBLoaiBaiBao
    {
        public TBLoaiBaiBao()
        {
            TBBaiBaos = new HashSet<TBBaiBao>();
        }

        [Key]
        public int MaLoaiBaiBao { get; set; }
        
        public string TenLoaiBao { get; set; }

        public double? QuyRaGioChuan { get; set; }
        
        public string DonVitinh { get; set; }
        
        public string GhiChu { get; set; }
        
        public virtual ICollection<TBBaiBao> TBBaiBaos { get; set; }
    }
}