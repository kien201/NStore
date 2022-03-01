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
            return View();
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