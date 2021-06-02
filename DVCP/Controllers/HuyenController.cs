using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DVCP.Context;
using DVCP.Models;
using PagedList;

namespace DVCP.Controllers
{
    public class HuyenController : Controller
    {
        DVCPcontext db = new DVCPcontext();
        // GET: Tinh
        public ActionResult Index(string sortorder, string currentfilter, string searchstring, int? page, int? pagesize, int? huyenId)
        {
            if (searchstring != null)
            {
                page = 1;
            }
            else
            {
                searchstring = currentfilter;
            }
            ViewBag.CurrentFilter = searchstring;

            var list = from p in db.Huyens
                       select p;

            if (!String.IsNullOrEmpty(searchstring))
            {
                list = list.Where(s => s.tenHuyen.Contains(searchstring));
            }

            if (huyenId != null && huyenId > 0)
            {
                list = list.Where(s => s.huyenId == huyenId);
                ViewBag.huyen = new SelectList(db.Huyens, "huyenId", "tenHuyen", huyenId);
                ViewBag.huyenId = huyenId;
            }
            else
            {
                ViewBag.Huyen = new SelectList(db.Huyens, "huyenId", "tenHuyen");
                ViewBag.huyenId = 0;
            }

            list = list.OrderBy(s => s.huyenId);
            ViewBag.RowsCount = list.Count();

            int? pageSize = 10;
            int pageNumber = (page ?? 1);
            if (pagesize != null) { pageSize = pagesize; }
            ViewBag.PageSize = pageSize;
            return View(list.ToPagedList(pageNumber, (int)pageSize));
        }


        // GET: Tinh/Details/5
        public ActionResult Details(int id)
        {
            var databyid = db.Huyens.Single(x => x.huyenId == id);
            return View(databyid);
        }


        // GET: Tinh/Create
        public ActionResult Create()
        {
            ViewBag.HuyenId = new SelectList(db.Huyens, "maHuyen", "tenHuyen");
            return View();
        }

        // POST: Nguoi1/Create
        [HttpPost]
        public ActionResult Create(Huyen collection)
        {
            try
            {
                db.Huyens.Add(collection);
                db.SaveChanges();
                return Json(new { success = true, message = "Thêm thành công." }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }



        // GET: Tinh/Edit/5
        public ActionResult Edit(int id)
        {
            var databyid = db.Huyens.Single(x => x.huyenId == id);
            if (databyid == null) return HttpNotFound();
            /*-------------------------------------------------------------------*/
            ViewBag.HuyenId = new SelectList(db.Huyens, "huyenId", "tenHuyen", databyid.huyenId);
            return View(databyid);
        }

        // POST: Nguoi1/Edit/5
        [HttpPost]
        public ActionResult Edit(Huyen collection)
        {
            try
            {
                db.Entry(collection).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true, message = "Cập nhật thành công." }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }



        // GET: Tinh/Delete/5
        public ActionResult Delete(int id)
        {
            var databyid = db.Huyens.Single(x => x.huyenId == id);
            return View(databyid);
        }

        // POST: Nguoi1/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Tinh collection)
        {
            try
            {
                var data = db.Huyens.Single(x => x.huyenId == id);
                db.Huyens.Remove(data);
                db.SaveChanges();
                return Json(new { success = true, message = "Xóa thành công." }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }


    }
}
