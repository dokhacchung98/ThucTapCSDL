using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeacherManagement.DTOs
{
    public class GiaoVienNghienCuuKhoaHocDTO
    {
        public List<GiaoVienVietSachDTO> GiaoVienVietSach { get; set; }
        public List<GiaoVienVietBaoDTO> GiaoVienVietBao { get; set; }
        public List<GiaoVienDeTaiKHDTO> GiaoVienDeTaiKH { get; set; }
    }
}