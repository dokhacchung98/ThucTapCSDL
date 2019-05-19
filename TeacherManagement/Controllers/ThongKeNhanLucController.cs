using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeacherManagement.Repository;

namespace TeacherManagement.Controllers
{
    public class ThongKeNhanLucController : Controller
    {
        private readonly ThongKeNhanSuRepository _thongKeNhanSuRepository = new ThongKeNhanSuRepository();

        // GET: ThongKeNhanLuc
        public ActionResult Index()
        {
            var thongkes = _thongKeNhanSuRepository.ThongKeNhanLucHienTai();
            return View(thongkes);
        }
    }
}