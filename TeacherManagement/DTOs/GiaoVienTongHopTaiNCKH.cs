using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeacherManagement.DTOs
{
    public class GiaoVienTongHopTaiNCKH
    {
        public int MaGV { get; set; }
        public string TenGV { get; set; }
        public double SoTaiNCKHThucTe { get; set; }
        public double SoTaiNCKHYeuCau { get; set; }
        public double TinhPhanTram()
        {
            if (SoTaiNCKHThucTe >= 0 && SoTaiNCKHYeuCau > 0)
            {
                return (SoTaiNCKHThucTe * 100) / SoTaiNCKHYeuCau;
            }
            return 0.0;
        }
    }
}