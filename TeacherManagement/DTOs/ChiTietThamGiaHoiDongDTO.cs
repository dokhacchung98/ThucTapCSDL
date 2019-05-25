using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeacherManagement.DTOs
{
    public class ChiTietThamGiaHoiDongDTO
    {
        public int MaGV { get; set; }
        public int MaHoiDong { get; set; }
        public string GhiChu { get; set; }
        public int SoLanThamGia { get; set; }
        public float SoGio { get; set; }
        public string NamHoc { get; set; }
    }
}