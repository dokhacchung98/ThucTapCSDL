using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeacherManagement.DTOs
{
    public class DinhMucGiangDayDTO
    {
        public int MaGV { get; set; }
        public string TenGV { get; set; }
        public string TenChucVuChuyenMon { get; set; }
        public string TenHocHam { get; set; }
        public string TenLoaiMon { get; set; }
        public int DinhMuc { get; set; }
        public string GhiChu { get; set; }
    }
}