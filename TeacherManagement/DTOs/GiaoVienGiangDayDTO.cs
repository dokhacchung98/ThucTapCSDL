using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeacherManagement.DTOs
{
    public class GiaoVienGiangDayDTO
    {
        public int MaGV { get; set; }
        public string TenLoaiDoiTuongDaoTao { get; set; }
        public string TenHeDaoTao { get; set; }
        public string TenHocPhan { get; set; }
        public string TenLoaiHocPhan { get; set; }
        public int SoTinChi { get; set; }
        public int TongTiet { get; set; }
        public int SiSo { get; set; }
        public int SoTietDay { get; set; }
        public double QuyRaGioChuan { get; set; }
        public string DonViTinh { get; set; }
        public string GhiChu { get; set; }
        public DateTime ThoiDiem { get; set; }
    }
}