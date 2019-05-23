using Newtonsoft.Json;
using SellingFruitsWeb.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellingFruitsWeb.Api
{
    /// <summary>
    /// Summary description for GetListTraiCay
    /// </summary>
    public class GetListTraiCay : IHttpHandler
    {
        private FruitDataDataContext db; 
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
            if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
            {
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin:", "origin url of your site");
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST");
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept");
                HttpContext.Current.Response.AddHeader("Access-Control-Max-Age", "1728000");
                HttpContext.Current.Response.End();
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            db = new FruitDataDataContext();
            // Check DataType 
            int dataType = int.Parse(context.Request.QueryString["DataType"]);
            switch (dataType)
            {
                // Get list trai cay 
                case 1:
                    getListTraiCay(context);
                    break;
                // Xoa trai cay by id
                case 2:
                    break;
                default: break;
            }

        }

        private void getListTraiCay(HttpContext context)
        {

            var listTraiCay = db.TRAI_CAYs.Where(p => p.Ma_Trai_Cay != "");

            var list = new List<Trai_Cay>();
            Trai_Cay trai_Cay;
            foreach (TRAI_CAY item in listTraiCay.ToList())
            {
                // Truy xuat ten loai trai cay tu ma tuong ung
                String tenLoaiTC = db.LOAI_TRAI_CAYs.Where(p => p.Ma_Loai_Trai_Cay == item.Loai_ID).FirstOrDefault().Ten_Loai_Trai_Cay;

                trai_Cay = new Trai_Cay();

                trai_Cay.Ma_Trai_Cay = item.Ma_Trai_Cay;
                trai_Cay.Ten_Trai_Cay = item.Ten_Trai_Cay;
                trai_Cay.So_Luong = item.So_Luong;
                trai_Cay.Don_Gia = item.Don_Gia;
                trai_Cay.Don_Vi_Tinh = item.Don_Vi_Tinh;
                trai_Cay.Xuat_Xu = item.Xuat_Xu;
                trai_Cay.Mo_Ta = item.Mo_Ta;
                trai_Cay.Loai_ID = item.Loai_ID;
                trai_Cay.Ten_Loai_TC = tenLoaiTC;

                list.Add(trai_Cay);
            }

            var json = JsonConvert.SerializeObject(list);
            context.Response.ContentType = "text/json";
            context.Response.Write(json);
        }

        private int xoaTraiCayByID(HttpContext context)
        {
            try
            {
                string maTraiCay = context.Request.QueryString["MaTraiCay"];

                if (maTraiCay.Length == 0) return 1;

                var traiCay = db.TRAI_CAYs.Where(p => p.Ma_Trai_Cay == maTraiCay).FirstOrDefault();
                if (traiCay == null) return 2;

                db.TRAI_CAYs.DeleteOnSubmit(traiCay);
                db.SubmitChanges();
                return 0;
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception xoaTraiCayById",e);
            }
            return -1;
           

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}