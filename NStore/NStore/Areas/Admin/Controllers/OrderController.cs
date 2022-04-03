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
                donHang = donHang.Where(x => ("#" + x.id.ToString()).Contains(q) ||
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
                if (order != null)
                {
                    //nếu cập nhật đơn hàng thành chờ lấy hàng thì nghĩa là nhân viên đã xác nhận đơn hàng => tạo phiếu xuất kho
                    if (oldState == 1 && newState == 2)
                    {
                        foreach (var item in order.ChiTietDonHang)
                        {
                            var sanPham = db.SanPham.Find(item.idSanPham);
                            if (item.soLuong > sanPham.soLuongTon)
                                return Json("Sản phẩm " + sanPham.tenSanPham + " không đủ số lượng để xuất kho, còn lại " + sanPham.soLuongTon, JsonRequestBehavior.AllowGet);
                        }
                        db.PhieuXuat.Add(new PhieuXuat()
                        {
                            idNhanVien = (Session["curStaff"] as NhanVien).id,
                            idDonHang = id,
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
                                soLuongXuat = item.soLuong,
                                donGiaXuat = item.donGia - item.donGia * item.giamGia / 100
                            });
                            //cập nhật số lượng tồn của sản phẩm
                            var sanPham = db.SanPham.Find(item.idSanPham);
                            sanPham.soLuongTon -= item.soLuong;
                            if (sanPham.soLuongTon < 0) sanPham.soLuongTon = 0;
                        }
                    }
                    //nếu cập nhật đơn hàng thành giao hàng thành công, đặt ngày giao hàng bằng ngày hiện tại
                    if (newState == 4) order.ngayGiaoHang = DateTime.Now;
                    //nếu huỷ đơn hoặc trả hàng/hoàn tiền
                    if (oldState == 4 && newState == 6 || (oldState == 2 || oldState == 3) && newState == 5)
                    {
                        foreach (var item in order.ChiTietDonHang)
                        {
                            //cập nhật số lượng tồn của sản phẩm
                            db.SanPham.Find(item.idSanPham).soLuongTon += item.soLuong;
                        }
                        //bỏ phiếu xuất
                        db.PhieuXuat.Remove(db.PhieuXuat.Where(x => x.idDonHang == id).FirstOrDefault());
                    }
                    order.trangThaiDonHang = newState;
                    db.SaveChanges();
                    return Json(1, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("Không tìm thấy đơn hàng", JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json("Chưa đăng nhập hoặc phiên đăng nhập đã hết hạn", JsonRequestBehavior.AllowGet);
            }
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
            if (donHang.trangThaiDonHang == 2 || donHang.trangThaiDonHang == 3 || donHang.trangThaiDonHang == 4)
            {
                foreach (var item in donHang.ChiTietDonHang)
                {
                    //cập nhật số lượng tồn của sản phẩm
                    db.SanPham.Find(item.idSanPham).soLuongTon += item.soLuong;
                }
                //bỏ phiếu xuất
                db.PhieuXuat.Remove(db.PhieuXuat.Where(x => x.idDonHang == id).FirstOrDefault());
            }
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
