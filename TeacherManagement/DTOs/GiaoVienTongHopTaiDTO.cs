using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeacherManagement.DTOs
{
    public class GiaoVienTongHopTaiDTO
    {
        public GiaoVienDTO GiaoVien { get; set; }
        public AbsGiaoVienTongHopTaiDaoTaoDTO TaiDaoTao { get; set; }
        public GiaoVienTongHopTaiNCKH TaiNCKH { get; set; }
        public double TinhTongTaiPhanTram()
        {
            if ((TaiDaoTao.SoTietThucTe + TaiNCKH.SoTaiNCKHThucTe) >= 0 && (TaiDaoTao.SoTietYeuCau + TaiNCKH.SoTaiYeuCau) > 0)
            {
                return ((TaiDaoTao.SoTietThucTe + TaiNCKH.SoTaiNCKHThucTe) * 100) / (TaiDaoTao.SoTietYeuCau + TaiNCKH.SoTaiYeuCau);
            }
            return 0.0;
        }
        
    }
}