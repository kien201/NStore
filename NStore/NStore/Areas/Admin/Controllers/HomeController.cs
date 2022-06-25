using NStore.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NStore.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin, mod")]
    public class HomeController : Controller
    {
        private NStoreEntities db = new NStoreEntities();

        // GET: Admin/Home
        public ActionResult Index()
        {
            var monday = DateTime.Today.AddDays(DayOfWeek.Monday - DateTime.Today.DayOfWeek);
            var order = db.DonHang.Where(x => x.ngayDatHang >= monday
                        && (x.trangThaiDonHang == 2 || x.trangThaiDonHang == 3 || x.trangThaiDonHang == 4));
            ViewBag.doanhthu = order.Sum(x => x.thanhTien);
            ViewBag.orderCount = order.Count();
            return View(db.DonHang);
        }
    }
}