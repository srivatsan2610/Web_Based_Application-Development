using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1021022_XYZShopping.Models
{
    public class ProductsModel
    {
        public string productId { get; set; }
        public string CatID { get; set; }
        public string ProductSDesc { get; set; }
        public string ProductLDesc { get; set; }
        public string Price { get; set; }
        public string Instock { get; set; }
        public string Inventory { get; set; }
    }
}