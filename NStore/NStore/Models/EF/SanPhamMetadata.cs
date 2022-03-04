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

        [Display(Name = "Ảnh")]
        public string img { get; set; }

        [Display(Name = "Mô tả")]
        [DataType(DataType.MultilineText)]
        [DisplayFormat(NullDisplayText = "??")]
        public string mota { get; set; }

        [Display(Name = "Kích thước")]
        [DisplayFormat(NullDisplayText = "??")]
        public string kichThuoc { get; set; }

        [Display(Name = "Màu sắc")]
        [DisplayFormat(NullDisplayText = "??")]
        public string mauSac { get; set; }

        [Display(Name = "Chất liệu")]
        [DisplayFormat(NullDisplayText = "??")]
        public string chatLieu { get; set; }

        [Display(Name = "Xuất xứ")]
        [DisplayFormat(NullDisplayText = "??")]
        public string xuatXu { get; set; }

        [Display(Name = "Đơn giá")]
        [Required(ErrorMessage = "Không được để trống!")]
        [DataType(DataType.Currency)]
        public Nullable<int> donGia { get; set; }

        [Display(Name = "Giảm giá")]
        [Required(ErrorMessage = "Không được để trống!")]
        [Range(0, 100, ErrorMessage = "Giá trị nằm trong khoảng 0 đến 100")]
        public Nullable<byte> giamGia { get; set; }

        [Display(Name = "Số lượng tồn")]
        public Nullable<int> soLuongTon { get; set; }
    }
}