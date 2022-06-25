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
    public class CustomerController : Controller
    {
        private NStoreEntities db = new NStoreEntities();

        // GET: Admin/Customer
        public ActionResult Index(string q)
        {
            var khachHang = db.KhachHang.Select(x => x);
            if(q != null)
            {
                khachHang = khachHang.Where(x => 
                                        x.hoTen.Contains(q) || 
                                        x.taiKhoan.Contains(q) ||
                                        x.email.Contains(q) || 
                                        x.soDienThoai.Contains(q) || 
                                        x.diaChi.Contains(q));
            }
            return View(khachHang.OrderByDescending(x => x.id));
        }

        // GET: Admin/Customer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = db.KhachHang.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return View(khachHang);
        }

        // GET: Admin/Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Customer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,taiKhoan,matKhau,hoTen,email,soDienThoai,diaChi,gioiTinh,ngaySinh")] KhachHang khachHang)
        {
            int count = db.KhachHang.Where(x => x.taiKhoan == khachHang.taiKhoan).Count();
            if(count > 0)
            {
                ModelState.AddModelError("", "Tài khoản đã có người đăng ký");
            }
            if (ModelState.IsValid)
            {
                khachHang.matKhau = Code.Md5hash.md5(khachHang.matKhau);
                db.KhachHang.Add(khachHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(khachHang);
        }

        // GET: Admin/Customer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = db.KhachHang.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return View(khachHang);
        }

        // POST: Admin/Customer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,taiKhoan,matKhau,hoTen,email,soDienThoai,diaChi,gioiTinh,ngaySinh")] KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(khachHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(khachHang);
        }

        // GET: Admin/Customer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = db.KhachHang.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return View(khachHang);
        }

        // POST: Admin/Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KhachHang khachHang = db.KhachHang.Find(id);
            db.KhachHang.Remove(khachHang);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Admin/Account/ResetPass/5
        public ActionResult ResetPass(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = db.KhachHang.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return View(khachHang);
        }

        // POST: Admin/Account/ResetPass/5
        [HttpPost, ActionName("ResetPass")]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassConfirmed(int id)
        {
            KhachHang khachHang = db.KhachHang.Find(id);
            khachHang.matKhau = Code.Md5hash.md5("123");
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
