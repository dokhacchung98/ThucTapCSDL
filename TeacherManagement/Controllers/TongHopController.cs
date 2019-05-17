using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeacherManagement.Repository;

namespace TeacherManagement.Controllers
{
    public class TongHopController : Controller
    {
        private readonly TBGiaoVienRepository _repository = new TBGiaoVienRepository();
        public ActionResult Index()
        {
            var models = _repository.TongHopTaiTheoNamHoc("2019-2020");
            return View(models);
        }
    }
}