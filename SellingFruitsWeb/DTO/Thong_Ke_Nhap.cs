using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellingFruitsWeb.DTO
{
    public class Thong_Ke_Nhap
    {
        public string Auto_ID { get; set; }

        public string Ma_Trai_Cay { get; set; }

        public string Thoi_Gian { get; set; }

        public long Tong_Tien_Nhap { get; set; }

        public int Don_Gia_Nhap { get; set; }

        public int So_Luong_Nhap { get; set; }

        public string Ten_Trai_Cay { get; set; }

        public string Ten_Loai_Trai_Cay { get; set; }

        public string Don_Vi_Tinh { get; set; }

        public string Xuat_Xu { get; set; }

        public Thong_Ke_Nhap(string auto_ID, string ma_Trai_Cay, string thoi_Gian, long tong_Tien_Nhap, int don_Gia_Nhap, int so_Luong_Nhap, string ten_Trai_Cay, string ten_Loai_Trai_Cay, string don_Vi_Tinh, string xuat_Xu)
        {
            Auto_ID = auto_ID;
            Ma_Trai_Cay = ma_Trai_Cay;
            Thoi_Gian = thoi_Gian;
            Tong_Tien_Nhap = tong_Tien_Nhap;
            Don_Gia_Nhap = don_Gia_Nhap;
            So_Luong_Nhap = so_Luong_Nhap;
            Ten_Trai_Cay = ten_Trai_Cay;
            Ten_Loai_Trai_Cay = ten_Loai_Trai_Cay;
            Don_Vi_Tinh = don_Vi_Tinh;
            Xuat_Xu = xuat_Xu;
        }

        public Thong_Ke_Nhap()
        {
        }
    }
}