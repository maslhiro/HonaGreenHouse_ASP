using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SellingFruitsWeb.Entity;

namespace SellingFruitsWeb
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var HonaModel = new HonaModel();
            var re = HonaModel.TRAI_CAY.First();
            Console.WriteLine(re.Ten_Trai_Cay);
        }
    }
}