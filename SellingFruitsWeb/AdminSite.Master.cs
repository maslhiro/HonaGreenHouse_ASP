using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SellingFruitsWeb
{
    public partial class AdminSite : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["username"] != null)
            {
                //var value = Request.Cookies["key"].Value;
            }
            else
            {
                Response.Redirect("/Admin/Login.aspx");
            }
        }
    }
}