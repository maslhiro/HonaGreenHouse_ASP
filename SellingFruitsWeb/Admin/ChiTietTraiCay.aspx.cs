using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SellingFruitsWeb.Admin
{
    public partial class ChiTietTraiCay : System.Web.UI.Page
    {
        private FruitDataDataContext db;
        protected void Page_Load(object sender, EventArgs e)
        {
                db = new FruitDataDataContext();
                loadData();

        }

        private void loadData()
        {
            string maTraiCay =  Request.QueryString["MaTraiCay"].ToString();
            title.InnerText = "Chi tiết trái cây " + maTraiCay;

            var traiCay = db.TRAI_CAYs.Where(p => p.Ma_Trai_Cay == maTraiCay).FirstOrDefault();
            txtMoTa.Value = traiCay.Mo_Ta;
            image.ImageUrl = traiCay.Url_Anh;

        }

        private int uploadImage()
        {
            if (imageUpload.PostedFile.FileName !="")
            {
                string fileName = Path.Combine(Server.MapPath("~/Image"), imageUpload.PostedFile.FileName);
                imageUpload.PostedFile.SaveAs(fileName);

                return 1;
            }
            else
            {
                return 0;
            }
        }

        private int saveTraiCay()
        {
            try
            {
                string maTraiCay = Request.QueryString["MaTraiCay"].ToString();

                var traiCay = db.TRAI_CAYs.Where(p => p.Ma_Trai_Cay == maTraiCay).FirstOrDefault();
                if (traiCay == null) return 2;

                traiCay.Mo_Ta = txtMoTa.Value;
                traiCay.Url_Anh = "/Image/" + imageUpload.PostedFile.FileName;

                db.SubmitChanges();

                return 1;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return 2;
            }
        }

        protected void btnSubmit_ServerClick(object sender, EventArgs e)
        {
            int upload = uploadImage();

            if(upload == 1)
            {
                int save = saveTraiCay();
                showAlert(save);
                if (save == 1) loadData();
            }
            else
            {
                showAlert(0);
            }
        }

        void showAlert(int code)
        {
            String text = "";
            switch (code)
            {
                case 0:
                    text = "Upload ảnh lỗi vui lòng thử lại";
                    break;
                case 1:
                    text = "Cập nhật chi tiết trái cây thành công";
                    break;
                default:
                    text = "Lỗi kết nối cơ sở dữ liệu";
                    break;
            }

            String script;
            if (code == 1) script = "<script>$('#alert').empty().append(`<div class='alert alert-danger'> <strong> Success!</strong > " + text + " </div>`);$('#alert').show(); $('#alert').delay(7000).slideUp(200, function () { $(this).alert('dispose'); });</script>";
            else
            script = "<script>$('#alert').empty().append(`<div class='alert alert-danger'> <strong> Warning!</strong > " + text + " </div>`);$('#alert').show(); $('#alert').delay(7000).slideUp(200, function () { $(this).alert('dispose'); });</script>";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertLoi", script, false);
        }

    }


}