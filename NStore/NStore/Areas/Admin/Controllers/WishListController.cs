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
    public class WishListController : Controller
    {
        private NStoreEntities db = new NStoreEntities();

        // GET: Admin/WishList
        public ActionResult Index()
        {
            var sanPhamYeuThich = db.SanPhamYeuThich.Include(s => s.KhachHang).Include(s => s.SanPham);
            return View(sanPhamYeuThich.ToList());
        }

        // GET: Admin/WishList/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPhamYeuThich sanPhamYeuThich = db.SanPhamYeuThich.Find(id);
            if (sanPhamYeuThich == null)
            {
                return HttpNotFound();
            }
            return View(sanPhamYeuThich);
        }

        // GET: Admin/WishList/Create
        public ActionResult Create()
        {
            ViewBag.idKhachHang = new SelectList(db.KhachHang, "id", "taiKhoan");
            ViewBag.idSanPham = new SelectList(db.SanPham, "id", "tenSanPham");
            return View();
        }

        // POST: Admin/WishList/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,idKhachHang,idSanPham")] SanPhamYeuThich sanPhamYeuThich)
        {
            if (ModelState.IsValid)
            {
                db.SanPhamYeuThich.Add(sanPhamYeuThich);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idKhachHang = new SelectList(db.KhachHang, "id", "taiKhoan", sanPhamYeuThich.idKhachHang);
            ViewBag.idSanPham = new SelectList(db.SanPham, "id", "tenSanPham", sanPhamYeuThich.idSanPham);
            return View(sanPhamYeuThich);
        }

        // GET: Admin/WishList/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPhamYeuThich sanPhamYeuThich = db.SanPhamYeuThich.Find(id);
            if (sanPhamYeuThich == null)
            {
                return HttpNotFound();
            }
            ViewBag.idKhachHang = new SelectList(db.KhachHang, "id", "taiKhoan", sanPhamYeuThich.idKhachHang);
            ViewBag.idSanPham = new SelectList(db.SanPham, "id", "tenSanPham", sanPhamYeuThich.idSanPham);
            return View(sanPhamYeuThich);
        }

        // POST: Admin/WishList/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,idKhachHang,idSanPham")] SanPhamYeuThich sanPhamYeuThich)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanPhamYeuThich).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idKhachHang = new SelectList(db.KhachHang, "id", "taiKhoan", sanPhamYeuThich.idKhachHang);
            ViewBag.idSanPham = new SelectList(db.SanPham, "id", "tenSanPham", sanPhamYeuThich.idSanPham);
            return View(sanPhamYeuThich);
        }

        // GET: Admin/WishList/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPhamYeuThich sanPhamYeuThich = db.SanPhamYeuThich.Find(id);
            if (sanPhamYeuThich == null)
            {
                return HttpNotFound();
            }
            return View(sanPhamYeuThich);
        }

        // POST: Admin/WishList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SanPhamYeuThich sanPhamYeuThich = db.SanPhamYeuThich.Find(id);
            db.SanPhamYeuThich.Remove(sanPhamYeuThich);
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
