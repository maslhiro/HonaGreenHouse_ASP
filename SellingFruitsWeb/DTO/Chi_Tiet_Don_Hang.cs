using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellingFruitsWeb.DTO
{
    public class Chi_Tiet_Don_Hang
    {
        public string Ma_Don_Hang { get; set; }

        public string Ma_Chi_Tiet_DH { get; set; }

        public string Ma_Trai_Cay { get; set; }

        public string Ten_Trai_Cay { get; set; }

        public string Don_Vi_Tinh { get; set; }

        public double Tong_Tien_Xuat { get; set; }

        public int So_Luong_Xuat { get; set; }

        public int Don_Gia_Xuat { get; set; }

        public string Xuat_Xu { get; set; }

        public DateTime Thoi_Gian { get; set; }

        public Chi_Tiet_Don_Hang(string ma_Don_Hang, string ma_Chi_Tiet_DH, string ma_Trai_Cay, string ten_Trai_Cay, string don_Vi_Tinh, double tong_Tien_Xuat, int so_Luong_Xuat, int don_Gia_Xuat, string xuat_Xu, DateTime thoi_Gian)
        {
            Ma_Don_Hang = ma_Don_Hang;
            Ma_Chi_Tiet_DH = ma_Chi_Tiet_DH;
            Ma_Trai_Cay = ma_Trai_Cay;
            Ten_Trai_Cay = ten_Trai_Cay;
            Don_Vi_Tinh = don_Vi_Tinh;
            Tong_Tien_Xuat = tong_Tien_Xuat;
            So_Luong_Xuat = so_Luong_Xuat;
            Don_Gia_Xuat = don_Gia_Xuat;
            Xuat_Xu = xuat_Xu;
            Thoi_Gian = thoi_Gian;
        }

        public Chi_Tiet_Don_Hang()
        {
        }
    }
}