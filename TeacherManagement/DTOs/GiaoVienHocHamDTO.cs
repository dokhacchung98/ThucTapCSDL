using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeacherManagement.DTOs
{
    public class GiaoVienHocHamDTO
    {
        public int Ma { get; set; }
        public int MaGV { get; set; }
        public int MaHocHam { get; set; }
        public string TenHocHam { get; set; }
        public DateTime? ThoiDiemNhan { get; set; }
    }
}