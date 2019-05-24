using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeacherManagement.DTOs
{
    public class LopMonHocGiangDayDTO
    {
        public int MaLopMonHocGiangDay { get; set; }
        public string TenLopMonHocGiangDay { get; set; }
        public int MaHocPhan { get; set; }
        public int MaHeDaoTao { get; set; }
        public int SiSo { get; set; }
        public DateTime ThoiDiem { get; set; }
    }
}