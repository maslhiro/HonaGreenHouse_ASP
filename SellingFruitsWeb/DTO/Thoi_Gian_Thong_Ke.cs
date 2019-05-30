using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellingFruitsWeb.DTO
{
    public class Thoi_Gian_Thong_Ke
    {
        public string From_Date { get; set; }
        public string To_Date { get; set; }

        public Thoi_Gian_Thong_Ke(string fromDate, string toDate)
        {
            From_Date = fromDate;
            To_Date = toDate;
        }

        public Thoi_Gian_Thong_Ke()
        {
        }
    }
}