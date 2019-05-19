using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeacherManagement.DTOs
{
    public class GiaoVienHuongDanDTO
    {
        public int MaGV { get; set; }
        public string TenHocVien { get; set; }
        public string TenLopHuongDan { get; set; }
        public string TenDeTai { get; set; }
        public string TenLoaiHuongDan { get; set; }
        public string TenHeDaoTao { get; set; }
    }
}