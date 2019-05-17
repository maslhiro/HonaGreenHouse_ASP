using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


namespace SellingFruitsWeb.Admin
{
    public partial class ThemSanPham : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {

            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string strErr = checkInput();

            if(strErr.Length != 0)
            {
                // Show thong bao 
                alertError.InnerHtml = @"<div class='alert alert-danger'> <strong> Warning !</strong>"+strErr+" không được để trống</div>";
                ScriptManager.RegisterStartupScript(this, GetType(), "showModalThemTC", "<script>$('#modalThemTC').modal('show');</script>", false);
                return;
            }

            alertError.InnerHtml = @"<div class='alert alert-danger'> <strong>Éc éc!</strong> Thêm trái cây thất bại </div>";
            ScriptManager.RegisterStartupScript(this, GetType(), "showModalThemTC", "<script>$('#modalThemTC').modal('show');</script>", false);
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            // Clear Input
            txtTenTraiCay.Value = "";
            txtXuatXu.Value = "";
            txtSoLuongNhap.Value = "";
            txtDonViTinh.Value = "";
            txtDonGia.Value = "";
            selLoaiTraiCay.SelectedIndex = 0;
            txtMoTa.Value = "";


            // Xoa alert error ( neu co )
            alertError.InnerHtml = "";

            // Goi Script dong modal
            ScriptManager.RegisterStartupScript(this, GetType(), "hideModalThemTC", "<script>$('#myModal').modal('hide');</script>", false);
        }

        protected void btnReload_Click(object sender, EventArgs e)
        {
        }

        private string checkInput()
        {
            string strErr = "";

            if (txtTenTraiCay.Value == "")
            {
                strErr += "Tên trái cây ,";
            }
            if (txtDonGia.Value == "")
            {
                strErr += "Đơn giá ,";
            }
            if (txtDonViTinh.Value == "")
            {
                strErr += "Đơn vị tính ,";
            }
            if (txtSoLuongNhap.Value == "")
            {
                strErr += "Số lượng nhập ";
            }

            if(strErr.Length != 0)  strErr.Substring(strErr.Length - 1);

            return strErr;
        }
    }
}