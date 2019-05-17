using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeacherManagement.DTOs
{
    public class GiaoVienDaiHocDTO
    {
        public int MaGV { get; set; }
        public DateTime NamTotNghiep { get; set; }
        public string HeDaoTao { get; set; }
        public string NoiDaoTao { get; set; }
        public string NganhHoc { get; set; }
        public string NuocDaoTao { get; set; }
    }
}