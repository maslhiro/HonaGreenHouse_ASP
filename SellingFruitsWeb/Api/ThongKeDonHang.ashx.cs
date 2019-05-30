using Newtonsoft.Json;
using SellingFruitsWeb.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace SellingFruitsWeb.Api
{
    public class ThongKeDonHang : IHttpHandler
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
                // Get list log thanh toan
                case 1:
                    object_Response = new Object_Response();
                    ketQua = getListThanhToan(context);
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
                // Get list log thanh toan theo ngay
                case 2:
                    object_Response = new Object_Response();
                    ketQua = getListThanhToanTheoThoiGian(context);
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

        private int getListThanhToanTheoThoiGian(HttpContext context)
        {
            try
            {
                string strJson = new StreamReader(context.Request.InputStream).ReadToEnd();
                //deserialize the object
                Thoi_Gian_Thong_Ke thoi_Gian_Thong_Ke = JsonConvert.DeserializeObject<Thoi_Gian_Thong_Ke>(strJson);

                if (thoi_Gian_Thong_Ke == null) return 1;

                int check = checkThoiGianThongKe(thoi_Gian_Thong_Ke);

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

                var listThanhToan = db.LOG_THANH_TOANs.Where(p => 
                p.Thoi_Gian >= DateTime.Parse(thoi_Gian_Thong_Ke.From_Date) &&
                p.Thoi_Gian <= DateTime.Parse(thoi_Gian_Thong_Ke.To_Date));

                var list = new List<Thong_Ke_Don_Hang>();

                foreach (LOG_THANH_TOAN item in listThanhToan.ToList())
                {
                    var thongKe = new Thong_Ke_Don_Hang();

                    thongKe.Auto_ID = item.Auto_ID;
                    thongKe.Tong_Tien = item.Tong_Tien;
                    thongKe.Thoi_Gian = item.Thoi_Gian.ToString("hh: mm tt - dd / MM / yyyy");
                    thongKe.Ma_Don_Hang = item.Ma_Don_Hang;

                    //Chi tiet don hang
                    //var donHang = db.DON_HANGs.Where(p => p.Ma_Don_Hang == item.Ma_Don_Hang).FirstOrDefault();
                    //thongKe.Ma_Khach_Hang = donHang.Ma_Khach_Hang;
                    //thongKe.Hinh_Thuc_Thanh_Toan = donHang.Hinh_Thuc_Thanh_Toan;

                    //bug here

                    //thongKe.Ho_ten = donHang.CHI_TIET_CHUYEN_HANGs.FirstOrDefault(p => p.Ma_Don_Hang == item.Ma_Don_Hang).Ho_Ten;
                    //thongKe.So_Dien_Thoai = donHang.CHI_TIET_CHUYEN_HANGs.FirstOrDefault(p => p.Ma_Don_Hang == item.Ma_Don_Hang).So_Dien_Thoai;
                    //thongKe.Dia_Chi_Nhan = donHang.CHI_TIET_CHUYEN_HANGs.FirstOrDefault(p => p.Ma_Don_Hang == item.Ma_Don_Hang).Dia_Chi_Nhan;

                    list.Add(thongKe);
                }

                object_Response.Status_Code = 0;
                object_Response.Status_Text = "Thống kê đơn hàng thành công";
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

        private int getListThanhToan(HttpContext context)
        {
            try
            {
                var listThanhToan = db.LOG_THANH_TOANs.ToList();

                var list = new List<Thong_Ke_Don_Hang>();

                foreach (LOG_THANH_TOAN item in listThanhToan.ToList())
                {
                    var thongKe = new Thong_Ke_Don_Hang();

                    thongKe.Auto_ID = item.Auto_ID;
                    thongKe.Tong_Tien = item.Tong_Tien;
                    thongKe.Thoi_Gian = item.Thoi_Gian.ToString("hh: mm tt - dd / MM / yyyy");
                    thongKe.Ma_Don_Hang = item.Ma_Don_Hang;

                    //Chi tiet don hang
                    //var donHang = db.DON_HANGs.Where(p => p.Ma_Don_Hang == item.Ma_Don_Hang).FirstOrDefault();
                    //thongKe.Ma_Khach_Hang = donHang.Ma_Khach_Hang;
                    //thongKe.Hinh_Thuc_Thanh_Toan = donHang.Hinh_Thuc_Thanh_Toan;

                    //bug here

                    //thongKe.Ho_ten = donHang.CHI_TIET_CHUYEN_HANGs.FirstOrDefault(p => p.Ma_Don_Hang == item.Ma_Don_Hang).Ho_Ten;
                    //thongKe.So_Dien_Thoai = donHang.CHI_TIET_CHUYEN_HANGs.FirstOrDefault(p => p.Ma_Don_Hang == item.Ma_Don_Hang).So_Dien_Thoai;
                    //thongKe.Dia_Chi_Nhan = donHang.CHI_TIET_CHUYEN_HANGs.FirstOrDefault(p => p.Ma_Don_Hang == item.Ma_Don_Hang).Dia_Chi_Nhan;

                    list.Add(thongKe);
                }

                object_Response.Status_Code = 0;
                object_Response.Status_Text = "Thống kê đơn hàng thành công";
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

        private int getListThanhToanTheoThang(HttpContext context)
        {
            try
            {
                var listThanhToanTheoThang = db.LOG_THANH_TOANs.Where(p => p.Thoi_Gian.Month == DateTime.Now.Month && p.Thoi_Gian.Year == DateTime.Now.Year);

                var list = new List<Thong_Ke_Don_Hang>();

                foreach (LOG_THANH_TOAN item in listThanhToanTheoThang.ToList())
                {
                    var logThanhToan = new Thong_Ke_Don_Hang();

                    logThanhToan.Auto_ID = item.Auto_ID;
                    logThanhToan.Tong_Tien = item.Tong_Tien;
                    logThanhToan.Thoi_Gian = item.Thoi_Gian.ToString("hh: mm tt - dd / MM / yyyy");
                    logThanhToan.Ma_Don_Hang = item.Ma_Don_Hang;

                    list.Add(logThanhToan);
                }

                object_Response.Status_Code = 0;
                object_Response.Status_Text = "Thống kê đơn hàng thành công";
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

        private int getListThanhToanTheoNgay(HttpContext context)
        {
            try
            {
                var listThanhToanTheoNgay = db.LOG_THANH_TOANs.Where(p =>
                    p.Thoi_Gian.Date == DateTime.Now.Date &&
                    p.Thoi_Gian.Month == DateTime.Now.Month &&
                    p.Thoi_Gian.Year == DateTime.Now.Year);

                var list = new List<Thong_Ke_Don_Hang>();

                foreach (LOG_THANH_TOAN item in listThanhToanTheoNgay.ToList())
                {
                    var logThanhToan = new Thong_Ke_Don_Hang();

                    logThanhToan.Auto_ID = item.Auto_ID;
                    logThanhToan.Tong_Tien = item.Tong_Tien;
                    logThanhToan.Thoi_Gian = item.Thoi_Gian.ToString("hh:mm tt - dd/MM/yyyy");
                    logThanhToan.Ma_Don_Hang = item.Ma_Don_Hang;

                    list.Add(logThanhToan);
                }

                object_Response.Status_Code = 0;
                object_Response.Status_Text = "Thống kê đơn hàng thành công";
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

        private int checkThoiGianThongKe(Thoi_Gian_Thong_Ke thoi_Gian_Thong_Ke)
        {
            DateTime fromDate, toDate;
            if (!DateTime.TryParse(thoi_Gian_Thong_Ke.From_Date, out fromDate) || !DateTime.TryParse(thoi_Gian_Thong_Ke.To_Date, out toDate))
            {
                //Ngay khong hop le
                return 1;
            }

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