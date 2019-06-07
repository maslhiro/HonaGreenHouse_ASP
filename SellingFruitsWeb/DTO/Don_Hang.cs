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

        public string Bang_Chung_Thanh_Toan { get; set; }

        public int Tinh_Trang { get; set; }

        public string Tinh_Trang_Text { get; set; }

        public double Tong_Tien { get; set; }

        public string Ho_Ten { get; set; }

        public string So_Dien_Thoai { get; set; }

        public string Dia_Chi_Nhan { get; set; }

        public string Ghi_Chu { get; set; }

        public Don_Hang(string ma_Don_Hang, string ngay_Dat, string bang_Chung_Thanh_Toan, int tinh_Trang, string tinh_Trang_Text, double tong_Tien, string ho_Ten, string so_Dien_Thoai, string dia_Chi_Nhan, string ghi_Chu)
        {
            Ma_Don_Hang = ma_Don_Hang;
            Ngay_Dat = ngay_Dat;
            Bang_Chung_Thanh_Toan = bang_Chung_Thanh_Toan;
            Tinh_Trang = tinh_Trang;
            Tinh_Trang_Text = tinh_Trang_Text;
            Tong_Tien = tong_Tien;
            Ho_Ten = ho_Ten;
            So_Dien_Thoai = so_Dien_Thoai;
            Dia_Chi_Nhan = dia_Chi_Nhan;
            Ghi_Chu = ghi_Chu;
        }

        public Don_Hang()
        {
        }
    }
}