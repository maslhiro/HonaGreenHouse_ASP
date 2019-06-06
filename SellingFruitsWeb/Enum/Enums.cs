using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  SellingFruitsWeb.Extensions
{
    
    public enum DonHang
    {

        [Description("Chờ xác nhận")]
        DH_Pending = 0,

        [Description("Hủy")]
        DH_Cancel =1,

        [Description("Thành công")]
        DH_Success = 2
    }
}
