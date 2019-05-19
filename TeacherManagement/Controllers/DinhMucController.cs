using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeacherManagement.DTOs;
using TeacherManagement.Repository;

namespace TeacherManagement.Controllers
{
    public class DinhMucController : Controller
    {
        private readonly DinhMucRepository _dinhMucRepository = new DinhMucRepository();

        // GET: DinhMuc/DinhMucGiangDay
        public ActionResult DinhMucGiangDay()
        {
            DateTime date = DateTime.Parse("2018-05-19");
            List<DinhMucGiangDayDTO> dinhMucGiangDays = _dinhMucRepository
                .DanhSachDinhMucGiangDay(date);

            return View("DinhMucGiangDay", dinhMucGiangDays);
        }

        public ActionResult DinhMucKhoaHoc()
        {
            DateTime date = DateTime.Parse("2018-05-19");
            List<DinhMucNghienCuuKHDTO> dinhMucNghienCuus = _dinhMucRepository
                .DanhSachDinhMucNghienCuuKH(date);
            return View("DinhMucNghienCuuKhoaHoc", dinhMucNghienCuus);
        }

        public ActionResult DinhMucMienGiam()
        {
            return View();
        }
    }
}