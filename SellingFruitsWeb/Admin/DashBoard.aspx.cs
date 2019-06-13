using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SellingFruitsWeb.Admin
{
    public partial class DashBoard : System.Web.UI.Page
    {
        private FruitDataDataContext db;
        protected void Page_Load(object sender, EventArgs e)
        {
            db = new FruitDataDataContext();

            int countDHM = db.DON_HANGs.Where(p => p.Tinh_Trang == 0).Count();
            txtDHM.InnerText = countDHM.ToString() + " ĐH Mới!";

            int countDHTC = db.DON_HANGs.Where(p => p.Tinh_Trang == 2).Count();
            txtDHDXL.InnerText = countDHTC + " ĐH Thành Công!";

            int countDHDH = db.DON_HANGs.Where(p => p.Tinh_Trang == 2).Count();
            txtDHH.InnerText = countDHDH + " ĐH Đã Hủy!";

            int countTC = db.TRAI_CAYs.Where(p => p.Is_Deleted == 0).Count();
            txtTraiCay.InnerText = countTC.ToString() + " Loại Trái cây!";


        }
    }
}