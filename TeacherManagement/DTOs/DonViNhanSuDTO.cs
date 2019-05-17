using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeacherManagement.DTOs
{
    public class DonViNhanSuDTO
    {
        public int MaGV { get; set; }
        public int MaDonVi { get; set; }
        public string TenGV { get; set; }
        public string ChucVu { get; set; }
        public string HocHam { get; set; }
        public string HocVi { get; set; }
        public DateTime ThoiGianNhan { get; set; }
        public DateTime ThoiGianKetThuc { get; set; }
    }
}