using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellingFruitsWeb.DTO
{
    public class Don_Hang
    {
        public string Ma_Don_Hang { get; set; }

        public string Ngay_Dat { get; set; }

        public int Hinh_Thuc_Thanh_Toan { get; set; }
        public string Hinh_Thuc_Thanh_Toan_String { get; set; }

        public string Bang_Chung_Thanh_Toan { get; set; }

        public int Trinh_Trang { get; set; }
        public string Trinh_Trang_String { get; set; }
        public string Ma_Khach_Hang { get; set; }

        public Don_Hang(string ma_Don_Hang, string ngay_Dat, int hinh_Thuc_Thanh_Toan, string hinh_Thuc_Thanh_Toan_String, string bang_Chung_Thanh_Toan, int trinh_Trang, string trinh_Trang_String, string ma_Khach_Hang)
        {
            Ma_Don_Hang = ma_Don_Hang;
            Ngay_Dat = ngay_Dat;
            Hinh_Thuc_Thanh_Toan = hinh_Thuc_Thanh_Toan;
            Hinh_Thuc_Thanh_Toan_String = hinh_Thuc_Thanh_Toan_String;
            Bang_Chung_Thanh_Toan = bang_Chung_Thanh_Toan;
            Trinh_Trang = trinh_Trang;
            Trinh_Trang_String = trinh_Trang_String;
            Ma_Khach_Hang = ma_Khach_Hang;
        }

        public Don_Hang()
        {
        }
    }
}