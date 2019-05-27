using Newtonsoft.Json;
using SellingFruitsWeb.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace SellingFruitsWeb.Api
{
    public class LoaiTraiCay : IHttpHandler
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
                // Get list loai trai cay 
                case 8:
                    object_Response = new Object_Response();
                    ketQua = getListLoaiTraiCay(context);
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
                // Xoa loai trai cay by id
                case 10:
                    object_Response = new Object_Response();
                    ketQua = xoaLoaiTraiCayByID(context);
                    switch (ketQua)
                    {
                        case 0:
                            object_Response.Status_Code = 0;
                            object_Response.Status_Text = "Xoá loại trái cây thành công";
                            object_Response.Data = "";

                            context.Response.ContentType = "text/json";
                            context.Response.Write(JsonConvert.SerializeObject(object_Response));

                            break;
                        case 1:
                            object_Response.Status_Code = 1;
                            object_Response.Status_Text = "Mã loại trái cây không tồn tại";
                            object_Response.Data = "";

                            context.Response.ContentType = "text/json";
                            context.Response.Write(JsonConvert.SerializeObject(object_Response));
                            break;
                        case 2:
                            object_Response.Status_Code = 2;
                            object_Response.Status_Text = "Mã loại trái cây không tồn tại";
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
                // Them loai trai cay
                case 11:
                    object_Response = new Object_Response();
                    ketQua = themLoaiTraiCay(context);
                    switch (ketQua)
                    {
                        // Lỗi nhập ko đủ dữ liệu
                        case -2:
                            // gửi reponse trong themLoaiTraiCay
                            break;
                        case 0:
                            object_Response.Status_Code = 0;
                            object_Response.Status_Text = "Thêm loại trái cây thành công";
                            object_Response.Data = "";

                            context.Response.ContentType = "text/json";
                            context.Response.Write(JsonConvert.SerializeObject(object_Response));

                            break;
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
                // Edit loai trai cay by id
                case 9:
                    object_Response = new Object_Response();
                    ketQua = suaLoaiTraiCayByID(context);
                    switch (ketQua)
                    {
                        // Lỗi nhập ko đủ dữ liệu
                        case -2:
                            // gửi reponse trong suaLoaiTraiCay
                            break;
                        // Update thanh cong
                        case 0:
                            object_Response.Status_Code = 0;
                            object_Response.Status_Text = "Cập nhật loại trái cây thành công";
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

        public int themLoaiTraiCay(HttpContext context) {

            try
            {
                string strJson = new StreamReader(context.Request.InputStream).ReadToEnd();
                //deserialize the object
                Loai_Trai_Cay loai_Trai_Cay = JsonConvert.DeserializeObject<Loai_Trai_Cay>(strJson);

                if (loai_Trai_Cay == null) return 1;

                // Check prop của loại trái cây
                string check = checkInputData(loai_Trai_Cay);

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
                string count = string.Format("{0, 0:D3}",db.LOAI_TRAI_CAYs.Count()+1);

                var ltc = new LOAI_TRAI_CAY();

                ltc.Ma_Loai_Trai_Cay = "LTC"+count;
                ltc.Ten_Loai_Trai_Cay = loai_Trai_Cay.Ten_Loai_Trai_Cay;

                db.LOAI_TRAI_CAYs.InsertOnSubmit(ltc);
                db.SubmitChanges();
                return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return -1;
            }
        }

        private int getListLoaiTraiCay(HttpContext context)
        {
            try
            {
                var listLoaiTraiCay = db.LOAI_TRAI_CAYs.Where(p => p.Is_Deleted == 0);

                var list = new List<Loai_Trai_Cay>();

                foreach (LOAI_TRAI_CAY item in listLoaiTraiCay.ToList())
                {
                    var loai_Trai_Cay = new Loai_Trai_Cay();

                    loai_Trai_Cay.Ma_Loai_Trai_Cay = item.Ma_Loai_Trai_Cay;
                    loai_Trai_Cay.Ten_Loai_Trai_Cay = item.Ten_Loai_Trai_Cay;

                    list.Add(loai_Trai_Cay);
                }

                object_Response.Status_Code = 0;
                object_Response.Status_Text = "Lấy danh sách loại trái cây thành công";
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

        private int xoaLoaiTraiCayByID(HttpContext context)
        {
            try
            {
                string maLoaiTraiCay = context.Request.QueryString["MaLoaiTraiCay"];

                if (maLoaiTraiCay.Length == 0) return 1;

                var loaiTraiCay = db.LOAI_TRAI_CAYs.Where(p => p.Ma_Loai_Trai_Cay == maLoaiTraiCay).FirstOrDefault();
                if (loaiTraiCay == null) return 2;

                loaiTraiCay.Is_Deleted = 1;
                db.SubmitChanges();
                return 0;
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception xoaTraiCayById",e);
            }
            return -1;
           

        }

        private int suaLoaiTraiCayByID(HttpContext context)
        {
            try
            {
                string strJson = new StreamReader(context.Request.InputStream).ReadToEnd();
                //deserialize the object
                Loai_Trai_Cay loai_Trai_Cay = JsonConvert.DeserializeObject<Loai_Trai_Cay>(strJson);

                if (loai_Trai_Cay == null) return 1;

                // Check prop của loại trái cây
                string check = checkInputData(loai_Trai_Cay);

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
                LOAI_TRAI_CAY ltc = db.LOAI_TRAI_CAYs.Where(p=>p.Ma_Loai_Trai_Cay == loai_Trai_Cay.Ma_Loai_Trai_Cay).FirstOrDefault();

                ltc.Ten_Loai_Trai_Cay = loai_Trai_Cay.Ten_Loai_Trai_Cay;
              
                db.SubmitChanges();
                return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return -1;
            }

        }

        private string checkInputData(Loai_Trai_Cay input)
        {
            string result = "";

            if(input.Ten_Loai_Trai_Cay == "")
            {
                result += " Tên loại trái cây,";
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