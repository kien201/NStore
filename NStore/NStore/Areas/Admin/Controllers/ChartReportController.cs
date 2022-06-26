using NStore.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NStore.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin, mod")]
    public class ChartReportController : Controller
    {
        private NStoreEntities db = new NStoreEntities();
        // GET: Admin/ChartReport
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult RenderChart(string inputType, string inputValue)
        {
            int month, year;
            List<string> arrLabel = new List<string>();
            List<int> arrData = new List<int>();
            if (inputType == "month")
            {
                DateTime date = DateTime.Parse(inputValue);
                month = date.Month;
                year = date.Year;
                for (int i = 1; i <= DateTime.DaysInMonth(year, month); i++)
                {
                    arrLabel.Add("Ngày " + i);
                    int tongTien = Convert.ToInt32(db.DonHang.Where(x =>
                                    x.ngayDatHang.Value.Day == i && x.ngayDatHang.Value.Month == month && x.ngayDatHang.Value.Year == year
                                    && x.trangThaiThanhToan == true
                                    && (x.trangThaiDonHang == 2 || x.trangThaiDonHang == 3 || x.trangThaiDonHang == 4))
                                    .Sum(x => x.thanhTien));
                    arrData.Add(tongTien / 1000);
                }
            }
            else
            {
                year = Convert.ToInt32(inputValue);
                for (int i = 1; i <= 12; i++)
                {
                    arrLabel.Add("Tháng " + i);
                    int tongTien = Convert.ToInt32(db.DonHang.Where(x => 
                                    x.ngayDatHang.Value.Month == i && x.ngayDatHang.Value.Year == year
                                    && x.trangThaiThanhToan == true
                                    && (x.trangThaiDonHang == 2 || x.trangThaiDonHang == 3 || x.trangThaiDonHang == 4))
                                    .Sum(x => x.thanhTien));
                    arrData.Add(tongTien / 1000);
                }
            }
            return Json(new { arrLabel, arrData }, JsonRequestBehavior.AllowGet);
        }
    }
}