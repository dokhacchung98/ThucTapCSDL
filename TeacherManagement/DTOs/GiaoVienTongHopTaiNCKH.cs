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
        public double SoTaiYeuCau { get; set; }
        public double TinhPhanTram()
        {
            if (SoTaiNCKHThucTe >= 0 && SoTaiYeuCau > 0)
            {
                return (SoTaiNCKHThucTe * 100) / SoTaiYeuCau;
            }
            return 0.0;
        }
    }
}