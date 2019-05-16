using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [DataType(DataType.Date)]
        public DateTime ThoiDiemNhan { get; set; }
    }
}