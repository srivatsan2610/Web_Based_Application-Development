using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1021022_XYZShopping.Models
{
            public class OrderDetailsModel
        {
            public string OrderDetailID { get; set; }
            public string OrderNo { get; set; }
            public string ItemNo { get; set; }
            public string ItemDesc { get; set; }
            public string Qty { get; set; }
            public string Price { get; set; }
        }
    }
