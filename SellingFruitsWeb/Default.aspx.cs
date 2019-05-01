using SellingFruitsWeb.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SellingFruitsWeb
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var model = new HonaModel();
            var re = model.TRAI_CAY.First();
        }
    }
}