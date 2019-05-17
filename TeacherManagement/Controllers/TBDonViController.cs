using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeacherManagement.Repository;

namespace TeacherManagement.Controllers
{
    public class TBDonViController: Controller
    {
        private readonly TBDonViRepository _repository = new TBDonViRepository();

        public ActionResult Index()
        {
            var danhSachDonVi = _repository.DanhSachDonVi();
            return View(danhSachDonVi);
        }

        public ActionResult Detail(string id)
        {
            var donVi = _repository.DonViTheoMaDonVi(Convert.ToInt32(id));

            return View(donVi);
        }

        public PartialViewResult NhanSuHienTai(string id)
        {
            var danhSachGV = _repository.NhanSuCuaDonVi(Convert.ToInt32(id), false);
            return PartialView("_DanhSachGiaoVienHienNay", danhSachGV);
        }

        public PartialViewResult LichSuNhanSuDonVi(string id)
        {
            var danhsachgv = _repository.NhanSuCuaDonVi(Convert.ToInt32(id), true);
            return PartialView("_LichSuNhanSu", danhsachgv);
        }
    }
}