using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeacherManagement.DTOs
{
    public class GiaoVienVietBaoDTO
    {
        public int MaGV { get; set; }
        public string TenBaiBao { get; set; }
        public int SoBaiBao { get; set; }
        public string LoaiBaiBao { get; set; }
        public string VaiTro { get; set; }
        public string LoaiHinh { get; set; }
        public string NoiXuatBan { get; set; }
        public string NamHoc { get; set; }
        public int SoTacGia { get; set; }
        public string SoISBN { get; set; }
        public DateTime NgayXuatBan { get; set; }
        public double GioChuan { get; set; }
    }
}