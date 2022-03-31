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

        [ChildActionOnly]
        public ActionResult RenderTableOrder(string q, int? orderState)
        {
            var donHang = db.DonHang.Include(d => d.KhachHang);
            if (orderState != null)
            {
                donHang = donHang.Where(x => x.trangThaiDonHang == orderState);
            }
            if (q != null)
            {
                donHang = donHang.Where(x => x.id.ToString().Contains(q) ||
                                             x.KhachHang.hoTen.Contains(q) ||
                                             x.KhachHang.soDienThoai.Contains(q) ||
                                             x.ChiTietDonHang.Where(y => y.SanPham.tenSanPham.Contains(q)).Count() > 0 ||
                                             x.diaChiGiaoHang.Contains(q)
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
            if (Session["curStaff"] != null)
            {
                var order = db.DonHang.Find(id);
                order.trangThaiDonHang = newState;
                //nếu cập nhật đơn hàng thành đang giao thì nghĩa là nhân viên lấy sản phẩm để đi giao => tạo phiếu xuất kho
                if (newState == 3)
                {
                    foreach (var item in order.ChiTietDonHang)
                    {
                        if (item.soLuong > db.SanPham.Find(item.idSanPham).soLuongTon) return RedirectToAction("Index", "Order");
                    }
                    db.PhieuXuat.Add(new PhieuXuat()
                    {
                        idNhanVien = (Session["curStaff"] as NhanVien).id,
                        ngayXuat = DateTime.Now
                    });
                    db.SaveChanges();
                    int idPhieuXuat = db.PhieuXuat.OrderByDescending(x => x.id).First().id;
                    foreach (var item in order.ChiTietDonHang)
                    {
                        db.ChiTietPhieuXuat.Add(new ChiTietPhieuXuat()
                        {
                            idPhieuXuat = idPhieuXuat,
                            idSanPham = item.idSanPham,
                            soLuongXuat = item.soLuong
                        });
                        var sanPham = db.SanPham.Find(item.idSanPham);
                        sanPham.soLuongTon -= item.soLuong;
                        if (sanPham.soLuongTon < 0) sanPham.soLuongTon = 0;
                    }
                }
                //nếu cập nhật đơn hàng thành giao hàng thành công, đặt ngày giao hàng bằng ngày hiện tại
                if (newState == 4) order.ngayGiaoHang = DateTime.Now;
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
