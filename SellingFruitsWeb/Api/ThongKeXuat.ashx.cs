using Newtonsoft.Json;
using SellingFruitsWeb.DTO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using SellingFruitsWeb.Extensions;

namespace SellingFruitsWeb.Api
{
    /// <summary>
    /// Summary description for ThongKeXuat
    /// </summary>
    public class ThongKeXuat : IHttpHandler
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
                // Get list don hang
                case 1:
                    object_Response = new Object_Response();
                    ketQua = getListXuat(context);
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
                    ketQua = getListXuatTheoThoiGian(context);
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

        private int getListXuat(HttpContext context)
        {
            try
            {
                long total = 0;
                var listResult = new List<Chi_Tiet_Don_Hang>();

                // Lấy ra list đơn hàng đã cập nhât bằng chứng thanh toán
                var listDonHang = db.DON_HANGs.Where(p => p.Bang_Chung_Thanh_Toan != null);
                var listChiTietDonHang = db.CHI_TIET_DON_HANGs.Join(listDonHang, ct => ct.Ma_Don_Hang, dh => dh.Ma_Don_Hang,
                    (ct, dh) => new { ct, dh });

                foreach (var item in listChiTietDonHang)
                {
                    var ctdh = new Chi_Tiet_Don_Hang();

                    ctdh.Ma_Chi_Tiet_DH = item.ct.Ma_Chi_Tiet_DH;
                    ctdh.Ma_Don_Hang = item.ct.Ma_Don_Hang;
                    ctdh.Thoi_Gian = item.dh.Ngay_Dat.ToString("hh:mm tt - dd/MM/yyyy"); ;
                    ctdh.So_Luong_Xuat = item.ct.So_Luong_Xuat;
                    ctdh.Ma_Trai_Cay = item.ct.Ma_Trai_Cay;
                    ctdh.Don_Gia_Xuat = item.ct.Don_Gia_Xuat;
                    ctdh.Tong_Tien_Xuat = item.ct.So_Luong_Xuat * item.ct.Don_Gia_Xuat;
                    //Chi tiet trai cay
                    var traiCay = db.TRAI_CAYs.Where(p => p.Ma_Trai_Cay == item.ct.Ma_Trai_Cay).FirstOrDefault();

                    ctdh.Ten_Trai_Cay =traiCay.Ten_Trai_Cay;
                    ctdh.Don_Vi_Tinh = traiCay.Don_Vi_Tinh;
                    ctdh.Xuat_Xu = traiCay.Xuat_Xu;
                    

                    listResult.Add(ctdh);
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

        private int getListXuatTheoThoiGian(HttpContext context)
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
                var listResult = new List<Chi_Tiet_Don_Hang>();
                // Lấy ra list đơn hàng đã cập nhât bằng chứng thanh toán
                var listDonHang = db.DON_HANGs.Where(p => p.Bang_Chung_Thanh_Toan != null && p.Ngay_Dat <= ToDate && p.Ngay_Dat >= FromDate);
                var listChiTietDonHang = db.CHI_TIET_DON_HANGs.Join(listDonHang, ct => ct.Ma_Don_Hang, dh => dh.Ma_Don_Hang,
                    (ct, dh) => new { ct, dh });

                foreach (var item in listChiTietDonHang)
                {
                    var ctdh = new Chi_Tiet_Don_Hang();

                    ctdh.Ma_Chi_Tiet_DH = item.ct.Ma_Chi_Tiet_DH;
                    ctdh.Ma_Don_Hang = item.ct.Ma_Don_Hang;
                    ctdh.So_Luong_Xuat = item.ct.So_Luong_Xuat;
                    ctdh.Ma_Trai_Cay = item.ct.Ma_Trai_Cay;
                    ctdh.Don_Gia_Xuat = item.ct.Don_Gia_Xuat;
                    ctdh.Tong_Tien_Xuat = item.ct.So_Luong_Xuat * item.ct.Don_Gia_Xuat;
                    ctdh.Thoi_Gian = item.dh.Ngay_Dat.ToString("hh:mm tt - dd/MM/yyyy"); ;
                    //Chi tiet trai cay
                    var traiCay = db.TRAI_CAYs.Where(p => p.Ma_Trai_Cay == item.ct.Ma_Trai_Cay).FirstOrDefault();

                    ctdh.Ten_Trai_Cay = traiCay.Ten_Trai_Cay;
                    ctdh.Don_Vi_Tinh = traiCay.Don_Vi_Tinh;
                    ctdh.Xuat_Xu = traiCay.Xuat_Xu;


                    listResult.Add(ctdh);
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

        private int checkDateTime(String fromDate, String toDate)
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