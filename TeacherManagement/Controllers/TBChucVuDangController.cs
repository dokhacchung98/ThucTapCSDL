using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeacherManagement.Repository;

namespace TeacherManagement.Controllers
{
    public class TBChucVuDangController : Controller
    {
        private readonly TBChucVuDangRepository _repository = new TBChucVuDangRepository();
        // GET: TBChucVuDang
        public ActionResult Index()
        {
            ModelState.Clear();
            var list = _repository.GetList();
            return View(list);
        }

        // GET: TBChucVuDang/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TBChucVuDang/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TBChucVuDang/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TBChucVuDang/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TBChucVuDang/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TBChucVuDang/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TBChucVuDang/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
