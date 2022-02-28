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
    public class SanPhamController : Controller
    {
        private NStoreEntities db = new NStoreEntities();

        // GET: Admin/SanPham
        public ActionResult Index()
        {
            var sanPham = db.SanPham.Include(s => s.DanhMuc);
            return View(sanPham.ToList());
        }

        // GET: Admin/SanPham/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPham.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // GET: Admin/SanPham/Create
        public ActionResult Create()
        {
            ViewBag.idDanhMuc = new SelectList(db.DanhMuc, "id", "tenDanhMuc");
            return View();
        }

        // POST: Admin/SanPham/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,tenSanPham,idDanhMuc,img,mota,kichThuoc,mauSac,chatLieu,xuatXu,donGia,giamGia,soLuongTon")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.SanPham.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idDanhMuc = new SelectList(db.DanhMuc, "id", "tenDanhMuc", sanPham.idDanhMuc);
            return View(sanPham);
        }

        // GET: Admin/SanPham/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPham.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            ViewBag.idDanhMuc = new SelectList(db.DanhMuc, "id", "tenDanhMuc", sanPham.idDanhMuc);
            return View(sanPham);
        }
        public ActionResult EditImg(int id)
        {
            int id_img = Convert.ToInt32(id);
            var result = db.SanPhamImage.Select(x=>new {x.id, x.img ,x.idSanPham}).Where(x=>x.idSanPham==id_img);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddImg(string imagePath,int id)
        {
            int id_img = Convert.ToInt32(id);
            SanPhamImage sp = new SanPhamImage() { idSanPham = id, img = imagePath };
            db.SanPhamImage.Add(sp);
            db.SaveChanges();
            return Json("Thêm thành công", JsonRequestBehavior.AllowGet);
        }
        public ActionResult DeleteImg(int id)
        {
            int id_ = Convert.ToInt32(id);
            var rm = db.SanPhamImage.Find(id_);
            db.SanPhamImage.Remove(rm);
            db.SaveChanges();
            return Json("Xóa thành công", JsonRequestBehavior.AllowGet);
        }
        // POST: Admin/SanPham/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,tenSanPham,idDanhMuc,img,mota,kichThuoc,mauSac,chatLieu,xuatXu,donGia,giamGia,soLuongTon")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idDanhMuc = new SelectList(db.DanhMuc, "id", "tenDanhMuc", sanPham.idDanhMuc);
            return View(sanPham);
        }

        // GET: Admin/SanPham/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPham.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // POST: Admin/SanPham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SanPham sanPham = db.SanPham.Find(id);
            db.SanPham.Remove(sanPham);
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
