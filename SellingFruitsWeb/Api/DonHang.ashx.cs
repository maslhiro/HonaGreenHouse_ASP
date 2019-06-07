using Newtonsoft.Json;
using SellingFruitsWeb.DTO;
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
                // Get list don hang tinh trang : cho xac nhan 
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
                            object_Response.Status_Text = "Vui lòng upload ảnh bằng chứng thanh toán";
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
                //get list don hang da xac nhan va da huy
                case 4:
                    object_Response = new Object_Response();
                    ketQua = getListDonHangDaXacNhan(context);
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
                // get chi tiet don hang by madon hang
                case 6:
                    object_Response = new Object_Response();
                    ketQua = getChiTietDonHangByID(context);
                    switch (ketQua)
                    {
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

        private int getListDonHangMoi(HttpContext context)
        {
            try
            {
                var listDonHangMoi = db.DON_HANGs.Where(x => x.Tinh_Trang == (int)DonHang.DH_Pending);
                var list = new List<Don_Hang>();
                Don_Hang donHang;
                foreach (DON_HANG item in listDonHangMoi.ToList())
                {
                    donHang = new Don_Hang();

                    donHang.Ma_Don_Hang = item.Ma_Don_Hang;
                    donHang.Ngay_Dat = item.Ngay_Dat.ToString("dd/MM/yyyy");
                    donHang.Bang_Chung_Thanh_Toan = item.Bang_Chung_Thanh_Toan;
                    donHang.Tinh_Trang = item.Tinh_Trang;
                    donHang.Tinh_Trang_Text = item.Tinh_Trang.ToEnum<DonHang>().Text();

                    donHang.Tong_Tien = item.Tong_Tien;
                    donHang.Ho_Ten = item.Ho_Ten;
                    donHang.Dia_Chi_Nhan = item.Dia_Chi_Nhan;
                    donHang.So_Dien_Thoai = item.So_Dien_Thoai;
                    donHang.Ghi_Chu = item.Ghi_Chu;

                    list.Add(donHang);
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
            catch (Exception e)
            {
                Console.WriteLine("Exception huyDonHangById", e);
            }
            return -1;


        }

        private int xacNhanDonHangById(HttpContext context)
        {
            try
            {
                string strJson = new StreamReader(context.Request.InputStream).ReadToEnd();
                //deserialize the object
                Don_Hang donHang = JsonConvert.DeserializeObject<Don_Hang>(strJson);

                if (donHang.Bang_Chung_Thanh_Toan == null || donHang.Ma_Don_Hang == null) return 1;

                var dh = db.DON_HANGs.Where(p => p.Ma_Don_Hang == donHang.Ma_Don_Hang).FirstOrDefault();
                if (dh == null) return 2;

                dh.Tinh_Trang = (int)DonHang.DH_Success;
                dh.Bang_Chung_Thanh_Toan = donHang.Bang_Chung_Thanh_Toan;

                db.SubmitChanges();
                return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception xacNhanDonHangById", e);
            }
            return -1;


        }

        //get Danh sach don hang
        private int getListDonHangDaXacNhan(HttpContext context)
        {
            try
            {
                var listDonHangMoi = db.DON_HANGs.Where(x => x.Tinh_Trang != (int)DonHang.DH_Pending);
                var list = new List<Don_Hang>();
                Don_Hang donHang;
                foreach (DON_HANG item in listDonHangMoi.ToList())
                {
                    donHang = new Don_Hang();

                    donHang.Ma_Don_Hang = item.Ma_Don_Hang;
                    donHang.Ngay_Dat = item.Ngay_Dat.ToString("dd/MM/yyyy");
                    donHang.Bang_Chung_Thanh_Toan = item.Bang_Chung_Thanh_Toan;
                    donHang.Tinh_Trang = item.Tinh_Trang;
                    donHang.Tinh_Trang_Text = item.Tinh_Trang.ToEnum<DonHang>().Text();

                    donHang.Tong_Tien = item.Tong_Tien;
                    donHang.Ho_Ten = item.Ho_Ten;
                    donHang.Dia_Chi_Nhan = item.Dia_Chi_Nhan;
                    donHang.So_Dien_Thoai = item.So_Dien_Thoai;
                    donHang.Ghi_Chu = item.Ghi_Chu;

                    list.Add(donHang);
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

                // Parse sang class DTO của linq
                DON_HANG dh = db.DON_HANGs.Where(p => p.Ma_Don_Hang == don_Hang.Ma_Don_Hang).FirstOrDefault();

                dh.Ngay_Dat = DateTime.ParseExact(don_Hang.Ngay_Dat, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                dh.Tinh_Trang = Int32.Parse(don_Hang.Tinh_Trang_Text);
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
        
        private int getChiTietDonHangByID(HttpContext context)
        {
            try
            {
                string maDonHang = context.Request.QueryString["MaDonHang"];

                if (maDonHang.Length == 0) return 1;
                var listChiTiet = db.CHI_TIET_DON_HANGs.Where(p => p.Ma_Don_Hang == maDonHang);
                var listResult = new List<Chi_Tiet_Don_Hang>();
                Chi_Tiet_Don_Hang ctdh;
                foreach(CHI_TIET_DON_HANG item in listChiTiet)
                {
                    ctdh = new Chi_Tiet_Don_Hang();
                    ctdh.Ma_Chi_Tiet_DH = item.Ma_Chi_Tiet_DH;
                    ctdh.Ma_Don_Hang = item.Ma_Don_Hang;
                    ctdh.So_Luong_Xuat = item.So_Luong_Xuat;
                    ctdh.Don_Gia_Xuat = item.Don_Gia_Xuat;
                    ctdh.Ma_Trai_Cay = item.Ma_Trai_Cay;
                    ctdh.Tong_Tien_Xuat = item.So_Luong_Xuat * item.Don_Gia_Xuat;

                    var dh = db.DON_HANGs.Where(p => p.Ma_Don_Hang == maDonHang).FirstOrDefault();
                    ctdh.Thoi_Gian = dh.Ngay_Dat;

                    var tc = db.TRAI_CAYs.Where(p => p.Ma_Trai_Cay == item.Ma_Trai_Cay).FirstOrDefault();
                    ctdh.Ten_Trai_Cay = tc.Ten_Trai_Cay;
                    ctdh.Xuat_Xu = tc.Xuat_Xu;
                    ctdh.Don_Vi_Tinh = tc.Don_Vi_Tinh;

                    listResult.Add(ctdh);
                }
                object_Response.Status_Code = 0;
                object_Response.Status_Text = "Get list chi tiet đơn hàng thành công";
                object_Response.Data = listResult;

                context.Response.ContentType = "text/json";
                context.Response.Write(JsonConvert.SerializeObject(object_Response));
                return 0;
            }
            catch(Exception e)
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