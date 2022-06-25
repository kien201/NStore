using NStore.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NStore.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin, mod")]
    public class ReportController : Controller
    {
        private NStoreEntities db = new NStoreEntities();
        // GET: Admin/Report
        public ActionResult Index(DateTime? fromDate, DateTime? toDate)
        {
            if(fromDate == null || toDate == null)
            {
                fromDate = DateTime.Today.AddDays(-30);
                toDate = DateTime.Today;
            }
            if (fromDate > toDate) fromDate = toDate.Value.AddDays(-30);

            DateTime toDateCompare = toDate.Value.AddDays(1);
            var orderConfirmed = db.DonHang
                .Where(x => fromDate < x.ngayDatHang && x.ngayDatHang < toDateCompare
                    && (x.trangThaiDonHang == 2 || x.trangThaiDonHang == 3 || x.trangThaiDonHang == 4)).ToList();

            ViewBag.fromDate = fromDate;
            ViewBag.toDate = toDate;
            return View(orderConfirmed);
        }
    }
}