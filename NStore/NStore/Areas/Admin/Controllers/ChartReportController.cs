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
    }
}