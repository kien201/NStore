using NStore.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace NStore.Controllers
{
    public class LoginController : Controller
    {
        NStoreEntities db = new NStoreEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string taiKhoan, string matKhau, string signinRemember)
        {
            matKhau = Code.Md5hash.md5(matKhau);
            var user = db.KhachHang.SingleOrDefault(x => x.taiKhoan == taiKhoan && x.matKhau == matKhau);
            if (user != null)
            {
                Session.Remove("curStaff");
                Session.Remove("curCustomer");
                FormsAuthentication.SetAuthCookie("customer" + user.taiKhoan, signinRemember == "on");
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không chính xác");
            }
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Remove("curCustomer");
            return RedirectToAction("Index");
        }

        public EmptyResult CheckAuthenticate()
        {
            if (User.Identity.Name.StartsWith("customer"))
            {
                var user = db.KhachHang.SingleOrDefault(x => x.taiKhoan == User.Identity.Name.Substring(8));
                Session["curCustomer"] = user;
            }
            return new EmptyResult();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(KhachHang khachHang, string retypePass)
        {
            if(khachHang.matKhau != retypePass) ModelState.AddModelError("", "Mật khẩu nhập lại không đúng");

            int count = db.KhachHang.Where(x => x.taiKhoan == khachHang.taiKhoan).Count();
            if (count > 0) ModelState.AddModelError("", "Tài khoản đã có người đăng ký");

            if (ModelState.IsValid)
            {
                khachHang.matKhau = Code.Md5hash.md5(khachHang.matKhau);
                db.KhachHang.Add(khachHang);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View("Index", khachHang);
        }

    }
}