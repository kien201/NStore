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
    [Authorize(Roles = "admin,mod")]
    public class OrderController : Controller
    {
        private NStoreEntities db = new NStoreEntities();

        // GET: Admin/Order
        public ActionResult Index(string q)
        {
            ViewBag.q = q;
            return View();
        }

        public ActionResult RenderTableOrder(string q, int? orderState)
        {
            var donHang = db.DonHang.Include(d => d.KhachHang);
            if (orderState != null)
            {
                donHang = donHang.Where(x => x.trangThaiDonHang == orderState);
            }
            if (q != null)
            {
                donHang = donHang.Where(x => x.KhachHang.hoTen.Contains(q) ||
                                             x.KhachHang.soDienThoai.Contains(q) ||
                                             x.ngayDatHang.Value.ToString().Contains(q) ||
                                             x.ngayGiaoHang.Value.ToString().Contains(q) ||
                                             x.diaChiGiaoHang.Contains(q) ||
                                             x.thanhTien.ToString().Contains(q)
                );
            }
            return PartialView(donHang.ToList());
        }

        // GET: Admin/Order/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHang donHang = db.DonHang.Find(id);
            if (donHang == null)
            {
                return HttpNotFound();
            }
            return View(donHang);
        }

        public List<SelectListItem> GetCheckoutState()
        {
            var list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Value = "false", Text = "Chưa thanh toán" });
            list.Add(new SelectListItem() { Value = "true", Text = "Đã thanh toán" });
            return list;
        }

        // GET: Admin/Order/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHang donHang = db.DonHang.Find(id);
            if (donHang == null)
            {
                return HttpNotFound();
            }
            ViewBag.trangThaiThanhToan = new SelectList(GetCheckoutState(), "Value", "Text", donHang.trangThaiThanhToan);
            return View(donHang);
        }

        // POST: Admin/Order/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,idKhachHang,ngayDatHang,diaChiGiaoHang,ngayGiaoHang,ghiChu,hinhThucThanhToan,thanhTien,trangThaiThanhToan,trangThaiDonHang")] DonHang donHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.trangThaiThanhToan = new SelectList(GetCheckoutState(), "Value", "Text", donHang.trangThaiThanhToan);
            return View(donHang);
        }

        public ActionResult UpdateOrderState(int id, byte oldState, byte newState)
        {
            if(Session["curStaff"] != null)
            {
                var order = db.DonHang.Find(id);
                order.trangThaiDonHang = newState;
                db.NhanVienTiepNhanDonHang.Add(new NhanVienTiepNhanDonHang()
                {
                    idDonHang = id,
                    idNhanVien = (Session["curStaff"] as NhanVien).id,
                    ngayNhanDon = DateTime.Now,
                    trangThaiDonHang_Cu = oldState,
                    trangThaiDonHang_Moi = newState
                });
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Order");
        }

        // GET: Admin/Order/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHang donHang = db.DonHang.Find(id);
            if (donHang == null)
            {
                return HttpNotFound();
            }
            return View(donHang);
        }

        // POST: Admin/Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DonHang donHang = db.DonHang.Find(id);
            db.DonHang.Remove(donHang);
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
