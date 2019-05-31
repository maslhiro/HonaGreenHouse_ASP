using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SellingFruitsWeb.Admin
{
    public partial class Login : System.Web.UI.Page
    {
        private FruitDataDataContext db;

        protected void Page_Load(object sender, EventArgs e)
        {
            db = new FruitDataDataContext();
        }

        protected void login_ServerClick(object sender, EventArgs e)
        {
            int check = check_Account();
            if (check != 0)
            {
                showAlert(check);
            }
            else
            {
                Response.Redirect("/Admin/ThemTraiCay.aspx");

                // Add cookie 
                HttpCookie ck = new HttpCookie("username");
                ck.Value = txtUsername.Value;
                ck.Expires = DateTime.Now.AddDays(15);
                Response.Cookies.Add(ck);
            }
           
        }

        private int check_Account()
        {
            try
            {
                String tenDangNhap = txtUsername.Value;
                String matKhau = txtPassword.Value;
                if (tenDangNhap.Length == 0 || matKhau.Length == 0) return 1;

                var admins = db.ADMINs.Where(x => x.Ten_Dang_Nhap == tenDangNhap).FirstOrDefault();
                if (admins == null) return 2;

                if (admins.Mat_Khau == matKhau) return 0;
                return 3;
            }
            catch ( Exception e)
            {
                Console.WriteLine(e);
                return -1;
            }
           
        }

        void showAlert(int code)
        {
            String text = "";
            switch (code)
            {
                case 1:
                    text = "Username hoặc mật khẩu không được để trống";
                    break;
                case 2:
                    text = "Tài khoản không tồn tại";
                    break;
                case 3:
                    text = "Mật khẩu không chính xác";
                    break;
                default:
                    text = "Lỗi kết nối cơ sở dữ liệu";
                    break;
            }

            String script = "<script>$('#alert').empty().append(`<div class='alert alert-danger'> <strong> Warning!</strong > " + text + " </div>`);$('#alert').show(); $('#alert').delay(7000).slideUp(200, function () { $(this).alert('dispose'); });</script>";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertLoi", script, false);
        }
    }
}