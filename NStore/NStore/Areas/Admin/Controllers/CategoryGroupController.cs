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
    public class CategoryGroupController : Controller
    {
        private NStoreEntities db = new NStoreEntities();

        // GET: Admin/CategoryGroup
        public ActionResult Index(string q)
        {
            if (q != null)
            {
                return View(db.NhomDanhMuc.Where(x =>
                                        x.tenNhomDanhMuc.Contains(q)
                                        ).ToList());
            }
            return View(db.NhomDanhMuc.ToList());
        }

        // GET: Admin/CategoryGroup/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhomDanhMuc nhomDanhMuc = db.NhomDanhMuc.Find(id);
            if (nhomDanhMuc == null)
            {
                return HttpNotFound();
            }
            return View(nhomDanhMuc);
        }

        // GET: Admin/CategoryGroup/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/CategoryGroup/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,tenNhomDanhMuc,img")] NhomDanhMuc nhomDanhMuc)
        {
            var f = Request.Files["img"];
            if (f != null && f.ContentLength > 0)
            {
                var path = Server.MapPath("~/assets/images/category/" + f.FileName);
                f.SaveAs(path);
                nhomDanhMuc.img = f.FileName;
            }
            else nhomDanhMuc.img = "default-image.jpg";

            if (ModelState.IsValid)
            {
                db.NhomDanhMuc.Add(nhomDanhMuc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nhomDanhMuc);
        }

        // GET: Admin/CategoryGroup/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhomDanhMuc nhomDanhMuc = db.NhomDanhMuc.Find(id);
            if (nhomDanhMuc == null)
            {
                return HttpNotFound();
            }
            return View(nhomDanhMuc);
        }

        // POST: Admin/CategoryGroup/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,tenNhomDanhMuc,img")] NhomDanhMuc nhomDanhMuc, string oldImageName)
        {
            var f = Request.Files["img"];
            if (f != null && f.ContentLength > 0)
            {
                var path = Server.MapPath("~/assets/images/category/" + f.FileName);
                f.SaveAs(path);
                nhomDanhMuc.img = f.FileName;
            }
            else nhomDanhMuc.img = oldImageName;

            if (ModelState.IsValid)
            {
                db.Entry(nhomDanhMuc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nhomDanhMuc);
        }

        // GET: Admin/CategoryGroup/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhomDanhMuc nhomDanhMuc = db.NhomDanhMuc.Find(id);
            if (nhomDanhMuc == null)
            {
                return HttpNotFound();
            }
            return View(nhomDanhMuc);
        }

        // POST: Admin/CategoryGroup/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NhomDanhMuc nhomDanhMuc = db.NhomDanhMuc.Find(id);
            db.NhomDanhMuc.Remove(nhomDanhMuc);
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
