using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

using SellingFruitsWeb.Entity;

namespace SellingFruitsWeb.Admin
{
    public partial class ThemSanPham : System.Web.UI.Page
    {
        HonaModel honaModel;

        protected void Page_Load(object sender, EventArgs e)
        {
            honaModel = new HonaModel();
            var list = honaModel.TRAI_CAY.Where(p => p.Loai_ID != "");
            List<TRAI_CAY> listTraiCay = list.ToList();
            //loadTable(listTraiCay);
        }

        //private void loadTable( List<TRAI_CAY> listTraiCay)
        //{
        //    HtmlTableRow row;
        //    // Mã
        //    HtmlTableCell cell01;
        //    //Tên trái cây
        //    HtmlTableCell cell02;
        //    // Loại  trái cây
        //    HtmlTableCell cell03;
        //    // Số lượng tồn
        //    HtmlTableCell cell04;
        //    // Đơn vị tính
        //    HtmlTableCell cell05;
        //    // Đơn giá
        //    HtmlTableCell cell06;

        //    foreach (var traiCay in listTraiCay)
        //    {
        //        row = new HtmlTableRow();
        //        // Mã
        //         cell01 = new HtmlTableCell() { InnerText =  traiCay.Ma_Trai_Cay};
        //        //Tên trái cây
        //         cell02 = new HtmlTableCell() { InnerText = traiCay.Ten_Trai_Cay };
        //        // Loại  trái cây
        //         cell03 = new HtmlTableCell() { InnerText = traiCay.Loai_ID };
        //        // Số lượng tồn
        //         cell04 = new HtmlTableCell() { InnerText = traiCay.So_Luong.ToString() };
        //        // Đơn vị tính
        //         cell05 = new HtmlTableCell() { InnerText = traiCay.Don_Vi_Tinh };
        //        // Đơn giá
        //         cell06 = new HtmlTableCell() { InnerText = traiCay.Don_Gia.ToString() };


        //        row.Cells.Add(cell01);
        //        row.Cells.Add(cell02);
        //        row.Cells.Add(cell03);
        //        row.Cells.Add(cell04);
        //        row.Cells.Add(cell05);
        //        row.Cells.Add(cell06);

        //        dataTable.Rows.Add(row);
        //    }
        //}
    }
}