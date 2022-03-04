using NStore.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace NStore.Controllers
{
    public class HomeController : Controller
    {
        private NStoreEntities db = new NStoreEntities();
        //[Authorize(Roles = "customer")]
        public ActionResult Index()
        {
            var beginDate = DateTime.Now.AddMonths(-1);
            //sắp xếp theo danh mục có số sản phẩm được đặt trong tháng từ cao đến thấp, lấy ra 6 danh mục có sản phẩm được đặt nhiều nhất
            var popularCategory = db.DanhMuc.Select(x => new
            {
                x,
                count = db.ChiTietDonHang.Where(y => y.SanPham.idDanhMuc == x.id && y.DonHang.ngayDatHang.Value >= beginDate).Sum(y => y.soLuong)
            }).OrderByDescending(x => x.count).ThenByDescending(x => x.x.id).Select(x => x.x).Take(6);
            ViewBag.popularCategory = popularCategory.ToList();
            return View();
        }

        public ActionResult RenderProductCarousel(int? category, string type = "newest")
        {
            var list = db.SanPham.Select(x => x);
            if (category != null)
            {
                list = list.Where(x => x.idDanhMuc == category);
            }
            switch (type)
            {
                case "newest":
                    list = list.OrderByDescending(x => x.id);
                    break;
                case "popular":
                    //sắp xếp theo sản phẩm được đặt nhiều nhất trong tháng
                    var beginDate = DateTime.Now.AddMonths(-1);
                    list = list.Select(x => new
                    {
                        x,
                        count = db.ChiTietDonHang.Where(y => y.idSanPham == x.id && y.DonHang.ngayDatHang.Value >= beginDate).Sum(y => y.soLuong)
                    }).OrderByDescending(x => x.count).ThenByDescending(x => x.x.id).Select(x => x.x);
                    break;
            }

            return PartialView(list.Take(10).ToList());
        }

        [ChildActionOnly]
        public ActionResult CategoryMenuLayout()
        {
            var nhomDanhMuc = db.NhomDanhMuc.ToList();
            return PartialView(nhomDanhMuc);
        }

        [ChildActionOnly]
        public ActionResult CategoryMenuMobileLayout()
        {
            var nhomDanhMuc = db.NhomDanhMuc.ToList();
            return PartialView(nhomDanhMuc);
        }

        //Redirect to the login page if not authentication yet
        public RedirectResult LoginRedirect(string returnUrl)
        {
            if (returnUrl.ToLower().StartsWith("/admin"))
                return Redirect(Url.Content("~/admin/Login/Index"));
            else
                return Redirect(Url.Content("~/Login/Index"));
        }

    }
}