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
    public class PhieuNhapController : Controller
    {
        private NStoreEntities db = new NStoreEntities();

        // GET: Admin/PhieuNhap
        public ActionResult Index()
        {
            var phieuNhap = db.PhieuNhap.Include(p => p.NhaCungCap).Include(p => p.NhanVien);
            return View(phieuNhap.ToList());
        }

        // GET: Admin/PhieuNhap/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietPhieuNhap phieuNhap = db.ChiTietPhieuNhap.Where(x=>x.idPhieuNhap==id).FirstOrDefault();
            if (phieuNhap == null)
            {
                return HttpNotFound();
            }
            return View(phieuNhap);
        }


        public ActionResult ViewSanPham()
        {
            var data = db.SanPham.Select(x=>new { x.tenSanPham,x.id, x.soLuongTon }).ToList();
            return Json(data,JsonRequestBehavior.AllowGet);
        }
        // GET: Admin/PhieuNhap/Create
        public ActionResult Create()
        {
            ViewBag.idNhaCungCap = new SelectList(db.NhaCungCap, "id", "tenNhaCungCap");
            ViewBag.idNhanVien = new SelectList(db.NhanVien, "id", "taiKhoan");
            return View();
        }

        // POST: Admin/PhieuNhap/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,idNhanVien,idNhaCungCap,ngayNhap")] PhieuNhap phieuNhap)
        {
            if (ModelState.IsValid)
            {
                int idsanpham=Convert.ToInt32(Request["sanpham"]);
                int soluongnhap = Convert.ToInt32(Request["soluong"]);
                int dongianhap = Convert.ToInt32(Request["dongianhap"]);

                var soluongton=db.SanPham.Where(x => x.id == idsanpham).FirstOrDefault().soLuongTon;
                soluongton += soluongnhap;

                db.SanPham.Where(x => x.id == idsanpham).FirstOrDefault().soLuongTon = soluongton;
                db.SaveChanges();

                db.PhieuNhap.Add(phieuNhap);
                db.SaveChanges();

                db.ChiTietPhieuNhap.Add(new ChiTietPhieuNhap() { idPhieuNhap = phieuNhap.id,idSanPham=idsanpham,soLuongNhap= soluongnhap,donGiaNhap= dongianhap });
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idNhaCungCap = new SelectList(db.NhaCungCap, "id", "tenNhaCungCap", phieuNhap.idNhaCungCap);
            ViewBag.idNhanVien = new SelectList(db.NhanVien, "id", "taiKhoan", phieuNhap.idNhanVien);
            return View(phieuNhap);
        }

        // GET: Admin/PhieuNhap/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuNhap phieuNhap = db.PhieuNhap.Find(id);
            if (phieuNhap == null)
            {
                return HttpNotFound();
            }
            ViewBag.idNhaCungCap = new SelectList(db.NhaCungCap, "id", "tenNhaCungCap", phieuNhap.idNhaCungCap);
            ViewBag.idNhanVien = new SelectList(db.NhanVien, "id", "taiKhoan", phieuNhap.idNhanVien);
            return View(phieuNhap);
        }

        // POST: Admin/PhieuNhap/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,idNhanVien,idNhaCungCap,ngayNhap")] PhieuNhap phieuNhap)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phieuNhap).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idNhaCungCap = new SelectList(db.NhaCungCap, "id", "tenNhaCungCap", phieuNhap.idNhaCungCap);
            ViewBag.idNhanVien = new SelectList(db.NhanVien, "id", "taiKhoan", phieuNhap.idNhanVien);
            return View(phieuNhap);
        }

        // GET: Admin/PhieuNhap/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuNhap phieuNhap = db.PhieuNhap.Find(id);
            if (phieuNhap == null)
            {
                return HttpNotFound();
            }
            return View(phieuNhap);
        }

        // POST: Admin/PhieuNhap/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PhieuNhap phieuNhap = db.PhieuNhap.Find(id);
            db.PhieuNhap.Remove(phieuNhap);
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
