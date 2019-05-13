using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SellingFruitsWeb.Entity;

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
                var imgFruit = db.CHI_TIET_TRAI_CAYs.Where(x => x.Ma_Trai_Cay == id).FirstOrDefault();
                lblTenTC.Text = detailFruit.Ten_Trai_Cay;
                lblDonGia.Text = string.Format("{0:#,##0}", detailFruit.Don_Gia);
                lblDonViTinh.Text = detailFruit.Don_Vi_Tinh;
                lblMieuTa.Text = " Xuất sứ: "+detailFruit.Xuat_Xu;
                imgFruiteId.ImageUrl = imgFruit.Hinh_Trai_Cay;
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