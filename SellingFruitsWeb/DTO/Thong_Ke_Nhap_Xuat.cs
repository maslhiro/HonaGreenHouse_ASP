using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellingFruitsWeb.DTO
{
    public class Thong_Ke_Nhap_Xuat
    {
        public string Auto_ID { get; set; }
        public string Ma_Trai_Cay { get; set; }
        public string Thoi_Gian { get; set; } 
        public long Tong_Tien { get; set; }
        public int So_Luong_Nhap { get; set; }
        public string Ten_Trai_Cay { get; set; }
        public string Don_Gia { get; set; }
        public string Don_Vi_Tinh { get; set; }
        public string Xuat_Xu { get; set; }

        public Thong_Ke_Nhap_Xuat(string autoID, string maTraiCay, string thoiGian, long tongTien, 
            int soLuong, string ten, string donGia, string donViTinh, string xuatXu)
        {
            Auto_ID = autoID;
            Ma_Trai_Cay = maTraiCay;
            Thoi_Gian = thoiGian;
            Tong_Tien = tongTien;
            So_Luong_Nhap = soLuong;
            Ten_Trai_Cay = ten;
            Don_Gia = donGia;
            Don_Vi_Tinh = donViTinh;
            Xuat_Xu = xuatXu;
        }

        public Thong_Ke_Nhap_Xuat()
        {
        }
    }
}