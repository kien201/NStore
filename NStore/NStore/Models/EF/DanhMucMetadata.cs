using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NStore.Models.EF
{
    public class DanhMucMetadata
    {
        [Display(Name = "Tên danh mục")]
        [Required(ErrorMessage = "Tên danh mục không được để trống!")]
        public string tenDanhMuc { get; set; }

        [Display(Name = "Ảnh")]
        public string img { get; set; }
    }
}