using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NStore.Models.EF
{
    public class PhieuXuatMetadata
    {
        [Display(Name = "Ngày xuất")]
        [DisplayFormat(NullDisplayText = "??", DataFormatString = "{0:HH:mm - dd/MM/yyyy}")]
        public Nullable<System.DateTime> ngayXuat { get; set; }
    }
}