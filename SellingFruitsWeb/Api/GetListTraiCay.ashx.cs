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
        private FruitDataDataContext db = new FruitDataDataContext();
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
            var listTraiCay = db.TRAI_CAYs.Where(p => p.Ma_Trai_Cay != "");

            var list = new List<Trai_Cay>();
            Trai_Cay trai_Cay;
            foreach (TRAI_CAY item in listTraiCay.ToList())
            {
                trai_Cay = new Trai_Cay(item.Ma_Trai_Cay, item.Ten_Trai_Cay, item.So_Luong, item.Don_Gia, item.Don_Vi_Tinh, item.Xuat_Xu, item.Mo_Ta, item.Loai_ID);
                list.Add(trai_Cay);
            }

            var json = JsonConvert.SerializeObject(list);
            context.Response.ContentType = "text/json";
            context.Response.Write(json);
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