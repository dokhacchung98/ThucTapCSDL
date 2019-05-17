using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeacherManagement.DTOs
{
    public abstract class AbsGiaoVienTongHopTaiDaoTaoDTO
    {
        protected AbsGiaoVienTongHopTaiDaoTaoDTO()
        {

        }
        protected AbsGiaoVienTongHopTaiDaoTaoDTO(int maGV, string tenGV, double soTietThucTe, double soTietYeuCau)
        {
            MaGV = maGV;
            TenGV = tenGV;
            SoTietThucTe = soTietThucTe;
            SoTietYeuCau = soTietYeuCau;
        }

        public int MaGV { get; set; }
        public string TenGV { get; set; }
        public double SoTietThucTe { get; set; }
        public double SoTietYeuCau { get; set; }
        public abstract double TinhPhanTram();
    }
}