using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellingFruitsWeb.DTO
{
    public class Loai_Trai_Cay
    {
        public string Ma_Loai_Trai_Cay { get; set; }

        public string Ten_Loai_Trai_Cay { get; set; }

        public Loai_Trai_Cay(string ma_Loai_Trai_Cay, string ten_Loai_Trai_Cay)
        {
            Ma_Loai_Trai_Cay = ma_Loai_Trai_Cay;
            Ten_Loai_Trai_Cay = ten_Loai_Trai_Cay;
        }

        public Loai_Trai_Cay()
        {
        }
    }
}