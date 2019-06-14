using Newtonsoft.Json;
using SellingFruitsWeb.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SellingFruitsWeb
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loadGioHangText();
        }

        protected void btnGioHang_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("GioHang.aspx");
        }

        private void loadGioHangText()
        {
            int countList = readCookieGioHang().Count;

            if (countList > 0) txtGioHang.InnerText = "Giỏ hàng ( " + countList.ToString() + " sản phẩm)";
        }

        protected List<Chi_Tiet_Gio_Hang> readCookieGioHang()
        {
            List<Chi_Tiet_Gio_Hang> list = new List<Chi_Tiet_Gio_Hang>();
            try
            {
                HttpCookie cookie = new HttpCookie("Gio_Hang");
                cookie = Request.Cookies["Gio_Hang"];

                // Read the cookie information and display it.
                if (cookie != null)
                {
                    string json = cookie.Value;

                    list = JsonConvert.DeserializeObject<List<Chi_Tiet_Gio_Hang>>(json);
                    return list;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
            return null;
        }
    }
}