using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SellingFruitsWeb
{
    public partial class DanhMuc : System.Web.UI.Page
    {
        FruitDataDataContext db = new FruitDataDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            string danhmuc = Request.QueryString["id"].ToString();
            if(danhmuc == "BanChay")
            {
                LoadListTraiCayBanChay();
            }
            else
            {
                LoadListTraiCayTheoDanhMuc(danhmuc);
            }
        }

        private void LoadListTraiCayTheoDanhMuc(string danhmuc)
        {
            var traiCay = db.TRAI_CAYs.Where(x => x.Loai_ID == danhmuc);
            danh_muc.InnerText = "Trái Cây " + db.LOAI_TRAI_CAYs.Where(x => x.Ma_Loai_Trai_Cay == danhmuc).FirstOrDefault().Ten_Loai_Trai_Cay;

            foreach (var tc in traiCay)
            {
                HtmlGenericControl li = new HtmlGenericControl("li");
                //HtmlGenericControl a = new HtmlGenericControl("a");
                //a.Attributes.Add("href", "#");
                //li.Controls.Add(a);
                li.InnerHtml = "<a href='" + "/DetailFruit.aspx?id=" + tc.Ma_Trai_Cay + "'><div class='card'><img src='" + tc.Url_Anh + "' alt='Avatar'><div class='content'><div class='product_name'><b>" + tc.Ten_Trai_Cay + "</b></div><div class='product_unit'>ĐƠN VI TÍNH : " + tc.Don_Vi_Tinh + "</div><div class='product_price'>" + tc.Don_Gia + " ₫</div></div></div></a>";
                ul_list_danhmuc.Controls.Add(li);
            }
        }

        private void LoadListTraiCayBanChay()
        {
            var traiCay = from tc in db.TRAI_CAYs
                          orderby tc.Count descending
                          select tc;

            danh_muc.InnerText = "Trái Cây Bán Chạy";

            foreach (var tc in traiCay)
            {
                HtmlGenericControl li = new HtmlGenericControl("li");
                //HtmlGenericControl a = new HtmlGenericControl("a");
                //a.Attributes.Add("href", "#");
                //li.Controls.Add(a);
                li.InnerHtml = "<a href='" + "/DetailFruit.aspx?id=" + tc.Ma_Trai_Cay + "'><div class='card'><img src='" + tc.Url_Anh + "' alt='Avatar'><div class='content'><div class='product_name'><b>" + tc.Ten_Trai_Cay + "</b></div><div class='product_unit'>ĐƠN VI TÍNH : " + tc.Don_Vi_Tinh + "</div><div class='product_price'>" + tc.Don_Gia + " ₫</div></div></div></a>";
                ul_list_danhmuc.Controls.Add(li);
            }
        }
    }
}