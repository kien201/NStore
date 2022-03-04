using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NStore.Models.EF;

namespace NStore.Models
{
    public class CustomStock
    {
        public PhieuNhap phieu_nhap { get; set; }
        public List<SanPham> list_sanpham { get; set; }

    }
}