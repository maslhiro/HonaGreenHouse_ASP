using Newtonsoft.Json;
using SellingFruitsWeb.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellingFruitsWeb.Api
{
    /// <summary>
    /// Summary description for GetListLoaiTraiCay
    /// </summary>
    public class GetListLoaiTraiCay : IHttpHandler
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
            var listLoaiTraiCay = db.LOAI_TRAI_CAYs.Where(p => p.Ma_Loai_Trai_Cay != "");

            var list = new List<Loai_Trai_Cay>();
            Loai_Trai_Cay loai_Trai_Cay;
            foreach (LOAI_TRAI_CAY item in listLoaiTraiCay.ToList())
            {
                loai_Trai_Cay = new Loai_Trai_Cay(item.Ma_Loai_Trai_Cay, item.Ten_Loai_Trai_Cay);
                list.Add(loai_Trai_Cay);
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