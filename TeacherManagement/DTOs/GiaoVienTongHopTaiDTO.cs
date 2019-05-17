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
        public double TinhTongTaiPhanTram()
        {
            return 0;
        }
        
    }
}