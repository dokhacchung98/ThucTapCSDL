using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeacherManagement.DTOs
{
    public class ThemCongTacNCKHDTO
    {
        public int MaGV { get; set; }
        public string NamHoc { get; set; }

        public string TenSach { get; set; }
        public string TenBaiBao { get; set; }
        public string TenDeTai { get; set; }

        public List<KeyValuePair<int, string>> LoaiSach { get; set; }
        public List<KeyValuePair<int, string>> LoaiBao { get; set; }
        public List<KeyValuePair<int, string>> LoaiDeTai { get; set; }

        public List<KeyValuePair<int, string>> LoaiVaiTro { get; set; }

        public List<KeyValuePair<int, string>> LoaiHinh { get; set; }
    }
}