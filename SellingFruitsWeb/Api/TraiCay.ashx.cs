using Newtonsoft.Json;
using SellingFruitsWeb.DTO;
using System;
using System.Collections.Generic;
using System.IO;
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
                // Get list trai cay 
                case 1:
                    object_Response = new Object_Response();
                    ketQua = getListTraiCay(context);
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
                // Xoa trai cay by id
                case 2:
                    object_Response = new Object_Response();
                    ketQua = xoaTraiCayByID(context);
                    switch (ketQua)
                    {
                        // Xoa thanh cong
                        case 0:
                            object_Response.Status_Code = 0;
                            object_Response.Status_Text = "Xoá trái cây thành công";
                            object_Response.Data = "";

                            context.Response.ContentType = "text/json";
                            context.Response.Write(JsonConvert.SerializeObject(object_Response));

                            break;
                        // Ma Trai cay khong ton tai
                        case 1:
                            object_Response.Status_Code = 1;
                            object_Response.Status_Text = "Mã trái cây không tồn tại";
                            object_Response.Data = "";

                            context.Response.ContentType = "text/json";
                            context.Response.Write(JsonConvert.SerializeObject(object_Response));
                            break;
                        // Khong tim thay trai cay
                        case 2:
                            object_Response.Status_Code = 2;
                            object_Response.Status_Text = "Mã trái cây không tồn tại";
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
                // Them trai cay
                case 3:
                    object_Response = new Object_Response();
                    ketQua = themTraiCay(context);
                    switch (ketQua)
                    {
                        // Lỗi nhập ko đủ dữ liệu
                        case -2:
                            // gửi reponse trong themTraiCay
                            break;
                        // Thêm thanh cong
                        case 0:
                            object_Response.Status_Code = 0;
                            object_Response.Status_Text = "Thêm trái cây thành công";
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
        public int themTraiCay(HttpContext context) {

            try
            {
                string strJson = new StreamReader(context.Request.InputStream).ReadToEnd();
                //deserialize the object
                Trai_Cay trai_Cay = JsonConvert.DeserializeObject<Trai_Cay>(strJson);

                if (trai_Cay == null) return 1;

                // Check prop của trái cây
                string check = checkInputData(trai_Cay);

                if(check != "")
                {
                    object_Response.Status_Code = -2;
                    object_Response.Status_Text = "Vui lòng nhập"+check;
                    object_Response.Data = "";

                    context.Response.ContentType = "text/json";
                    context.Response.Write(JsonConvert.SerializeObject(object_Response));
                    return -2;
                }
                
                // Parse sang class DTO của linq
                string count = string.Format("{0, 0:D3}",db.TRAI_CAYs.Count()+1);

                TRAI_CAY tc = new TRAI_CAY();
                
                tc.Ma_Trai_Cay = "TC"+count;
                tc.Ten_Trai_Cay = trai_Cay.Ten_Trai_Cay;
                tc.So_Luong = trai_Cay.So_Luong;
                tc.Xuat_Xu = trai_Cay.Xuat_Xu;
                tc.Don_Gia = trai_Cay.Don_Gia;
                tc.Don_Vi_Tinh = trai_Cay.Don_Vi_Tinh;
                tc.Loai_ID = trai_Cay.Loai_ID;
                tc.Mo_Ta = trai_Cay.Mo_Ta;

                db.TRAI_CAYs.InsertOnSubmit(tc);
                db.SubmitChanges();
                return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return -1;
            }
        }

        private int getListTraiCay(HttpContext context)
        {
            try
            {
                var listTraiCay = db.TRAI_CAYs.Where(p => p.Is_Deleted == 0);

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

                object_Response.Status_Code = 0;
                object_Response.Status_Text = "Get list trái cây thành công";
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

        private int xoaTraiCayByID(HttpContext context)
        {
            try
            {
                string maTraiCay = context.Request.QueryString["MaTraiCay"];

                if (maTraiCay.Length == 0) return 1;

                var traiCay = db.TRAI_CAYs.Where(p => p.Ma_Trai_Cay == maTraiCay).FirstOrDefault();
                if (traiCay == null) return 2;

                traiCay.Is_Deleted = 1;
                db.SubmitChanges();
                return 0;
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception xoaTraiCayById",e);
            }
            return -1;
           

        }

        private string checkInputData(Trai_Cay trai_Cay)
        {
            string result = "";

            if(trai_Cay.Ten_Trai_Cay == "")
            {
                result += " Tên trái cây,";
            }
            if (trai_Cay.Don_Vi_Tinh == "")
            {
                result += " Đơn vị tính,";
            }
            if (trai_Cay.Don_Gia.ToString() == "")
            {
                result += " Đơn giá,";
            }
            if (trai_Cay.So_Luong.ToString() == "")
            {
                result += " Số lượng ";
            }

            if(result.Length !=0) result = result.Substring(0, result.Length - 1);

            return result;
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