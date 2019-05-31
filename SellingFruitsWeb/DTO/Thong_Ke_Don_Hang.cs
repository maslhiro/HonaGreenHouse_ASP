using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellingFruitsWeb.DTO
{
    public class Thong_Ke_Don_Hang
    {
        public string Auto_ID { get; set; }
        public string Ma_Don_Hang { get; set; }
        public string Thoi_Gian { get; set; } 
        public long Tong_Tien { get; set; }
        public string Ma_Khach_Hang { get; set; }
        public string Hinh_Thuc_Thanh_Toan { get; set; }
        public string Ho_Ten { get; set; }
        public string So_Dien_Thoai { get; set; }
        public string Dia_Chi_Nhan { get; set; }

        public Thong_Ke_Don_Hang(string auto_ID, string thoi_Gian, long tong_Tien,string ma_Don_Hang, 
            string maKH, string hinhThuc, string hoTen, string SDT, string diaChi)
        {
            Auto_ID = auto_ID;
            Ma_Don_Hang = ma_Don_Hang;
            Thoi_Gian = thoi_Gian;
            Tong_Tien = tong_Tien;
            Ma_Khach_Hang = maKH;
            Hinh_Thuc_Thanh_Toan = hinhThuc;
            Ho_Ten = hoTen;
            So_Dien_Thoai = SDT;
            Dia_Chi_Nhan = diaChi;
        }

        public Thong_Ke_Don_Hang()
        {
        }
    }
}