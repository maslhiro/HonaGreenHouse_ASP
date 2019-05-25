using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellingFruitsWeb.DTO
{
    public class Object_Response
    {
        public string Status_Text { get; set; }
        public int Status_Code { get; set; }

        public Object Data { get; set; }

        public Object_Response()
        {
        }
        public Object_Response(string status_Text, int status_Code, object data)
        {
            Status_Text = status_Text;
            Status_Code = status_Code;
            Data = data;
        }
    }
}