using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeacherManagement.DTOs
{
    public class GiaoVienChuyenMonDTO
    {
        public int Ma { get; set; }
        public int MaGV { get; set; }
        public int MaChucVuCM { get; set; }
        public string TenChucVuCM { get; set; }
        public DateTime? ThoiDiemNhan { get; set; }
    }
}