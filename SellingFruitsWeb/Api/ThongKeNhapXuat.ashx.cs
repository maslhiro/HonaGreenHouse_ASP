using Newtonsoft.Json;
using SellingFruitsWeb.DTO;
using SellingFruitsWeb.Extensions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace SellingFruitsWeb.Api
{
    public class ThongKeNhapXuat : IHttpHandler
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
                // Get list log nhap xuat
                case 1:
                    object_Response = new Object_Response();
                    ketQua = getListNhapXuat(context);
                    switch (ketQua)
                    {
                        // Get list thanh cong
                        case 0:
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
                // Get list log nhap xuat theo ngay
                case 2:
                    object_Response = new Object_Response();
                    ketQua = getListNhapXuatTheoThoiGian(context);
                    switch (ketQua)
                    {
                        //Lỗi ngày bắt đầu lớn hơn ngày kết thúc
                        case -3:
                            break;
                        case -2:
                            break;
                        // Thong ke theo ngay thanh cong
                        case 0:
                            break;
                        // Data = null
                        case 1:
                            object_Response.Status_Code = 1;
                            object_Response.Status_Text = "Lỗi kết nối cơ sở dữ liệu";
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

        private int getListNhapXuatTheoThoiGian(HttpContext context)
        {
            try
            {
                string From_Date = context.Request.QueryString["From_Date"];
                string To_Date = context.Request.QueryString["To_Date"];

                if (From_Date.Length == 0 || To_Date.Length == 0)
                {
                    object_Response.Status_Code = -2;
                    object_Response.Status_Text = "Ngày không hợp lệ";
                    object_Response.Data = "";

                    context.Response.ContentType = "text/json";
                    context.Response.Write(JsonConvert.SerializeObject(object_Response));
                    return -2;
                }

                DateTime fromDate = DateTime.MinValue, toDate = DateTime.MinValue;
                int check = 0;
                try
                {
                    fromDate = DateTime.ParseExact(From_Date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    toDate = DateTime.ParseExact(To_Date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    check = checkThoiGianThongKe(fromDate, toDate);
                }
                catch (Exception)
                {
                    check = 1;
                }

                if (check != 0)
                {
                    if(check == 1)
                    {
                        object_Response.Status_Code = -2;
                        object_Response.Status_Text = "Ngày không hợp lệ";
                        object_Response.Data = "";

                        context.Response.ContentType = "text/json";
                        context.Response.Write(JsonConvert.SerializeObject(object_Response));
                        return -2;
                    }

                    object_Response.Status_Code = -3;
                    object_Response.Status_Text = "Ngày kết thúc phải sau ngày bắt đầu";
                    object_Response.Data = "";

                    context.Response.ContentType = "text/json";
                    context.Response.Write(JsonConvert.SerializeObject(object_Response));
                    return -3;
                }

                var listNhapXuat = db.LOG_NHAP_TCs.Where(p => p.Thoi_Gian >= fromDate && p.Thoi_Gian <= toDate);

                var list = new List<Thong_Ke_Nhap_Xuat>();

                foreach (LOG_NHAP_TC item in listNhapXuat.ToList())
                {
                    var thongKe = new Thong_Ke_Nhap_Xuat();

                    thongKe.Auto_ID = item.Auto_ID;
                    thongKe.Ma_Trai_Cay = item.Ma_Trai_Cay;
                    thongKe.Thoi_Gian = item.Thoi_Gian.ToString("hh:mm tt - dd/MM/yyyy");
                    thongKe.Tong_Tien = item.Tong_Tien_Nhap;
                    thongKe.So_Luong_Nhap = item.So_Luong_Nhap;

                    //Chi tiet trai cay
                    var traiCay = db.TRAI_CAYs.Where(p => p.Ma_Trai_Cay == item.Ma_Trai_Cay).FirstOrDefault();
                    thongKe.Ten_Trai_Cay = traiCay.Ten_Trai_Cay;
                    thongKe.Don_Gia = traiCay.Don_Gia_Nhap.ToString();
                    thongKe.Don_Vi_Tinh = traiCay.Don_Vi_Tinh;
                    thongKe.Xuat_Xu = traiCay.Xuat_Xu;

                    list.Add(thongKe);
                }

                object_Response.Status_Code = 0;
                object_Response.Status_Text = "Thống kê nhập xuất thành công";
                object_Response.Data = list;

                context.Response.ContentType = "text/json";
                context.Response.Write(JsonConvert.SerializeObject(object_Response));
                return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return -1;
            }

        }

        private int getListNhapXuat(HttpContext context)
        {
            try
            {
                var listNhapXuat = db.LOG_NHAP_TCs.ToList();

                var list = new List<Thong_Ke_Nhap_Xuat>();

                foreach (LOG_NHAP_TC item in listNhapXuat.ToList())
                {
                    var thongKe = new Thong_Ke_Nhap_Xuat();

                    thongKe.Auto_ID = item.Auto_ID;
                    thongKe.Ma_Trai_Cay = item.Ma_Trai_Cay;
                    thongKe.Thoi_Gian = item.Thoi_Gian.ToString("hh:mm tt - dd/MM/yyyy");
                    thongKe.Tong_Tien = item.Tong_Tien_Nhap;
                    thongKe.So_Luong_Nhap = item.So_Luong_Nhap;

                    //Chi tiet trai cay
                    var traiCay = db.TRAI_CAYs.Where(p => p.Ma_Trai_Cay == item.Ma_Trai_Cay).FirstOrDefault();
                    thongKe.Ten_Trai_Cay = traiCay.Ten_Trai_Cay;
                    thongKe.Don_Gia = traiCay.Don_Gia_Nhap.ToString();
                    thongKe.Don_Vi_Tinh = traiCay.Don_Vi_Tinh;
                    thongKe.Xuat_Xu = traiCay.Xuat_Xu;

                    list.Add(thongKe);
                }

                object_Response.Status_Code = 0;
                object_Response.Status_Text = "Thống kê nhập xuất thành công";
                object_Response.Data = list;

                context.Response.ContentType = "text/json";
                context.Response.Write(JsonConvert.SerializeObject(object_Response));
                return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return -1;
            }
        }

        private int checkThoiGianThongKe(DateTime fromDate, DateTime toDate)
        {
            //Ngay bat dau lon hon ngay ket thuc
            if (DateTime.Compare(fromDate, toDate) > 0)
                return 2;

            //Thoi gian thong ke binh thuong
            return 0;
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