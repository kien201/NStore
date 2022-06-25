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
    [Authorize(Roles = "admin")]
    public class StaffController : Controller
    {
        private NStoreEntities db = new NStoreEntities();

        // GET: Admin/Staff
        public ActionResult Index(string q)
        {
            var nhanvien = db.NhanVien.Select(x => x);
            if (q != null)
            {
                nhanvien = nhanvien.Where(x =>
                                        x.hoTen.Contains(q) ||
                                        x.taiKhoan.Contains(q) ||
                                        x.CCCD.Contains(q) ||
                                        x.email.Contains(q) ||
                                        x.soDienThoai.Contains(q) ||
                                        x.diaChi.Contains(q));
            }
            return View(nhanvien.OrderByDescending(x => x.id));
        }

        // GET: Admin/Staff/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanVien.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        public List<SelectListItem> GetRoles()
        {
            var chucVu = new List<SelectListItem>();
            chucVu.Add(new SelectListItem() { Value = "1", Text = "Admin" });
            chucVu.Add(new SelectListItem() { Value = "2", Text = "Nhân viên" });
            return chucVu;
        }

        // GET: Admin/Staff/Create
        public ActionResult Create()
        {
            ViewBag.chucVu = new SelectList(GetRoles(), "Value", "Text");
            return View();
        }

        // POST: Admin/Staff/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,taiKhoan,matKhau,hoTen,CCCD,email,soDienThoai,ngaySinh,gioiTinh,diaChi,chucVu")] NhanVien nhanVien)
        {
            int count = db.NhanVien.Where(x => x.taiKhoan == nhanVien.taiKhoan).Count();
            if (count > 0)
            {
                ModelState.AddModelError("", "Tài khoản đã tồn tại");
            }
            if (ModelState.IsValid)
            {
                nhanVien.matKhau = Code.Md5hash.md5(nhanVien.matKhau);
                db.NhanVien.Add(nhanVien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.chucVu = new SelectList(GetRoles(), "Value", "Text", nhanVien.chucVu);
            return View(nhanVien);
        }

        // GET: Admin/Staff/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanVien.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            ViewBag.chucVu = new SelectList(GetRoles(), "Value", "Text", nhanVien.chucVu);
            return View(nhanVien);
        }

        // POST: Admin/Staff/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,taiKhoan,matKhau,hoTen,CCCD,email,soDienThoai,ngaySinh,gioiTinh,diaChi,chucVu")] NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhanVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.chucVu = new SelectList(GetRoles(), "Value", "Text", nhanVien.chucVu);
            return View(nhanVien);
        }

        // GET: Admin/Staff/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanVien.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        // POST: Admin/Staff/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NhanVien nhanVien = db.NhanVien.Find(id);
            db.NhanVien.Remove(nhanVien);
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
            NhanVien nhanVien = db.NhanVien.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        // POST: Admin/Account/ResetPass/5
        [HttpPost, ActionName("ResetPass")]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassConfirmed(int id)
        {
            NhanVien nhanVien = db.NhanVien.Find(id);
            nhanVien.matKhau = Code.Md5hash.md5("123");
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
