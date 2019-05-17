using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeacherManagement.DTOs
{
    public class GiaoVienThacSiDTO
    {
        public int MaGV { get; set; }
        public string TenLuanVan { get; set; }
        public string ThacSyChuyenNganh { get; set; }
        public string NoiDaoTao { get; set; }
        public DateTime NamCapBang { get; set; }
    }
}