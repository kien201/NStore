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
    public class NhomDanhMucController : Controller
    {
        private NStoreEntities db = new NStoreEntities();

        // GET: Admin/NhomDanhMuc
        public ActionResult Index()
        {
            return View(db.NhomDanhMuc.ToList());
        }

        // GET: Admin/NhomDanhMuc/Details/5
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

        // GET: Admin/NhomDanhMuc/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/NhomDanhMuc/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,tenNhomDanhMuc,img")] NhomDanhMuc nhomDanhMuc)
        {
            if (ModelState.IsValid)
            {
                db.NhomDanhMuc.Add(nhomDanhMuc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nhomDanhMuc);
        }

        // GET: Admin/NhomDanhMuc/Edit/5
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

        // POST: Admin/NhomDanhMuc/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,tenNhomDanhMuc,img")] NhomDanhMuc nhomDanhMuc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhomDanhMuc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nhomDanhMuc);
        }

        // GET: Admin/NhomDanhMuc/Delete/5
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

        // POST: Admin/NhomDanhMuc/Delete/5
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
