using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NStore.Models.EF
{
    public class PhieuNhapMetadata
    {
        [Display(Name = "Ngày nhập")]
        [DisplayFormat(NullDisplayText = "??", DataFormatString = "{0:HH:mm - dd/MM/yyyy}")]
        public Nullable<System.DateTime> ngayNhap { get; set; }
    }
}