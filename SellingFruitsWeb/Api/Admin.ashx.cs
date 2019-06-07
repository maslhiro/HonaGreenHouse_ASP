using Newtonsoft.Json;
using SellingFruitsWeb.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using SellingFruitsWeb.Extensions;

namespace SellingFruitsWeb.Api
{
    /// <summary>
    /// Summary description for GetListDonHang
    /// </summary>
    public class Admin : IHttpHandler
    {
        private FruitDataDataContext db;
        private Object_Response object_Response;

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
            int ketQua;
            // Check DataType 
            int dataType = int.Parse(context.Request.QueryString["DataType"]);
            switch (dataType)
            {
                // Check admin in db
                case 1:
                    object_Response = new Object_Response();
                    ketQua = checkAdmin(context);
                    switch (ketQua)
                    {
                        // Get list thanh cong
                        case 0:
                            break;
                        // Khong nhap username or pass
                        case 1:
                            object_Response.Status_Code = 1;
                            object_Response.Status_Text = "Username hoặc Password không được để trống";
                            object_Response.Data = "";

                            context.Response.ContentType = "text/json";
                            context.Response.Write(JsonConvert.SerializeObject(object_Response));
                            break;
                        case 2:
                            object_Response.Status_Code = 2;
                            object_Response.Status_Text = "Tài khoản không tồn tại";
                            object_Response.Data = "";

                            context.Response.ContentType = "text/json";
                            context.Response.Write(JsonConvert.SerializeObject(object_Response));
                            break;
                        case 3:
                            object_Response.Status_Code = 3;
                            object_Response.Status_Text = "Mật khẩu không chính xác";
                            object_Response.Data = "";

                            context.Response.ContentType = "text/json";
                            context.Response.Write(JsonConvert.SerializeObject(object_Response));
                            break;
                        default:
                            object_Response.Status_Code = -1;
                            object_Response.Status_Text = "Lỗi kết nối cơ sở dữ liệu";
                            object_Response.Data = "";

                            context.Response.ContentType = "text/json";
                            context.Response.Write(JsonConvert.SerializeObject(object_Response));
                            break;
                    }
                    break;
                default: break;
            }

        }

        private int checkAdmin(HttpContext context)
        {
            try
            {
                string tenDangNhap = context.Request.QueryString["Username"];
                string matKhau = context.Request.QueryString["Password"];


                if (tenDangNhap.Length == 0 || matKhau.Length == 0) return 1;

                var admins = db.ADMINs.Where(x => x.Ten_Dang_Nhap == tenDangNhap).FirstOrDefault();
                if (admins == null) return 2;

                if (admins.Mat_Khau == matKhau) return 0;
                return 3;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception huyDonHangById", e);
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