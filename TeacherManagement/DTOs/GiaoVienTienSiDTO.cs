using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeacherManagement.DTOs
{
    public class GiaoVienTienSiDTO
    {
        public int MaGV { get; set; }
        public string TenLuanAn { get; set; }
        public string NoiDaoTao { get; set; }
        public DateTime NamCapBang { get; set; }
    }
}