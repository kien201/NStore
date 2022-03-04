using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NStore.Models.EF
{
    public class PhieuNhapMetadata
    {
        [Display(Name = "Họ tên")]
        public Nullable<int> idNhanVien { get; set; }

        [Display(Name = "Nhà Cung cấp")]
        public Nullable<int> idNhaCungCap { get; set; }

        [Display(Name = "Ngày nhập")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> ngayNhap { get; set; }
    }
}