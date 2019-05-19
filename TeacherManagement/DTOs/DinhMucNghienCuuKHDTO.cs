using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeacherManagement.DTOs
{
    public class DinhMucNghienCuuKHDTO
    {
        public int MaGV { get; set; }
        public string TenGV { get; set; }
        public string TenChucVuChuyenMon { get; set; }
        public string TenHocHam { get; set; }
        public int DinhMucThoiGian { get; set; }
        public int DinhMucGioChuan { get; set; }
        public string GhiChu { get; set; }
    }
}