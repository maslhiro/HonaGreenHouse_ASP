using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellingFruitsWeb.DTO
{
    public class Chi_Tiet_Chuyen_Hang
    {
        public string Ma_Chi_Tiet_CH { get; set; }

        public string Ho_Ten { get; set; }

        public string So_Dien_Thoai { get; set; }
        public string Dia_Chi_Nhan { get; set; }
        public string Ghi_Chu { get; set; }
        public string Ma_Don_Hang { get; set; }
        

        public Chi_Tiet_Chuyen_Hang(string ma_Chi_Tiet_CH, string ho_Ten, string so_Dien_Thoai, string dia_Chi_Nhan, string ghi_Chu, string ma_Don_Hang)
        {
            Ma_Chi_Tiet_CH = ma_Chi_Tiet_CH;
            Ho_Ten = ho_Ten;
            So_Dien_Thoai = so_Dien_Thoai;
            Dia_Chi_Nhan = dia_Chi_Nhan;
            Ghi_Chu = ghi_Chu;
            Ma_Don_Hang = ma_Don_Hang;
        }

        public Chi_Tiet_Chuyen_Hang()
        {
        }


    }
}