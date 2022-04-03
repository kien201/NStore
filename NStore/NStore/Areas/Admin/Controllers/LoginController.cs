using NStore.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace NStore.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        NStoreEntities db = new NStoreEntities();
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(NhanVien nhanVien, string rememberPass)
        {
            nhanVien.matKhau = Code.Md5hash.md5(nhanVien.matKhau);
            int count = db.NhanVien.Where(x => x.taiKhoan == nhanVien.taiKhoan && x.matKhau == nhanVien.matKhau).Count();
            if (count > 0)
            {
                Session.Remove("curStaff");
                Session.Remove("curCustomer");
                FormsAuthentication.SetAuthCookie("staff" + nhanVien.taiKhoan, rememberPass == "on");
                return RedirectToAction("Index", "Customer");
            }
            else
            {
                ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không chính xác");
            }
            return View(nhanVien);
        }

        [Authorize(Roles = "admin, mod")]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Remove("curStaff");
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "admin, mod")]
        public EmptyResult CheckAuthenticate()
        {
            if (User.Identity.Name.StartsWith("staff"))
            {
                var user = db.NhanVien.SingleOrDefault(x => x.taiKhoan == User.Identity.Name.Substring(5));
                Session["curStaff"] = user;
            }
            return new EmptyResult();
        }
    }
}