using NStore.Models;
using NStore.Models.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NStore.Controllers
{
    [Authorize(Roles = "customer")]
    public class UserController : Controller
    {
        NStoreEntities db = new NStoreEntities();
        // GET: User
        public ActionResult Index()
        {
            if (Session["curCustomer"] != null)
            {
                var customer = (Session["curCustomer"] as KhachHang);
                return View(customer);
        }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult RenderUserOrder(int idCustomer, int? orderState)
        {
            var order = db.DonHang.Where(x => x.idKhachHang == idCustomer);
            if (orderState != null)
            {
                order = order.Where(x => x.trangThaiDonHang == orderState);
        }
            return PartialView(order.ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateCustomer(KhachHang customer, string oldPass, string newPass, string retypePass)
        {
            bool isChangePass = false;
            if(oldPass != "" || newPass != "" || retypePass != "")
            {
                if (Code.Md5hash.md5(oldPass) != customer.matKhau) ModelState.AddModelError("", "Mật khẩu không chính xác");
                if (newPass.Length < 3 || retypePass.Length < 3) ModelState.AddModelError("", "Mật khẩu phải có tối thiểu 3 ký tự");
                if(newPass != retypePass) ModelState.AddModelError("", "Mật khẩu nhập lại không đúng");
                isChangePass = true;
            }
            if (ModelState.IsValid)
            {
                if (isChangePass) customer.matKhau = Code.Md5hash.md5(newPass);
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                Session["curCustomer"] = db.KhachHang.Find(customer.id);
                return RedirectToAction("Index");
            }
            return View("Index", customer);
        }

        public ActionResult Wishlist()
        {
            return View(db.SanPhamYeuThich.Where(x => x.idKhachHang == 1).ToList());
        }

        public ActionResult Loading_Wishlist()
        {
            var rm = db.SanPhamYeuThich.Select(x => new {
                soLuongTon = x.SanPham.soLuongTon,
                idSanPham = x.idSanPham,
                donGia = x.SanPham.donGia,
                idKhachHang = x.idKhachHang,
                tenSanPham = x.SanPham.tenSanPham,
                img = x.SanPham.img
            })
                    .Where(x => x.idKhachHang == 1);

            return Json(rm, JsonRequestBehavior.AllowGet);

        }

        public JsonResult Adding_Wishlist(int? id_sanpham)
        {
            if (db.SanPhamYeuThich.Any(x => x.idSanPham == id_sanpham))
                return Json("Đã có sản phẩm trong yêu thích", JsonRequestBehavior.AllowGet);
            else
            {
                db.SanPhamYeuThich.Add(new SanPhamYeuThich() { idKhachHang = 1, idSanPham = id_sanpham });
                db.SaveChanges();
                return Json("Thêm thành công", JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult Removing_Wishlist(int? id_sanpham)
        {
            var rm = db.SanPhamYeuThich.Where(x => x.idSanPham == id_sanpham).FirstOrDefault();
            db.SanPhamYeuThich.Remove(rm);
            db.SaveChanges();
            return Json("Xóa khỏi danh sách ưa thích thành công", JsonRequestBehavior.AllowGet);
        }

        public ActionResult Cart()
        {
            if (Session["curCustomer"] != null)
            {
                var customer = (Session["curCustomer"] as KhachHang);
                var list = customer.GioHang;
                return View(list.ToList());
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult CheckOut()
        {
            if (Session["curCustomer"] != null)
            {
                var customer = (Session["curCustomer"] as KhachHang);
                var list = customer.GioHang;
                if (list.Count > 0)
                {
                    ViewBag.curCustomer = customer;
                    return View(list.ToList());
        }
                else
                {
                    return RedirectToAction("Cart");
                }
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CheckOut(int idCustomer, string checkboxDiffAddress, string diffAddress, string deliveryNotes, int accordionPayment)
        {
            var customer = db.KhachHang.Find(idCustomer);
            var cartList = customer.GioHang;
            ViewBag.curCustomer = customer;

            var newOrder = new DonHang()
            {
                idKhachHang = idCustomer,
                ngayDatHang = DateTime.Now,
                ghiChu = deliveryNotes,
                hinhThucThanhToan = accordionPayment == 1 ? "Trả tiền mặt khi nhận hàng" : "Chuyển khoản ngân hàng",
                thanhTien = cartList.Sum(x => (x.SanPham.donGia - x.SanPham.donGia * x.SanPham.giamGia / 100) * x.soLuong),
                trangThaiThanhToan = false,
                trangThaiDonHang = 1
            };

            if (checkboxDiffAddress == "on")
        {
                if (diffAddress == null) ModelState.AddModelError("", "Địa chỉ không được để trống");
                newOrder.diaChiGiaoHang = diffAddress;
                db.DonHang.Add(newOrder);
                db.SaveChanges();
            }
            else
            {
                if (customer.diaChi == null) ModelState.AddModelError("", "Địa chỉ hiện tại của bạn đang trống, hãy chọn giao hàng đến địa chỉ khác");
                newOrder.diaChiGiaoHang = customer.diaChi;
                db.DonHang.Add(newOrder);
                db.SaveChanges();
            }

            if (ModelState.IsValid)
            {
                var order = db.DonHang.OrderByDescending(x => x.id).First();
                foreach (var item in cartList)
                {
                    db.ChiTietDonHang.Add(new ChiTietDonHang()
                    {
                        idDonHang = order.id,
                        idSanPham = item.idSanPham,
                        soLuong = item.soLuong,
                        donGia = item.SanPham.donGia,
                        giamGia = item.SanPham.giamGia
                    });
                }
                db.GioHang.RemoveRange(cartList);
                db.SaveChanges();
                return View("CheckOutSuccess", order);
            }
            return View(cartList.ToList());
        }

        public JsonResult GetListCart()
        {
            int customerId = (Session["curCustomer"] as KhachHang).id;
            var cart = db.GioHang.Where(x => x.idKhachHang == customerId)
                .Select(x => new
                {
                    x.id,
                    idSanPham = x.SanPham.id,
                    x.SanPham.tenSanPham,
                    x.SanPham.img,
                    x.SanPham.donGia,
                    x.SanPham.giamGia,
                    x.soLuong
                });
            return Json(cart.ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTotal_CartPrice()
        {
            int customerId = (Session["curCustomer"] as KhachHang).id;
            var totalPrice = db.GioHang.Where(x => x.idKhachHang == customerId).Sum(x => (x.SanPham.donGia - x.SanPham.donGia * x.SanPham.giamGia / 100) * x.soLuong);
            return Json(totalPrice, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddToCart(int productId, int soLuong, string type = "replace")
        {
            int customerId = (Session["curCustomer"] as KhachHang).id;
            var cart = db.GioHang.FirstOrDefault(x => x.idSanPham == productId && x.idKhachHang == customerId);
            if (cart != null)
            {
                if (type == "add") db.GioHang.Find(cart.id).soLuong += soLuong;
                else db.GioHang.Find(cart.id).soLuong = soLuong;
            }
            else
            {
                var newCart = new GioHang() { idKhachHang = customerId, idSanPham = productId, soLuong = soLuong };
                db.GioHang.Add(newCart);
            }
            db.SaveChanges();
            return Json("Đã cập nhật giỏ hàng", JsonRequestBehavior.AllowGet);
        }

        public JsonResult RemoveFromCart(int id)
        {
            var user = Session["curCustomer"] as KhachHang;
            if (user != null)
        {
                db.GioHang.Remove(db.GioHang.Find(id));
                db.SaveChanges();
            }
            return Json("Xóa thành công", JsonRequestBehavior.AllowGet);
        }

    }
}