using Newtonsoft.Json;
using SellingFruitsWeb.DTO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace SellingFruitsWeb.Api
{
    /// <summary>
    /// Summary description for ThongKeNhap
    /// </summary>
    public class ThongKeNhap : IHttpHandler
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
                // Get list log nhap
                case 1:
                    object_Response = new Object_Response();
                    ketQua = getListNhap(context);
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
                // Get list log nhap theo ngay
                case 2:
                    object_Response = new Object_Response();
                    ketQua = getListNhapTheoThoiGian(context);
                    switch (ketQua)
                    {
                      
                        // Thong ke theo ngay thanh cong
                        case 0:
                            break;
                        // Data = null
                        case 1:
                            object_Response.Status_Code = 1;
                            object_Response.Status_Text = "Ngày bắt đầu không được lớn hơn ngày kết thúc";
                            object_Response.Data = "";

                            context.Response.ContentType = "text/json";
                            context.Response.Write(JsonConvert.SerializeObject(object_Response));
                            break;
                        //Lỗi ngày bắt đầu lớn hơn ngày kết thúc
                        case 2:
                            object_Response.Status_Code = 2;
                            object_Response.Status_Text = "Vui lòng nhập thời gian bắt đầu, kết thúc";
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

        private int getListNhap(HttpContext context)
        {
            try
            {
                long total = 0;
                var list = new List<Thong_Ke_Nhap>();

                foreach (LOG_NHAP_TC item in db.LOG_NHAP_TCs)
                {
                    var thongKe = new Thong_Ke_Nhap();

                    thongKe.Auto_ID = item.Auto_ID;
                    thongKe.Ma_Trai_Cay = item.Ma_Trai_Cay;
                    thongKe.Thoi_Gian = item.Thoi_Gian.ToString("hh:mm tt - dd/MM/yyyy");
                    thongKe.Tong_Tien_Nhap = item.Tong_Tien_Nhap;
                    thongKe.So_Luong_Nhap = item.So_Luong_Nhap;
                    thongKe.Don_Gia_Nhap = item.Don_Gia_Nhap;

                    //Chi tiet trai cay
                    var traiCay = db.TRAI_CAYs.Where(p => p.Ma_Trai_Cay == item.Ma_Trai_Cay).FirstOrDefault();
                    thongKe.Ten_Trai_Cay = traiCay.Ten_Trai_Cay;
                    thongKe.Don_Vi_Tinh = traiCay.Don_Vi_Tinh;
                    thongKe.Xuat_Xu = traiCay.Xuat_Xu;

                    var loaiTraiCay = db.LOAI_TRAI_CAYs.Where(p => p.Ma_Loai_Trai_Cay == traiCay.Loai_ID).FirstOrDefault();

                    thongKe.Ten_Loai_Trai_Cay = loaiTraiCay.Ten_Loai_Trai_Cay;
                    total += item.Tong_Tien_Nhap;

                    list.Add(thongKe);
                }

                object_Response.Status_Code = 0;
                object_Response.Status_Text = total.ToString();
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

        private int getListNhapTheoThoiGian(HttpContext context)
        {
            try
            {
                string From_Date = context.Request.QueryString["From_Date"];
                string To_Date = context.Request.QueryString["To_Date"];

                int check = checkDateTime(From_Date, To_Date);

                if (check != 0) return check;

                DateTime FromDate = DateTime.ParseExact(From_Date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime ToDate = DateTime.ParseExact(To_Date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                var total = 0;
                var listResult = new List<Thong_Ke_Nhap>();
                var listLogNhap = db.LOG_NHAP_TCs.Where(p => p.Thoi_Gian <= ToDate && p.Thoi_Gian >= FromDate);

                foreach(LOG_NHAP_TC item in listLogNhap)
                {
                    var thongKeNhap = new Thong_Ke_Nhap();
                    thongKeNhap.Auto_ID = item.Auto_ID;
                    thongKeNhap.Ma_Trai_Cay = item.Ma_Trai_Cay;
                    thongKeNhap.So_Luong_Nhap = item.So_Luong_Nhap;
                    thongKeNhap.Don_Gia_Nhap = item.Don_Gia_Nhap;
                    thongKeNhap.Tong_Tien_Nhap = item.Tong_Tien_Nhap;
                    thongKeNhap.Thoi_Gian = item.Thoi_Gian.ToShortDateString();

                    total += item.Tong_Tien_Nhap;
                    // Chi tiet trai cay
                    var traiCay = db.TRAI_CAYs.Where(p => p.Ma_Trai_Cay == item.Ma_Trai_Cay).FirstOrDefault();
                    var loaiTraiCay = db.LOAI_TRAI_CAYs.Where(p => p.Ma_Loai_Trai_Cay == traiCay.Loai_ID).FirstOrDefault();

                    thongKeNhap.Ten_Loai_Trai_Cay = loaiTraiCay.Ten_Loai_Trai_Cay;
                    thongKeNhap.Ten_Trai_Cay = traiCay.Ten_Trai_Cay;
                    thongKeNhap.Xuat_Xu = traiCay.Xuat_Xu;
                    thongKeNhap.Don_Vi_Tinh = traiCay.Don_Vi_Tinh;

                    listResult.Add(thongKeNhap);
                }
                object_Response.Status_Code = 0;
                object_Response.Status_Text = total.ToString();
                object_Response.Data = listResult;

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

        private int checkDateTime( String fromDate, String toDate)
        {
            try
            {
                // Kiem tra fromDate va toDate co gia tri ?
                if (fromDate.Length == 0 || toDate.Length == 0) return 2;

                // Parse string => Datetime
                DateTime FromDate = DateTime.ParseExact(fromDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime ToDate = DateTime.ParseExact(toDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                // Compare Datetime
                int compare = DateTime.Compare(FromDate, ToDate);
                //Ngay bat dau lon hon ngay ket thuc
                if (compare > 0) return 1;

                return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return -1;
            }
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