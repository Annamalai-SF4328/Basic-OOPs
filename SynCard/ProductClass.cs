using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynCard
{
    public class ProductClass
    {
        // Autoincrement ID
        private static int s_productID = 100;

        // property
        public string ProductID { get; }
        public string ProductName { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
        public int ShippingDuration { get; set; }

        public ProductClass(string productName, int stock, double price, int shippingDuration)
        {
            s_productID++;
            ProductID="PID"+s_productID;
            ProductName=productName;
            Stock=stock;
            Price=price;
            ShippingDuration=shippingDuration;
        }
    
    }
}