using NStore.Models;
using NStore.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace NStore.Controllers
{
    public class ProductController : Controller
    {
        NStoreEntities db = new NStoreEntities();
        // GET: Product
        public ActionResult Index(int? category, string q, string sortby = "popular", int page = 1)
        {
            var list = db.SanPham.Select(x => x);
            if (category != null)
            {
                list = list.Where(x => x.idDanhMuc == category);
            }
            if (q != null)
            {
                list = list.Where(x => x.tenSanPham.Contains(q) ||
                                       x.DanhMuc.tenDanhMuc.Contains(q) ||
                                       x.mota.Contains(q) ||
                                       x.kichThuoc.Contains(q) ||
                                       x.mauSac.Contains(q) ||
                                       x.chatLieu.Contains(q) ||
                                       x.xuatXu.Contains(q) ||
                                       x.donGia.ToString().Contains(q) ||
                                       x.giamGia.ToString().Contains(q)
                                       );
            }
            switch (sortby)
            {
                case "popular":
                    //sắp xếp theo sản phẩm được đặt nhiều nhất trong tháng
                    var beginDate = DateTime.Now.AddMonths(-1);
                    list = list.Select(x => new
                    {
                        x,
                        count = db.ChiTietDonHang.Where(y => y.idSanPham == x.id && y.DonHang.ngayDatHang.Value >= beginDate).Sum(y => y.soLuong)
                    }).OrderByDescending(x => x.count).ThenByDescending(x => x.x.id).Select(x => x.x);
                    break;
                case "newest":
                    list = list.OrderByDescending(x => x.id);
                    break;
                case "sales":
                    //sản phẩm được đặt nhiều nhất
                    list = list.OrderByDescending(x => x.ChiTietDonHang.Sum(y => y.soLuong)).ThenByDescending(x => x.id);
                    break;
                case "price-asc":
                    list = list.OrderBy(x => x.donGia);
                    break;
                case "price-desc":
                    list = list.OrderByDescending(x => x.donGia);
                    break;
            }

            //pagination
            float pageLimit = (float)list.Count() / 12;
            list = list.Skip((page - 1) * 12).Take(12);

            ViewBag.category = category;
            ViewBag.q = q;
            ViewBag.sortby = sortby;
            ViewBag.page = page;
            ViewBag.pageLimit = pageLimit % 1 == 0 ? Convert.ToInt32((int)pageLimit) : Convert.ToInt32((int)pageLimit + 1);

            ViewBag.categoryName = category == null ? "Tất cả sản phẩm" : db.DanhMuc.Find(category).tenDanhMuc;
            return View(list.ToList());
        }

        public ActionResult ProductDetail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomProduct ct = new CustomProduct();
            var sp = db.SanPham.Find(id);
            ct.sanpham = sp;
            ct.list_sanpham = db.SanPham.Where(x => x.idDanhMuc == sp.idDanhMuc).ToList();
            return View(ct);
        }
    }
}
