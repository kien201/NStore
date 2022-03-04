using NStore.Models;
using NStore.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NStore.Controllers
{
    public class UserController : Controller
    {
        private NStoreEntities db = new NStoreEntities();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Wishlist()
        {
            return View(db.SanPhamYeuThich.Where(x => x.idKhachHang == 1).ToList());
        }
        public ActionResult Loading_Wishlist()
        {
            var rm = db.SanPhamYeuThich.Select(x => new { soLuongTon=x.SanPham.soLuongTon,
                idSanPham =x.idSanPham,donGia=x.SanPham.donGia,
                idKhachHang =x.idKhachHang,tenSanPham=x.SanPham.tenSanPham,
                img =x.SanPham.img })
                    .Where(x => x.idKhachHang ==1);

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
    }
}