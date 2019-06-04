using SellingFruitsWeb.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.Web.UI.HtmlControls;

namespace SellingFruitsWeb
{
    public partial class GioHang : System.Web.UI.Page
    {
        List<Chi_Tiet_Gio_Hang> gioHang;
        const string moneySuffix = " đ";
        protected void Page_Load(object sender, EventArgs e)
        {
            loadCart();
        }

        protected void loadCart()
        {
            FruitDataDataContext db = new FruitDataDataContext();
            gioHang = readCookieGioHang();

            if (gioHang != null && gioHang.Count != 0)
            {
                txtGioHangTrong.Visible = false;
                divGioHang.Visible = true;

                //Add data
                foreach (Chi_Tiet_Gio_Hang item in gioHang)
                {
                    string urlAnh = db.TRAI_CAYs.Where(p => p.Ma_Trai_Cay == item.Ma_Trai_Cay).FirstOrDefault().Url_Anh,
                        tenTC = db.TRAI_CAYs.Where(p => p.Ma_Trai_Cay == item.Ma_Trai_Cay).FirstOrDefault().Ten_Trai_Cay;

                    divDataGioHang.Controls.Add(createChiTietGioHangHtml(urlAnh, tenTC, item.Don_Gia_Xuat, item.So_Luong_Xuat, item.Ma_Trai_Cay));
                }

                calculateTongTien();
            }
            else
            {
                txtGioHangTrong.Visible = true;
                divGioHang.Visible = false;
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
                return null;
            }
            return null;
        }

        protected HtmlGenericControl createChiTietGioHangHtml(string urlAnh, string tenTraiCay, string donGia, string soLuong, string maTraiCay)
        {                      
            //Card detal container
            HtmlGenericControl div = new HtmlGenericControl("div");
            div.ID = maTraiCay;
            div.Attributes.Add("class", "row cart-detail text-center");

            //Fruit Image
            div.InnerHtml += "<div class=\"col-md-2 align-self-center\"><img class=\"img-fruit\" src=\""+ urlAnh +"\"/></div>";
            //Fruit Name
            div.InnerHtml += "<div class=\"col-md-3 align-self-center\"><span>" + tenTraiCay + "</span></div>";
            //Fruit Selling Price
            div.InnerHtml += "<div class=\"col-md-2 align-self-center\"><span>" + string.Format("{0:#,##0}", Int32.Parse(donGia)) + moneySuffix + "</span></div>";
            //Buying Quantity
            HtmlGenericControl divColSoLuong = new HtmlGenericControl("div");
            divColSoLuong.Attributes.Add("class", "col-md-2 align-self-center");
            div.Controls.Add(divColSoLuong);
            var txtSoLuong = new TextBox();
            txtSoLuong.ID = "txtSoLuong" + maTraiCay;
            txtSoLuong.CssClass = "fruit-quantity-width";
            txtSoLuong.Attributes.Add("type", "number");
            txtSoLuong.Attributes.Add("min", "1");
            txtSoLuong.Attributes.Add("step", "1");
            txtSoLuong.Text = soLuong;
            divColSoLuong.Controls.Add(txtSoLuong);

            HtmlGenericControl divBtn = new HtmlGenericControl("div");
            divBtn.Attributes.Add("class", "col-md-3 align-self-center");

            HtmlGenericControl divBtnRow = new HtmlGenericControl("div");
            divBtnRow.Attributes.Add("class", "row");

            //Cập nhật
            HtmlGenericControl divColCapNhat = new HtmlGenericControl("div");
            divColCapNhat.Attributes.Add("class", "col-md-7");

            var btnCapNhat = new LinkButton();
            btnCapNhat.ID = "btnCapNhatSP" + maTraiCay;
            btnCapNhat.CommandArgument = maTraiCay;
            btnCapNhat.CssClass = "fas fa-sync-alt";
            btnCapNhat.ForeColor = System.Drawing.Color.FromArgb(255, 13, 15, 16);
            btnCapNhat.Command += btnCapNhatSP_ServerClick;

            //Xóa
            HtmlGenericControl divColXoaKhoiGioHang = new HtmlGenericControl("div");
            divColXoaKhoiGioHang.Attributes.Add("class", "col-md-3");

            var btnXoaKhoiGioHang = new LinkButton();
            btnXoaKhoiGioHang.ID = "btnXoaKhoiGioHang" + maTraiCay;
            btnXoaKhoiGioHang.CommandArgument = maTraiCay;
            btnXoaKhoiGioHang.CssClass = "fas fa-times";
            btnXoaKhoiGioHang.ForeColor = System.Drawing.Color.FromArgb(255, 13, 15, 16);
            btnXoaKhoiGioHang.Command += btnXoaKhoiGioHang_ServerClick;


            divColCapNhat.Controls.Add(btnCapNhat);
            divColXoaKhoiGioHang.Controls.Add(btnXoaKhoiGioHang);
            divBtnRow.Controls.Add(divColCapNhat);
            divBtnRow.Controls.Add(divColXoaKhoiGioHang);
            divBtn.Controls.Add(divBtnRow);
            div.Controls.Add(divBtn);

            return div;
        }

        protected void btnXoaKhoiGioHang_ServerClick(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = sender as LinkButton;
                divDataGioHang.Controls.Remove(FindControlRecursive(divDataGioHang, btn.CommandArgument));

                gioHang.Remove(gioHang.Where(p => p.Ma_Trai_Cay == btn.CommandArgument).FirstOrDefault());
                if (gioHang.Count == 0)
                {
                    txtGioHangTrong.Visible = true;
                    divGioHang.Visible = false;
                }

                //Delete from cookie
                string json = JsonConvert.SerializeObject(gioHang);
                HttpCookie cookie = new HttpCookie("Gio_Hang");
                cookie.Value = json;

                // Set the cookie expiration date.
                cookie.Expires = DateTime.Now.AddDays(1);

                Response.Cookies.Add(cookie);

                calculateTongTien();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnCapNhatSP_ServerClick(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = sender as LinkButton;

                TextBox txtSoLuong = FindControlRecursive(divDataGioHang, "txtSoLuong" + btn.CommandArgument) as TextBox;
                gioHang.FirstOrDefault(p => p.Ma_Trai_Cay == btn.CommandArgument).So_Luong_Xuat = txtSoLuong.Text;

                //Update cookie
                string json = JsonConvert.SerializeObject(gioHang);
                HttpCookie cookie = new HttpCookie("Gio_Hang");
                cookie.Value = json;

                // Set the cookie expiration date.
                cookie.Expires = DateTime.Now.AddDays(1);

                Response.Cookies.Add(cookie);

                calculateTongTien();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        protected Control FindControlRecursive(Control root, string id)
        {
            if (root.ID == id)
            {
                return root;
            }

            foreach (Control c in root.Controls)
            {
                Control t = FindControlRecursive(c, id);
                if (t != null)
                {
                    return t;
                }
            }

            return null;
        }

        protected void calculateTongTien()
        {
            long sum = 0;
            foreach(Chi_Tiet_Gio_Hang item in gioHang)
            {
                sum += Int32.Parse(item.Don_Gia_Xuat) * Int32.Parse(item.So_Luong_Xuat);
            }
            txtTongCong.InnerText = string.Format("{0:#,##0}", sum) + moneySuffix;
        }

        protected void btnCheckOut_Click(object sender, EventArgs e)
        {
            try
            {
                FruitDataDataContext db = new FruitDataDataContext();

                string count = string.Format("{0, 0:D3}", db.DON_HANGs.Count() + 1);

                //Create new order
                var donHang = new DON_HANG();
                donHang.Ma_Don_Hang = "DH" + count;
                donHang.Ma_Chi_Tiet_DH = ""; //WTF chỗ này đáng lẽ ko có
                donHang.Ngay_Dat = DateTime.Now;
                //Sửa lại chỗ này, mấy cái này null éo dc
                donHang.Hinh_Thuc_Thanh_Toan = 0;
                donHang.Tinh_Trang = 0;
                donHang.Ma_Khach_Hang = "KH001";

                //Create new order details
                int countCTDH = db.CHI_TIET_DON_HANGs.Count();
                foreach (Chi_Tiet_Gio_Hang item in gioHang)
                {
                    var ctdh = new CHI_TIET_DON_HANG();
                    countCTDH++;
                    ctdh.Ma_Chi_Tiet_DH = "CTDH" + string.Format("{0, 0:D3}", countCTDH);
                    ctdh.Ma_Don_Hang = donHang.Ma_Don_Hang;
                    ctdh.Ma_Trai_Cay = item.Ma_Trai_Cay;
                    ctdh.Don_Gia_Xuat = Int32.Parse(item.Don_Gia_Xuat);
                    ctdh.So_Luong_Xuat = Int32.Parse(item.So_Luong_Xuat);

                    db.CHI_TIET_DON_HANGs.InsertOnSubmit(ctdh); 
                }
                db.DON_HANGs.InsertOnSubmit(donHang);

                db.SubmitChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}