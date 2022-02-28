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
    public class SanPhamImageController : Controller
    {
        private NStoreEntities db = new NStoreEntities();

        // GET: Admin/SanPhamImage
        public ActionResult Index()
        {
            var sanPhamImage = db.SanPhamImage.Include(s => s.SanPham);
            return View(sanPhamImage.ToList());
        }

        // GET: Admin/SanPhamImage/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPhamImage sanPhamImage = db.SanPhamImage.Find(id);
            if (sanPhamImage == null)
            {
                return HttpNotFound();
            }
            return View(sanPhamImage);
        }

        // GET: Admin/SanPhamImage/Create
        public ActionResult Create()
        {
            ViewBag.idSanPham = new SelectList(db.SanPham, "id", "tenSanPham");
            return View();
        }

        // POST: Admin/SanPhamImage/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,idSanPham,img")] SanPhamImage sanPhamImage)
        {
            if (ModelState.IsValid)
            {
                db.SanPhamImage.Add(sanPhamImage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idSanPham = new SelectList(db.SanPham, "id", "tenSanPham", sanPhamImage.idSanPham);
            return View(sanPhamImage);
        }

        // GET: Admin/SanPhamImage/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPhamImage sanPhamImage = db.SanPhamImage.Find(id);
            if (sanPhamImage == null)
            {
                return HttpNotFound();
            }
            ViewBag.idSanPham = new SelectList(db.SanPham, "id", "tenSanPham", sanPhamImage.idSanPham);
            return View(sanPhamImage);
        }

        // POST: Admin/SanPhamImage/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,idSanPham,img")] SanPhamImage sanPhamImage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanPhamImage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idSanPham = new SelectList(db.SanPham, "id", "tenSanPham", sanPhamImage.idSanPham);
            return View(sanPhamImage);
        }

        // GET: Admin/SanPhamImage/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPhamImage sanPhamImage = db.SanPhamImage.Find(id);
            if (sanPhamImage == null)
            {
                return HttpNotFound();
            }
            return View(sanPhamImage);
        }

        // POST: Admin/SanPhamImage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SanPhamImage sanPhamImage = db.SanPhamImage.Find(id);
            db.SanPhamImage.Remove(sanPhamImage);
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
