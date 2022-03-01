using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NStore.Models.EF
{
    public class NhomDanhMucMetadata
    {
        [Display(Name = "Tên nhóm danh mục")]
        [Required(ErrorMessage = "Tên nhóm danh mục không được để trống!")]
        public string tenNhomDanhMuc { get; set; }

        [Display(Name = "Ảnh")]
        public string img { get; set; }
    }
}