using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeacherManagement.DTOs
{
    public class ChiTietGiangDayDTO
    {
        public int MaGV { get; set; }
        public int MaLop { get; set; }
        public int SoTiet { get; set; }
        public int MaLoaiGiangDay { get; set; }
        public string NamHoc { get; set; }
    }
}