using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NStore.Models.EF
{
    public class SanPhamMetadata
    {
        [Display(Name = "Tên sản phẩm")]
        [Required(ErrorMessage = "Sản phẩm không được để trống!")]
        public string tenSanPham { get; set; }

        [Display(Name = "Họ tên")]
        [Required(ErrorMessage = "Họ tên không được để trống!")]
        public string idDanhMuc { get; set; }

        [Display(Name = "Image")]
        [Required(ErrorMessage = "Không được để trống!")]
        public string img { get; set; }

        [Display(Name = "Mô tả")]
        [Required(ErrorMessage = "Không được để trống!")]
        public string mota { get; set; }

        [Display(Name = "Kích thước")]
        [Required(ErrorMessage = "Không được để trống!")]
        public string kichThuoc { get; set; }

        [Display(Name = "Màu sắc")]
        [Required(ErrorMessage = "Không được để trống!")]
        public string mauSac { get; set; }

        [Display(Name = "Chất liệu")]
        [Required(ErrorMessage = "Không được để trống!")]
        public string chatLieu { get; set; }

        [Display(Name = "Xuất xứ")]
        [Required(ErrorMessage = "Không được để trống!")]
        public string xuatXu { get; set; }

        [Display(Name = "Đơn giá")]
        [Required(ErrorMessage = "Không được để trống!")]
        public Nullable<int> donGia { get; set; }

        [Display(Name = "Giảm giá")]
        [Required(ErrorMessage = "Không được để trống!")]
        public Nullable<byte> giamGia { get; set; }

        [Display(Name = "Số lượng tồn")]
        [Required(ErrorMessage = "Không được để trống!")]
        public Nullable<int> soLuongTon { get; set; }
    }
}