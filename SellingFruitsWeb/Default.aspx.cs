using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SellingFruitsWeb
{
    public partial class Default : System.Web.UI.Page
    {
        FruitDataDataContext db = new FruitDataDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadListTraiCayBanChay();            
        }

        private void LoadListTraiCayBanChay()
        {
            var traiCay = from tc in db.TRAI_CAYs
                          orderby tc.Count descending
                          select tc;

            var i = 1;
            foreach (var tc in traiCay)
            {
                if (i > 10)
                    break;

                HtmlGenericControl li = new HtmlGenericControl("li");
                //HtmlGenericControl a = new HtmlGenericControl("a");
                //a.Attributes.Add("href", "#");
                //li.Controls.Add(a);
                li.InnerHtml = "<a href='" + "/DetailFruit.aspx?id=" + tc.Ma_Trai_Cay + "'><div class='card'><img src='" + tc.Url_Anh + "' alt='Avatar'><div class='content'><div class='product_name'><b>" + tc.Ten_Trai_Cay + "</b></div><div class='product_unit'>ĐƠN VI TÍNH : " + tc.Don_Vi_Tinh + "</div><div class='product_price'>" + tc.Don_Gia_Xuat + " ₫</div></div></div></a>";
                ul_list_tc.Controls.Add(li);
                i++;
            }
        }

        protected void button_see_more_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("/DanhMuc.aspx?id=BanChay");
        }
    }
}