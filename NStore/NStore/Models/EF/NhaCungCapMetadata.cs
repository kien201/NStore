using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NStore.Models.EF
{
    public class NhaCungCapMetadata
    {
        [Display(Name = "Tên nhà cung cấp")]
        [Required(ErrorMessage = "không được để trống!")]
        public string tenNhaCungCap { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Không đúng định dạng email!")]
        public string email { get; set; }

        [Display(Name = "Số điện thoại")]
        [MinLength(9, ErrorMessage = "Số điện thoại không hợp lệ!")]
        [MaxLength(15, ErrorMessage = "Số điện thoại không hợp lệ!")]
        [Required(ErrorMessage = "Số điện thoại không được để trống!")]
        public string soDienThoai { get; set; }

        [Display(Name = "Địa chỉ")]
        [DisplayFormat(NullDisplayText = "??")]
        public string diaChi { get; set; }

    }
}