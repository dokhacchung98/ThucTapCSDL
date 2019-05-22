using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeacherManagement.Helpers;
using TeacherManagement.Models;
using TeacherManagement.Repository;

namespace TeacherManagement.Controllers
{
    public class TBGiaoVienController : Controller
    {
        private readonly TBGiaoVienRepository _repository = new TBGiaoVienRepository();

        private readonly TBHocHamRepository tBHocHamRepository = new TBHocHamRepository();

        private readonly TBHocViRepository tBHocViRepository = new TBHocViRepository();

        private readonly TBDonViRepository tBDonViRepository = new TBDonViRepository();

        private readonly TBChucVuChuyenMonRepository tBChucVuChuyenMonRepository = new TBChucVuChuyenMonRepository();

        private readonly TBChucVuChinhQuyenRepository tBChucVuChinhQuyenRepository = new TBChucVuChinhQuyenRepository();

        private readonly DinhMucRepository _dinhMucRepository = new DinhMucRepository();
        
        // GET: TBChucVuDang
        public ActionResult Index()
        {
            var list = _repository.GetList();
            return View(list);
        }

        public ActionResult Detail(string id)
        {
            var giaoVien = _repository.LayGiaoVienTheoMaGV(Convert.ToInt32(id));

            return View(giaoVien);
        }

        public PartialViewResult ThongTinGiaoVien(string id)
        {
            var hocHamHienTai = _repository.HocHamGiaoVienHienTai(Convert.ToInt32(id));
            ViewBag.HocHamHienTai = hocHamHienTai;

            var hocViHienTai = _repository.HocViGiaoVienHienTai(Convert.ToInt32(id));
            ViewBag.HocViHienTai = hocViHienTai;

            var donViHienHienTai = _repository.DonViGiaoVienHienTai(Convert.ToInt32(id));
            ViewBag.DonViGiaoVienHienTai = donViHienHienTai;

            var chucVuChuyenMonHienTai = _repository.ChuyenMonGiaoVienHienTai(Convert.ToInt32(id));
            ViewBag.ChucVuChuyenMonHienTai = chucVuChuyenMonHienTai;

            var chucVuDangHienTai = _repository.ChucVuDangHienTai(Convert.ToInt32(id));
            ViewBag.ChucVuDang = chucVuDangHienTai;

            var chucVuCQHienTai = _repository.ChucVuChinhQuyenHienTai(Convert.ToInt32(id));
            ViewBag.ChucVuChinhQuyenHienTai = chucVuCQHienTai;

            var giaoVien = _repository.LayGiaoVienTheoMaGV(Convert.ToInt32(id));

            return PartialView("_ThongTinGiaoVien", giaoVien);
        }

        public PartialViewResult QuaTrinhHocTap(string id)
        {
            var daiHoc = _repository.LayThongTinDaiHoc(Convert.ToInt32(id));
            ViewBag.LayThongTinDaiHoc = daiHoc;

            var thacSi = _repository.LayThongTinThacSi(Convert.ToInt32(id));
            ViewBag.LayThongTinThacSi = thacSi;

            var tienSi = _repository.LayThongTinTienSi(Convert.ToInt32(id));
            ViewBag.LayThongTinTienSi = tienSi;

            var giaoVien = _repository.LayGiaoVienTheoMaGV(Convert.ToInt32(id));

            return PartialView("_QuaTrinhHocTap", giaoVien);
        }

        #region Tham gia hội đồng
        public PartialViewResult ThamGiaHoatDong(string id)
        {
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
            ViewBag.SelectListSchoolYear = select;
            var giaoVien = _repository.LayGiaoVienTheoMaGV(Convert.ToInt32(id));
            return PartialView("_ThamGiaHoatDong", giaoVien);
        }

        public ActionResult ThamGiaHoiDongRenderResult(string id, string NamHoc)
        {
            if (id == null || NamHoc == null) return null;
            var listThamGiaHoiDong = _repository.LayThongTinGiaovienThamGiaHoiDong(int.Parse(id), NamHoc);

            return PartialView("_ThamGiaHoatDongRenderResult", listThamGiaHoiDong);
        }
        #endregion

        #region Tham gia hướng dẫn
        public PartialViewResult ThamGiaHuongDan(string id)
        {
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
            ViewBag.SelectListSchoolYear = select;
            var giaoVien = _repository.LayGiaoVienTheoMaGV(Convert.ToInt32(id));
            return PartialView("_ThamGiaHuongDan", giaoVien);
        }

        public ActionResult ThamGiaHuongDanRenderResult(string id, string NamHoc)
        {
            if (id == null || NamHoc == null) return null;
            var listThamGiaHuongDan = _repository.LayThongTinHuongDanGiaoVien(int.Parse(id), NamHoc);

            return PartialView("_ThamGiaHuongDanRenderResult", listThamGiaHuongDan);
        }
        #endregion

        #region Tham gia công tác khác
        public PartialViewResult ThamGiaCongTacKhac(string id)
        {
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
            ViewBag.SelectListSchoolYear = select;
            var giaoVien = _repository.LayGiaoVienTheoMaGV(Convert.ToInt32(id));
            return PartialView("_ThamGiaCongTacKhac", giaoVien);
        }

        public ActionResult ThamGiaCongTacKhacRenderResult(string id, string NamHoc)
        {
            if (id == null || NamHoc == null) return null;
            var listCongTacKhac = _repository.LayThongTinCongTacKhacGiaoVien(int.Parse(id), NamHoc);

            return PartialView("_ThamGiaCongTacKhacResult", listCongTacKhac);
        }
        #endregion

        #region Tham gia giảng dạy
        public PartialViewResult ThamGiaGiangDay(string id)
        {
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
            ViewBag.SelectListSchoolYear = select;
            var giaoVien = _repository.LayGiaoVienTheoMaGV(Convert.ToInt32(id));
            return PartialView("_ThamGiaGiangDay", giaoVien);
        }

        public ActionResult ThamGiaGiangDayRenderResult(string id, string NamHoc)
        {
            if (id == null || NamHoc == null) return null;
            var listGiangDay = _repository.LayThongTinGiangDayGiaoVien(int.Parse(id), NamHoc);

            return PartialView("_ThamGiaGiangDayKhacResult", listGiangDay);
        }
        #endregion

        #region Thêm mới giáo viên
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult ThemThongTinGiaoVien()
        {
            var danhSachHocHam = tBHocHamRepository.DanhSachHocHam();
            ViewBag.DanhSachHocHam = new SelectList(danhSachHocHam, "MaHocHam", "TenHocHam");

            var danhSachHocVi = tBHocViRepository.DanhSachHocVi();
            ViewBag.DanhSachHocVi = new SelectList(danhSachHocVi, "MaHocVi", "TenHocVi");

            var danhSachDonVi = tBDonViRepository.DanhSachDonViHienNay();
            ViewBag.DanhSachDonVi = new SelectList(danhSachDonVi, "MaDonVi", "TenDonVi");

            var danhSachChucVuChuyenMon = tBChucVuChuyenMonRepository.DanhSachChucVuChuyenMon();
            ViewBag.DanhSachChucVuChuyenMon = new SelectList(danhSachChucVuChuyenMon, "MaChucVuCM", "TenChuVuCM");

            var danhSachChucVuChinhQuyen = tBChucVuChinhQuyenRepository.DanhSachChucVuChinhQuyen();
            ViewBag.DanhSachChucVuChinhQuyen = new SelectList(danhSachChucVuChinhQuyen, "MaChucVuChinhQuyen", "TenChucVuChinhQuyen");
            
            return PartialView("_ThemThongTinGiaoVien");
        }

        [HttpPost]
        public ActionResult ThemThongTinGiaoVien(TBGiaoVien giaoVien, string GioiTinh)
        {
            if (GioiTinh != null && GioiTinh.Equals("1"))
            {
                giaoVien.GioiTinh = true;
            }
            else
            {
                giaoVien.GioiTinh = false;
            }

            _repository.ThemGiaoVien(giaoVien);
            return RedirectToAction("Index");
        }

        public ActionResult Update(string id)
        {
            TBGiaoVien giaoVien = _repository.LayGiaoVienTheoMaGV(Convert.ToInt32(id));

            return View(giaoVien);
        }

        public ActionResult SuaThongTinGiaoVien(string id)
        {
            TBGiaoVien giaoVien = _repository.LayGiaoVienTheoMaGV(Convert.ToInt32(id));

            var danhSachHocHam = tBHocHamRepository.DanhSachHocHam();

            ViewBag.DanhSachHocHam = new SelectList(danhSachHocHam, "MaHocHam", "TenHocHam");

            var danhSachHocVi = tBHocViRepository.DanhSachHocVi();
            ViewBag.DanhSachHocVi = new SelectList(danhSachHocVi, "MaHocVi", "TenHocVi");

            var danhSachDonVi = tBDonViRepository.DanhSachDonViHienNay();
            ViewBag.DanhSachDonVi = new SelectList(danhSachDonVi, "MaDonVi", "TenDonVi");

            var danhSachChucVuChuyenMon = tBChucVuChuyenMonRepository.DanhSachChucVuChuyenMon();
            ViewBag.DanhSachChucVuChuyenMon = new SelectList(danhSachChucVuChuyenMon, "MaChucVuCM", "TenChuVuCM");

            var danhSachChucVuChinhQuyen = tBChucVuChinhQuyenRepository.DanhSachChucVuChinhQuyen();
            ViewBag.DanhSachChucVuChinhQuyen = new SelectList(danhSachChucVuChinhQuyen, "MaChucVuChinhQuyen", "TenChucVuChinhQuyen");

            return PartialView("_SuaThongTinGiaoVien", giaoVien);
        }

        [HttpPost]
        public ActionResult SuaThongTinGiaoVien(TBGiaoVien giaoVien, string GioiTinh,
            string MaHocHam, string MaHocVi, string MaDonVi, string MaChucVuChuyenMon, string MaChucVuChinhQuyen,
            DateTime? ThoiDiemNhanHocHam, DateTime? ThoiDiemNhanHocVi, DateTime? ThoiDiemNhanDonVi, DateTime? ThoiDiemKetThucDonVi, DateTime? ThoiDiemNhanCVCM
            )
        {
            if (GioiTinh != null && GioiTinh.Equals("1"))
            {
                giaoVien.GioiTinh = true;
            }
            else
            {
                giaoVien.GioiTinh = false;
            }

            _repository.SuaThongTinGiaoVien(giaoVien, MaHocHam, MaHocVi, MaDonVi, MaChucVuChuyenMon, MaChucVuChinhQuyen,
                ThoiDiemNhanHocHam, ThoiDiemNhanHocVi, ThoiDiemNhanDonVi, ThoiDiemKetThucDonVi, ThoiDiemNhanCVCM);
            return RedirectToAction("Index");
         }
        #region Công tác nghiên cứu khoa học
        public PartialViewResult CongTacNghienCuuKH(string id)
        {
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
            ViewBag.SelectListSchoolYear = select;
            var giaoVien = _repository.LayGiaoVienTheoMaGV(Convert.ToInt32(id));
            return PartialView("_CongTacNghienCuuKH", giaoVien);
        }

        public ActionResult CongTacNghienCuuKHRenderResult(string id, string NamHoc)
        {
            if (id == null || NamHoc == null) return null;
            var nghienCuuKhoaHoc = _repository.GiaoVienNghienCuuKhoaHoc(int.Parse(id), NamHoc);
            

            return PartialView("_CongTacNghienCuuKHResult", nghienCuuKhoaHoc);
        }
        #endregion
    }
}