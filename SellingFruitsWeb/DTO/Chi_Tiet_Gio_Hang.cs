using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellingFruitsWeb.DTO
{
    public class Chi_Tiet_Gio_Hang
    {
        public string Ma_Trai_Cay { get; set; }

        public string Don_Gia_Xuat { get; set; }

        public string So_Luong_Xuat { get; set; }
        
        public Chi_Tiet_Gio_Hang(string maTraiCay, string donGiaXuat, string soLuongXuat)
        {
            Ma_Trai_Cay = maTraiCay;
            Don_Gia_Xuat = donGiaXuat;
            So_Luong_Xuat = soLuongXuat;
        }

        public Chi_Tiet_Gio_Hang()
        {
        }


    }
}