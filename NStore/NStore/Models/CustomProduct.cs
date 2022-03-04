using NStore.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NStore.Models
{
    public class CustomProduct
    {
        public SanPham sanpham { get; set; }
        public List<SanPham> list_sanpham { get; set; }
    }
}