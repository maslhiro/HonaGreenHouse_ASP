using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SellingFruitsWeb
{
    public partial class DetailFruit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FruitDataDataContext db = new FruitDataDataContext();
            try
            {
                string id = Request.QueryString["id"].ToString();
                var detailFruit = db.TRAI_CAYs.Where(x => x.Ma_Trai_Cay == id).FirstOrDefault();
                lblTenTC.Text = detailFruit.Ten_Trai_Cay;
                lblDonGia.Text = string.Format("{0:#,##0}", detailFruit.Don_Gia_Xuat);
                lblDonViTinh.Text = detailFruit.Don_Vi_Tinh;
                lblMieuTa.Text = " Xuất sứ: "+detailFruit.Xuat_Xu;
                imgFruiteId.ImageUrl = detailFruit.Url_Anh;
            }
            catch
            {

            }
            

        }

        protected void btnBuy_Click(object sender, EventArgs e)
        {
            var money = Convert.ToDecimal(lblDonGia.Text) * Convert.ToDecimal(txbSoLuong.Text);
        }
    }
}