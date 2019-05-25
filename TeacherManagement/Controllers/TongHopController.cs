using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeacherManagement.DTOs;
using TeacherManagement.Helpers;
using TeacherManagement.Repository;

namespace TeacherManagement.Controllers
{
    public class TongHopController : Controller
    {
        private readonly TBGiaoVienRepository _repository = new TBGiaoVienRepository();
        private readonly TBDonViRepository _donViRepository = new TBDonViRepository();
        private readonly TBGiaoVienRepository _giaoVienRepository = new TBGiaoVienRepository();
        public ActionResult Index()
        {
            var listDV = _donViRepository.DanhSachDonVi();
            var listSelect = new List<SelectListItem>();
            foreach (var item in listDV)
            {
                listSelect.Add(new SelectListItem()
                {
                    Text = item.TenDonVi,
                    Value = item.MaDonVi.ToString()
                });
            }
            var listSchoolYear = CreateSchoolYearExtention.CreateSchoolYear();
            IList<SelectListItem> select = new List<SelectListItem>();
            foreach (var item in listSchoolYear)
            {
                select.Add(new SelectListItem()
                {
                    Text = item,
                    Value = item
                });
            }
            ViewBag.Select = listSelect;
            ViewBag.SelectYear = select;
            return View();
        }

        public ActionResult GetList(string namHoc, int maDonVi)
        {
            var listNhanSu = _donViRepository.NhanSuCuaDonVi(maDonVi, false);
            var listGV = new List<GiaoVienDTO>();
            foreach (var item in listNhanSu)
            {
                var tmp = _giaoVienRepository.ThongTinCoBan(item.MaGV);
                listGV.Add(tmp);
            }
            var models = _repository.TongHopTaiTheoNamHoc(namHoc, listGV);
            double daoTaoYC = 0;
            double daoTaoTT = 0;
            double nckhTT = 0;
            double nckhYC = 0;

            foreach (var item in models)
            {
                if (item.TaiDaoTao != null)
                {
                    daoTaoTT += item.TaiDaoTao.SoTietThucTe;
                    daoTaoYC += item.TaiDaoTao.SoTietYeuCau;
                }
                if (item.TaiNCKH != null)
                {
                    nckhTT += item.TaiNCKH.SoTaiNCKHThucTe;
                    nckhYC += item.TaiNCKH.SoTaiYeuCau;
                }
            }

            double ptDT = 0;
            double ptNC = 0;
            if (daoTaoTT >= 0 && daoTaoYC > 0)
            {
                ptDT = (daoTaoTT * 100) / daoTaoYC;
            }
            if (nckhTT >= 0 && nckhYC > 0)
            {
                ptNC = (nckhTT * 100) / nckhYC;
            }

            ViewBag.DTTT = daoTaoTT;
            ViewBag.DTYC = daoTaoYC;
            ViewBag.NCKHTT = nckhTT;
            ViewBag.NCKHYC = nckhYC;
            ViewBag.PTDT = ptDT;
            ViewBag.PTNC = ptNC;

            return PartialView("_PartialTongHopView", models);
        }
    }
}