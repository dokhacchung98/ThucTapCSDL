using System;

namespace TeacherManagement.DTOs
{
    public class GiaoVienHocViDTO
    {
        public int Ma { get; set; }
        public int MaGV { get; set; }
        public int MaHocVi { get; set; }
        public DateTime? ThoiDiemNhan { get; set; }
        public string TenHocVi { get; set; }
    }
}