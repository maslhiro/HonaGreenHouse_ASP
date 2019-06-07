using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SellingFruitsWeb.Admin
{
    public partial class ChiTietDonHang : System.Web.UI.Page
    {
        private FruitDataDataContext db;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadChiTietGiaoHang();
        }

        private void LoadChiTietGiaoHang()
        {
            db = new FruitDataDataContext();
            string maDonHang = Request.QueryString["MaDonHang"].ToString();

            try
            {
                var donHang = db.DON_HANGs.Where(p => p.Ma_Don_Hang == maDonHang).FirstOrDefault();

                txtHoTen.Value = donHang.Ho_Ten;
                txtDiaChiNhan.Value = donHang.Dia_Chi_Nhan;
                txtSoDienThoai.Value = donHang.So_Dien_Thoai;

                image.Src = donHang.Bang_Chung_Thanh_Toan;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }
    }
}