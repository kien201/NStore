using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NStore.Models.EF
{
    public class NhanVienMetadata
    {
        [Display(Name = "Tài khoản")]
        [Required(ErrorMessage = "Tài khoản không được để trống!")]
        public string taiKhoan { get; set; }

        [Display(Name = "Mật khẩu")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Mật khẩu không được để trống!")]
        [MinLength(3, ErrorMessage = "Mật khẩu phải có tối thiểu 3 ký tự!")]
        public string matKhau { get; set; }

        [Display(Name = "Họ tên")]
        [Required(ErrorMessage = "Họ tên không được để trống!")]
        public string hoTen { get; set; }

        [Display(Name = "Căn cước")]
        [MinLength(9, ErrorMessage = "Căn cước không hợp lệ!")]
        [MaxLength(15, ErrorMessage = "Căn cước không hợp lệ!")]
        [Required(ErrorMessage = "Căn cước không được để trống!")]
        public string CCCD { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email không được để trống!")]
        [EmailAddress(ErrorMessage = "Không đúng định dạng email!")]
        public string email { get; set; }

        [Display(Name = "Số điện thoại")]
        [MinLength(9, ErrorMessage = "Số điện thoại không hợp lệ!")]
        [MaxLength(15, ErrorMessage = "Số điện thoại không hợp lệ!")]
        [Required(ErrorMessage = "Số điện thoại không được để trống!")]
        public string soDienThoai { get; set; }

        [Display(Name = "Ngày sinh")]
        [DataType(DataType.Date)]
        [DisplayFormat(NullDisplayText = "??", DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<System.DateTime> ngaySinh { get; set; }

        [Display(Name = "Giới tính")]
        [DisplayFormat(NullDisplayText = "??")]
        public string gioiTinh { get; set; }

        [Display(Name = "Địa chỉ")]
        [DisplayFormat(NullDisplayText = "??")]
        public string diaChi { get; set; }

        [Display(Name = "Chức vụ")]
        [Required(ErrorMessage = "Chức vụ không được để trống!")]
        public Nullable<byte> chucVu { get; set; }
    }
}