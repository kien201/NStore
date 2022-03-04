using NStore.Models;
using NStore.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NStore.Controllers
{
    public class ProductController : Controller
    {
        private NStoreEntities db = new NStoreEntities();
        // GET: SanPham
        public ActionResult Index()
        {
            var index = db.SanPham.ToList();
            return View(index);
        }
        public ActionResult ProductDetail(int? id)
        {
            CustomProduct ct = new CustomProduct();
            var sp = db.SanPham.Find(2);
            ct.sanpham = sp;
            ct.list_sanpham = db.SanPham.Where(x => x.idDanhMuc == sp.idDanhMuc).ToList();
            return View(ct);
        }
    }
}
