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
                lblDonGiaInt.Text = detailFruit.Don_Gia_Xuat.ToString();
                lblDonViTinh.Text = detailFruit.Don_Vi_Tinh;
                lblMieuTa.Text = " Xuất sứ: "+detailFruit.Xuat_Xu;
                imgFruiteId.ImageUrl = detailFruit.Url_Anh;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            

        }

        protected void btnBuy_Click(object sender, EventArgs e)
        {
            var money = Convert.ToDecimal(lblDonGia.Text) * Convert.ToDecimal(txbSoLuong.Text);
            // txbGhiChu.text = textarea_note.text;
            updateCookieGioHang();
        }

        protected void updateCookieGioHang()
        {    
            try
            {
                List<Chi_Tiet_Gio_Hang> gioHang = readCookieGioHang();
                Chi_Tiet_Gio_Hang chitietGioHang = null;
                if (gioHang == null)
                {
                    gioHang = new List<Chi_Tiet_Gio_Hang>();
                }
                else
                {
                    chitietGioHang = gioHang.FirstOrDefault(p => p.Ma_Trai_Cay == Request.QueryString["id"].ToString());
                }
                
                if (chitietGioHang != null)
                {
                    chitietGioHang.So_Luong_Xuat = (Int32.Parse(txbSoLuong.Text) + Int32.Parse(chitietGioHang.So_Luong_Xuat)).ToString();
                }
                else
                {
                    chitietGioHang = new Chi_Tiet_Gio_Hang();
                    chitietGioHang.Ma_Trai_Cay = Request.QueryString["id"].ToString();
                    chitietGioHang.Don_Gia_Xuat = lblDonGiaInt.Text;
                    chitietGioHang.So_Luong_Xuat = txbSoLuong.Text;
                    gioHang.Add(chitietGioHang);
                }


                string json = JsonConvert.SerializeObject(gioHang);
                HttpCookie cookie = new HttpCookie("Gio_Hang");
                cookie.Value = json;

                // Set the cookie expiration date.
                cookie.Expires = DateTime.Now.AddDays(1);

                Response.Cookies.Add(cookie);
            }
            catch (Exception e)
            {
                throw e;
            }
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
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
            return null;
        }
    }
}