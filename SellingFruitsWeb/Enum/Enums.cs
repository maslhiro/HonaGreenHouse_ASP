using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  SellingFruitsWeb.Enums
{
    
    public enum DonHang
    {

        [Description("Chờ xác nhận")]
        DH_Pending = 0,

        [Description("Đang xử lý")]
        DH_Processing = 1,

        [Description("Hủy")]
        DH_Cancel = 2,

        [Description("Thành công")]
        DH_Success = 3
    }
    public enum ThanhToan
    {

        [Description("Thanh toán qua MOMO")]
        TT_MOMO = 0,

        [Description("Thanh toán COD")]
        TT_COD = 1
    }




}
