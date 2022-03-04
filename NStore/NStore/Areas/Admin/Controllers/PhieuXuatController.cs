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
    public class PhieuXuatController : Controller
    {
        private NStoreEntities db = new NStoreEntities();

        // GET: Admin/PhieuXuat
        public ActionResult Index()
        {
            var phieuXuat = db.PhieuXuat.Include(p => p.NhanVien);
            return View(phieuXuat.ToList());
        }
        // GET: Admin/PhieuXuat/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietPhieuXuat phieuXuat = db.ChiTietPhieuXuat.Where(x => x.idPhieuXuat == id).FirstOrDefault();
            if (phieuXuat == null)
            {
                return HttpNotFound();
            }
            return View(phieuXuat);
        }

        // GET: Admin/PhieuXuat/Create
        public ActionResult Create()
        {
            ViewBag.idNhanVien = new SelectList(db.NhanVien, "id", "taiKhoan");
            return View();
        } 

        // POST: Admin/PhieuXuat/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,idNhanVien,ngayXuat")] PhieuXuat phieuXuat)
        {
            if (ModelState.IsValid)
            {
                int idsanpham = Convert.ToInt32(Request["sanpham"]);
                int soluongxuat = Convert.ToInt32(Request["soluong"]);

                var soluongton = db.SanPham.Where(x => x.id == idsanpham).FirstOrDefault().soLuongTon;
                if (soluongton > 0)
                {
                soluongton -= soluongxuat;
                db.SanPham.Where(x => x.id == idsanpham).FirstOrDefault().soLuongTon = soluongton;
                db.SaveChanges();
                db.PhieuXuat.Add(phieuXuat);
                db.SaveChanges();
                db.ChiTietPhieuXuat.Add(new ChiTietPhieuXuat() { idPhieuXuat = phieuXuat.id, idSanPham = idsanpham, soLuongXuat = soluongxuat});
                db.SaveChanges();
                    return RedirectToAction("Index");
                }
     
            }
            ViewBag.idNhanVien = new SelectList(db.NhanVien, "id", "taiKhoan", phieuXuat.idNhanVien);
            return View(phieuXuat);
        }

        // GET: Admin/PhieuXuat/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuXuat phieuXuat = db.PhieuXuat.Find(id);
            if (phieuXuat == null)
            {
                return HttpNotFound();
            }
            ViewBag.idNhanVien = new SelectList(db.NhanVien, "id", "taiKhoan", phieuXuat.idNhanVien);
            return View(phieuXuat);
        }

        // POST: Admin/PhieuXuat/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,idNhanVien,ngayXuat")] PhieuXuat phieuXuat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phieuXuat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idNhanVien = new SelectList(db.NhanVien, "id", "taiKhoan", phieuXuat.idNhanVien);
            return View(phieuXuat);
        }

        // GET: Admin/PhieuXuat/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuXuat phieuXuat = db.PhieuXuat.Find(id);
            if (phieuXuat == null)
            {
                return HttpNotFound();
            }
            return View(phieuXuat);
        }

        // POST: Admin/PhieuXuat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PhieuXuat phieuXuat = db.PhieuXuat.Find(id);
            db.PhieuXuat.Remove(phieuXuat);
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
