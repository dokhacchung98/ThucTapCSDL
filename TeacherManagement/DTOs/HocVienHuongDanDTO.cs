using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeacherManagement.DTOs
{
    public class HocVienHuongDanDTO
    {
        public int MaHocVien { get; set; }
        public string TenHocVien { get; set; }
        public int MaLopHuongDan { get; set; }
        public int MaLoaiHuongDan { get; set; }
    }
}