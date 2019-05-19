using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeacherManagement.DTOs
{
    public class GiaoVienVietSachDTO
    {
        public int MaGV { get; set; }
        public string TenSach { get; set; }
        public string LoaiSach { get; set; }
        public string VaiTro { get; set; }
        public string LoaiHinh { get; set; }
        public string NamHoc { get; set; }
        public int SoTacGia { get; set; }
        public double GioChuan { get; set; }
    }
}