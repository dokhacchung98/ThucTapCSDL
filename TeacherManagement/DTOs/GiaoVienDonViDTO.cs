using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeacherManagement.DTOs
{
    public class GiaoVienDonViDTO
    {
        public int Ma { get; set; }
        public int MaGV { get; set; }
        public int MaDonVi { get; set; }
        public string TenDonVi { get; set; }
        public DateTime? ThoiDiemNhan { get; set; }
        public DateTime? ThoiDiemKetThuc { get; set; }
    }
}