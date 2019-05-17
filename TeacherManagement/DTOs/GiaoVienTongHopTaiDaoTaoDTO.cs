using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeacherManagement.DTOs
{
    public class GiaoVienTongHopTaiDaoTaoDTO : AbsGiaoVienTongHopTaiDaoTaoDTO
    {
        public GiaoVienTongHopTaiDaoTaoDTO()
        {
        }

        public GiaoVienTongHopTaiDaoTaoDTO(int maGV, string tenGV, int soTietThucTe, int soTietYeuCau) : base(maGV, tenGV, soTietThucTe, soTietYeuCau)
        {
        }

        public override double TinhPhanTram()
        {
            if (SoTietThucTe >= 0 && SoTietYeuCau > 0)
            {
                return (SoTietThucTe * 100) / SoTietYeuCau;
            }
            return 0.0;
        }
    }
}