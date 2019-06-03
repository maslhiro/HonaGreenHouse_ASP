using Newtonsoft.Json;
using SellingFruitsWeb.DTO;
using SellingFruitsWeb.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using SellingFruitsWeb.Extensions;
using System.Globalization;

namespace SellingFruitsWeb.Api
{
    /// <summary>
    /// Summary description for GetListDonHang
    /// </summary>
    public class GetListDonHangMoi : IHttpHandler
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
                    ketQua = getListDonHangMoi(context);
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
                // Huy don hang by id
                case 2:
                    object_Response = new Object_Response();
                    ketQua = huyDonHangById(context);
                    switch (ketQua)
                    {
                        // Huy thanh cong
                        case 0:
                            object_Response.Status_Code = 0;
                            object_Response.Status_Text = "Hủy đơn hàng thành công";
                            object_Response.Data = "";
                            context.Response.ContentType = "text/json";
                            context.Response.Write(JsonConvert.SerializeObject(object_Response));

                            break;
                        // Ma don hang khong ton tai
                        case 1:
                            object_Response.Status_Code = 1;
                            object_Response.Status_Text = "Mã đơn hàng không tồn tại";
                            object_Response.Data = "";

                            context.Response.ContentType = "text/json";
                            context.Response.Write(JsonConvert.SerializeObject(object_Response));
                            break;
                        // Khong tim thay don hang
                        case 2:
                            object_Response.Status_Code = 2;
                            object_Response.Status_Text = "Mã đơn hàng không tồn tại";
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
                    // xác nhận đơn hàng
                case 3:
                    object_Response = new Object_Response();
                    ketQua = xacNhanDonHangById(context);
                    switch (ketQua)
                    {
                        // xác nhận đơn hàng thanh cong
                        case 0:
                            object_Response.Status_Code = 0;
                            object_Response.Status_Text = "Xác nhận đơn hàng thành công";
                            object_Response.Data = "";
                            context.Response.ContentType = "text/json";
                            context.Response.Write(JsonConvert.SerializeObject(object_Response));

                            break;
                        // Ma don hang khong ton tai
                        case 1:
                            object_Response.Status_Code = 1;
                            object_Response.Status_Text = "Mã đơn hàng không tồn tại";
                            object_Response.Data = "";

                            context.Response.ContentType = "text/json";
                            context.Response.Write(JsonConvert.SerializeObject(object_Response));
                            break;
                        // Khong tim thay don hang
                        case 2:
                            object_Response.Status_Code = 2;
                            object_Response.Status_Text = "Mã đơn hàng không tồn tại";
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
                //get Danh sach don hang
                case 4:
                    object_Response = new Object_Response();
                    ketQua = getDanhSachDonHang(context);
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
                //sua don hang theo id
                case 5:
                    object_Response = new Object_Response();
                    ketQua = suaChiTietDHByID(context);
                    switch (ketQua)
                    {
                        // Lỗi nhập ko đủ dữ liệu
                        case -2:
                            // gửi reponse trong chiTietDH
                            break;
                        // Update thanh cong
                        case 0:
                            object_Response.Status_Code = 0;
                            object_Response.Status_Text = "Update đơn hàng thành công";
                            object_Response.Data = "";

                            context.Response.ContentType = "text/json";
                            context.Response.Write(JsonConvert.SerializeObject(object_Response));

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

        private int getListDonHangMoi(HttpContext context)
        {
            try
            {
                var listDonHangMoi = db.DON_HANGs.Where(x => x.Tinh_Trang == 0);
                var list = new List<Don_Hang>();
                Don_Hang Don_Hang;
                foreach (DON_HANG item in listDonHangMoi.ToList())
                {
                    Don_Hang = new Don_Hang();
                    Don_Hang.Ma_Don_Hang = item.Ma_Don_Hang;
                    Don_Hang.Ngay_Dat = item.Ngay_Dat.ToString("dd/MM/yyyy");
                    Don_Hang.Hinh_Thuc_Thanh_Toan = item.Hinh_Thuc_Thanh_Toan;
                    Don_Hang.Hinh_Thuc_Thanh_Toan_String = item.Hinh_Thuc_Thanh_Toan.ToEnum<ThanhToan>().Text();
                    Don_Hang.Bang_Chung_Thanh_Toan = item.Bang_Chung_Thanh_Toan;
                    Don_Hang.Trinh_Trang = item.Tinh_Trang;
                    Don_Hang.Trinh_Trang_String= item.Tinh_Trang.ToEnum<DonHang>().Text();
                    list.Add(Don_Hang);
                }

                object_Response.Status_Code = 0;
                object_Response.Status_Text = "Get list đơn hàng thành công";
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

        private int huyDonHangById(HttpContext context)
        {
            try
            {
                string maDonHang = context.Request.QueryString["MaDonHang"];

                if (maDonHang.Length == 0) return 1;

                var donhang = db.DON_HANGs.Where(x => x.Ma_Don_Hang == maDonHang).FirstOrDefault();
                if (donhang == null) return 2;
                donhang.Tinh_Trang = (int)DonHang.DH_Cancel;
                db.SubmitChanges();
                return 0;
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception huyDonHangById",e);
            }
            return -1;
           

        }

        private int xacNhanDonHangById(HttpContext context)
        {
            try
            {
                string maDonHang = context.Request.QueryString["MaDonHang"];

                if (maDonHang.Length == 0) return 1;
                var donhang = db.DON_HANGs.Where(x => x.Ma_Don_Hang == maDonHang).FirstOrDefault();
                if (donhang == null) return 2;
                donhang.Tinh_Trang = (int)DonHang.DH_Processing;
                db.SubmitChanges();
                return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception xacNhanDonHangById", e);
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

        //get Danh sach don hang
        private int getDanhSachDonHang(HttpContext context)
        {
            try
            {
                var listDonHangMoi = db.DON_HANGs.Where(x => x.Tinh_Trang != 0);
                var list = new List<Don_Hang>();
                Don_Hang Don_Hang;
                foreach (DON_HANG item in listDonHangMoi.ToList())
                {
                    Don_Hang = new Don_Hang();
                    Don_Hang.Ma_Don_Hang = item.Ma_Don_Hang;
                    Don_Hang.Ngay_Dat = item.Ngay_Dat.ToString("dd/MM/yyyy");
                    Don_Hang.Hinh_Thuc_Thanh_Toan = item.Hinh_Thuc_Thanh_Toan;
                    Don_Hang.Hinh_Thuc_Thanh_Toan_String = item.Hinh_Thuc_Thanh_Toan.ToEnum<ThanhToan>().Text();
                    Don_Hang.Bang_Chung_Thanh_Toan = item.Bang_Chung_Thanh_Toan;
                    Don_Hang.Trinh_Trang = item.Tinh_Trang;
                    Don_Hang.Trinh_Trang_String = item.Tinh_Trang.ToEnum<DonHang>().Text();
                    list.Add(Don_Hang);
                }

                object_Response.Status_Code = 0;
                object_Response.Status_Text = "Get list đơn hàng thành công";
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

        private int suaChiTietDHByID(HttpContext context)
        {
            try
            {
                string strJson = new StreamReader(context.Request.InputStream).ReadToEnd();
                //deserialize the object
                Don_Hang don_Hang = JsonConvert.DeserializeObject<Don_Hang>(strJson);

                if (don_Hang == null) return 1;

                // Check prop của trái cây
                string check = checkInputData(don_Hang);

                if (check != "")
                {
                    object_Response.Status_Code = -2;
                    object_Response.Status_Text = "Vui lòng nhập" + check;
                    object_Response.Data = "";

                    context.Response.ContentType = "text/json";
                    context.Response.Write(JsonConvert.SerializeObject(object_Response));
                    return -2;
                }

                // Parse sang class DTO của linq
                DON_HANG dh = db.DON_HANGs.Where(p => p.Ma_Don_Hang == don_Hang.Ma_Don_Hang).FirstOrDefault();

                dh.Ngay_Dat = DateTime.ParseExact(don_Hang.Ngay_Dat, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                dh.Hinh_Thuc_Thanh_Toan = Int32.Parse(don_Hang.Hinh_Thuc_Thanh_Toan_String);
                dh.Tinh_Trang = Int32.Parse(don_Hang.Trinh_Trang_String);
                dh.Bang_Chung_Thanh_Toan = don_Hang.Bang_Chung_Thanh_Toan;
                
                db.SubmitChanges();
                return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return -1;
            }

        }

        private string checkInputData(Don_Hang don_Hang )
        {
            string result = "";

            if (don_Hang.Ngay_Dat == "")
            {
                result += " Ngày đặt,";
            }
            if (don_Hang.Hinh_Thuc_Thanh_Toan_String == "")
            {
                result += " Hình thức thanh toán,";
            }
            if (don_Hang.Trinh_Trang_String == "")
            {
                result += " Tình trạng,";
            }

            if (result.Length != 0) result = result.Substring(0, result.Length - 1);

            return result;
        }
    }
}