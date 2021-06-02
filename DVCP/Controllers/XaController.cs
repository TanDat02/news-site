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
    public class XaController : Controller
    {
        DVCPcontext db = new DVCPcontext();
        // GET: Tinh
        public ActionResult Index(string sortorder, string currentfilter, string searchstring, int? page, int? pagesize, int? xaId)
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

            var list = from p in db.Xas
                       select p;

            if (!String.IsNullOrEmpty(searchstring))
            {
                list = list.Where(s => s.tenXa.Contains(searchstring));
            }

            if (xaId != null && xaId > 0)
            {
                list = list.Where(s => s.xaId == xaId);
                ViewBag.xa = new SelectList(db.Xas, "xaId", "tenXa", xaId);
                ViewBag.xaId = xaId;
            }
            else
            {
                ViewBag.Xa = new SelectList(db.Xas, "xaId", "tenXa");
                ViewBag.xaId = 0;
            }

            list = list.OrderBy(s => s.xaId);
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
            var databyid = db.Xas.Single(x => x.xaId == id);
            return View(databyid);
        }


        // GET: Tinh/Create
        public ActionResult Create()
        {
            ViewBag.xaId = new SelectList(db.Xas, "maXa", "tenXa");
            return View();
        }

        // POST: Nguoi1/Create
        [HttpPost]
        public ActionResult Create(Xa collection)
        {
            try
            {
                db.Xas.Add(collection);
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
            var databyid = db.Xas.Single(x => x.xaId == id);
            if (databyid == null) return HttpNotFound();
            /*-------------------------------------------------------------------*/
            ViewBag.XaId = new SelectList(db.Huyens, "xaId", "tenXa", databyid.xaId);
            return View(databyid);
        }

        // POST: Nguoi1/Edit/5
        [HttpPost]
        public ActionResult Edit(Xa collection)
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
            var databyid = db.Xas.Single(x => x.xaId == id);
            return View(databyid);
        }

        // POST: Nguoi1/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Tinh collection)
        {
            try
            {
                var data = db.Xas.Single(x => x.xaId == id);
                db.Xas.Remove(data);
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
