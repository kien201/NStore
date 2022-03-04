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
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> ngayXuat { get; set; }
    }
}