using NStore.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace NStore.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin, mod")]
    public class KhoController : Controller
    {
        private NStoreEntities db = new NStoreEntities();

        // GET: Admin/Kho
        public ActionResult Index(string q)
        {
            var sanPham = db.SanPham.Select(x => x);
            if (q != null)
            {
                sanPham = sanPham.Where(x => x.tenSanPham.Contains(q) ||
                                             x.DanhMuc.tenDanhMuc.Contains(q) ||
                                             x.soLuongTon.Value.ToString().Contains(q));
            }
            return View(sanPham.OrderByDescending(x => x.id));
        }

        public ActionResult NhapKho()
        {
            ViewBag.idNhaCungCap = new SelectList(db.NhaCungCap, "id", "tenNhaCungCap");
            ViewBag.idSanPham = new SelectList(db.SanPham, "id", "tenSanPham");
            return View();
        }

        [HttpPost]
        public JsonResult NhapKhoPost(int idNhaCungCap, IEnumerable<ChiTietPhieuNhap> listSanPham)
        {
            if (Session["curStaff"] != null)
            {
                db.PhieuNhap.Add(new PhieuNhap()
                {
                    idNhanVien = (Session["curStaff"] as NhanVien).id,
                    idNhaCungCap = idNhaCungCap,
                    ngayNhap = DateTime.Now
                });
                db.SaveChanges();
                int idPhieuNhap = db.PhieuNhap.OrderByDescending(x => x.id).First().id;
                foreach (var item in listSanPham)
                {
                    db.ChiTietPhieuNhap.Add(new ChiTietPhieuNhap()
                    {
                        idPhieuNhap = idPhieuNhap,
                        idSanPham = item.idSanPham,
                        soLuongNhap = item.soLuongNhap,
                        donGiaNhap = item.donGiaNhap
                    });
                    db.SanPham.Find(item.idSanPham).soLuongTon += item.soLuongNhap;
                }
                db.SaveChanges();
                return Json("Nhập kho thành công", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Chưa đăng nhập hoặc phiên đăng nhập đã hết hạn", JsonRequestBehavior.AllowGet);
            }
        }

        [ChildActionOnly]
        public ActionResult RenderPhieuNhap(string q)
        {
            var phieuNhap = db.PhieuNhap.Select(x => x);
            if (q != null)
            {
                phieuNhap = phieuNhap.Where(x => ("#" + x.id.ToString()).Contains(q) ||
                                                 x.NhanVien.hoTen.Contains(q) ||
                                                 x.NhaCungCap.tenNhaCungCap.Contains(q));
            }
            return PartialView(phieuNhap.OrderByDescending(x => x.id));
        }

        public ActionResult ChiTietPhieuNhap(int? id)
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

        public ActionResult XoaPhieuNhap(int? id)
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

        [HttpPost, ActionName("XoaPhieuNhap")]
        [ValidateAntiForgeryToken]
        public ActionResult XoaPhieuNhapConfirmed(int? id)
        {
            PhieuNhap phieuNhap = db.PhieuNhap.Find(id);
            foreach (var item in phieuNhap.ChiTietPhieuNhap)
            {
                var sanPham = db.SanPham.Find(item.idSanPham);
                sanPham.soLuongTon -= item.soLuongNhap;
                if (sanPham.soLuongTon < 0) sanPham.soLuongTon = 0;
            }
            db.PhieuNhap.Remove(phieuNhap);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult XuatKho()
        {
            ViewBag.idSanPham = new SelectList(db.SanPham, "id", "tenSanPham");
            return View();
        }

        public JsonResult XuatKhoPost(IEnumerable<ChiTietPhieuXuat> listSanPham)
        {
            if (Session["curStaff"] != null)
            {
                foreach (var item in listSanPham)
                {
                    var sanPham = db.SanPham.Find(item.idSanPham);
                    if (item.soLuongXuat > sanPham.soLuongTon)
                        return Json("Sản phẩm " + sanPham.tenSanPham + " không đủ số lượng để xuất kho, còn lại " + sanPham.soLuongTon, JsonRequestBehavior.AllowGet);
                }
                db.PhieuXuat.Add(new PhieuXuat()
                {
                    idNhanVien = (Session["curStaff"] as NhanVien).id,
                    ngayXuat = DateTime.Now
                });
                db.SaveChanges();
                int idPhieuXuat = db.PhieuXuat.OrderByDescending(x => x.id).First().id;
                foreach (var item in listSanPham)
                {
                    db.ChiTietPhieuXuat.Add(new ChiTietPhieuXuat()
                    {
                        idPhieuXuat = idPhieuXuat,
                        idSanPham = item.idSanPham,
                        soLuongXuat = item.soLuongXuat,
                        donGiaXuat = item.donGiaXuat
                    });
                    var sanPham = db.SanPham.Find(item.idSanPham);
                    sanPham.soLuongTon -= item.soLuongXuat;
                    if (sanPham.soLuongTon < 0) sanPham.soLuongTon = 0;
                }
                db.SaveChanges();
                return Json("Xuất kho thành công", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Chưa đăng nhập hoặc phiên đăng nhập đã hết hạn", JsonRequestBehavior.AllowGet);
            }
        }

        [ChildActionOnly]
        public ActionResult RenderPhieuXuat(string q)
        {
            var phieuXuat = db.PhieuXuat.Select(x => x);
            if (q != null)
            {
                phieuXuat = phieuXuat.Where(x => ("#" + x.id).Contains(q) ||
                                                 ("#" + x.DonHang.id).Contains(q) ||
                                                 x.DonHang.KhachHang.hoTen.Contains(q) ||
                                                 x.NhanVien.hoTen.Contains(q));
            }
            return PartialView(phieuXuat.OrderByDescending(x => x.id));
        }

        public ActionResult ChiTietPhieuXuat(int? id)
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

        public ActionResult XoaPhieuXuat(int? id)
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

        [HttpPost, ActionName("XoaPhieuXuat")]
        [ValidateAntiForgeryToken]
        public ActionResult XoaPhieuXuatConfirmed(int? id)
        {
            PhieuXuat phieuXuat = db.PhieuXuat.Find(id);
            foreach (var item in phieuXuat.ChiTietPhieuXuat)
            {
                db.SanPham.Find(item.idSanPham).soLuongTon += item.soLuongXuat;
            }
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