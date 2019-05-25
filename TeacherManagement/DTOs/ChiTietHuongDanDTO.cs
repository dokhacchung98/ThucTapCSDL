using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeacherManagement.DTOs
{
    public class ChiTietHuongDanDTO
    {
        public int MaGV { get; set; }
        public int MaHocVien { get; set; }
        public string TenDeTai { get; set; }
        public float SoGio { get; set; }
        public string NamHoc { get; set; }
    }
}