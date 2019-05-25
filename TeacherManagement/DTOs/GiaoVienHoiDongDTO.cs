using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeacherManagement.DTOs
{
    public class GiaoVienHoiDongDTO
    {
        public int Ma { get; set; }
        public int MaGV { get; set; }
        public string TenHoiDong { get; set; }
        public string TenLoaiHoiDong { get; set; }
        public int SoLanThamGia { get; set; }
        public double SoGioThamGia { get; set; }
        public string GhiChu { get; set; }
        public string NamHoc { get; set; }
    }
}