using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NStore.Models.EF;

namespace NStore.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin, mod")]
    public class CategoryController : Controller
    {
        private NStoreEntities db = new NStoreEntities();

        // GET: Admin/Category
        public ActionResult Index(string q)
        {
            var danhMuc = db.DanhMuc.Include(d => d.NhomDanhMuc);
            if (q != null)
            {
                danhMuc = danhMuc.Where(x => x.tenDanhMuc.Contains(q) || x.NhomDanhMuc.tenNhomDanhMuc.Contains(q));
            }
            return View(danhMuc.OrderByDescending(x => x.id));
        }

        // GET: Admin/Category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhMuc danhMuc = db.DanhMuc.Find(id);
            if (danhMuc == null)
            {
                return HttpNotFound();
            }
            return View(danhMuc);
        }

        // GET: Admin/Category/Create
        public ActionResult Create()
        {
            ViewBag.idNhomDanhMuc = new SelectList(db.NhomDanhMuc, "id", "tenNhomDanhMuc");
            return View();
        }

        // POST: Admin/Category/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,idNhomDanhMuc,tenDanhMuc,img")] DanhMuc danhMuc)
        {
            var f = Request.Files["img"];
            if (f != null && f.ContentLength > 0)
            {
                var path = Server.MapPath("~/assets/images/category/" + f.FileName);
                f.SaveAs(path);
                danhMuc.img = f.FileName;
            }
            else danhMuc.img = "default-image.jpg";

            if (ModelState.IsValid)
            {
                db.DanhMuc.Add(danhMuc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idNhomDanhMuc = new SelectList(db.NhomDanhMuc, "id", "tenNhomDanhMuc", danhMuc.idNhomDanhMuc);
            return View(danhMuc);
        }

        // GET: Admin/Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhMuc danhMuc = db.DanhMuc.Find(id);
            if (danhMuc == null)
            {
                return HttpNotFound();
            }
            ViewBag.idNhomDanhMuc = new SelectList(db.NhomDanhMuc, "id", "tenNhomDanhMuc", danhMuc.idNhomDanhMuc);
            return View(danhMuc);
        }

        // POST: Admin/Category/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,idNhomDanhMuc,tenDanhMuc")] DanhMuc danhMuc, string oldImageName)
        {
            var f = Request.Files["img"];
            if (f != null && f.ContentLength > 0)
            {
                var path = Server.MapPath("~/assets/images/category/" + f.FileName);
                f.SaveAs(path);
                danhMuc.img = f.FileName;
            }
            else danhMuc.img = oldImageName;

            if (ModelState.IsValid)
            {
                db.Entry(danhMuc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idNhomDanhMuc = new SelectList(db.NhomDanhMuc, "id", "tenNhomDanhMuc", danhMuc.idNhomDanhMuc);
            return View(danhMuc);
        }

        // GET: Admin/Category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhMuc danhMuc = db.DanhMuc.Find(id);
            if (danhMuc == null)
            {
                return HttpNotFound();
            }
            return View(danhMuc);
        }

        // POST: Admin/Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DanhMuc danhMuc = db.DanhMuc.Find(id);
            db.DanhMuc.Remove(danhMuc);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
