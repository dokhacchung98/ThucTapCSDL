using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeacherManagement.DTOs
{
    public class GiaoVienCongTacKhacDTO
    {
        public int Ma { get; set; }
        public int MaGV { get; set; }
        public string NoiDungCongTac { get; set; }
        public string VaiTro { get; set; }
        public string GhiChu { get; set; }
        public string NamHoc { get; set; }
    }
}