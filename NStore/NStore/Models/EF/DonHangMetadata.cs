using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NStore.Models.EF
{
    public class DonHangMetadata
    {
        [Display(Name = "Ngày đặt hàng")]
        [DisplayFormat(DataFormatString = "{0:HH:mm - dd/MM/yyyy}")]
        public Nullable<System.DateTime> ngayDatHang { get; set; }

        [Display(Name = "Địa chỉ giao hàng")]
        [Required(ErrorMessage = "Địa chỉ giao hàng không được để trống!")]
        public string diaChiGiaoHang { get; set; }

        [Display(Name = "Ngày giao hàng")]
        [DisplayFormat(NullDisplayText = "??", DataFormatString = "{0:HH:mm - dd/MM/yyyy}")]
        public Nullable<System.DateTime> ngayGiaoHang { get; set; }

        [Display(Name = "Ghi chú")]
        [DataType(DataType.MultilineText)]
        [DisplayFormat(NullDisplayText = "??")]
        public string ghiChu { get; set; }

        [Display(Name = "Hình thức thanh toán")]
        public string hinhThucThanhToan { get; set; }

        [Display(Name = "Thành tiền")]
        [DataType(DataType.Currency)]
        public Nullable<int> thanhTien { get; set; }

        [Display(Name = "Thanh toán")]
        public Nullable<bool> trangThaiThanhToan { get; set; }

        [Display(Name = "Trạng thái")]
        public Nullable<byte> trangThaiDonHang { get; set; }
    }
}