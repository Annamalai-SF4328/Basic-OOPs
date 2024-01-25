using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynCard
{
    public enum OrderStatus{select,Default,Ordered,Cancelled};
    public class OrderClass
    {
        // Autoincrement ID
        private static int s_orderID = 5000;

        // property
        public string OrderID { get; }
        public string CustomerID { get; }
        public string ProductID { get; }
        public double TotalPrice { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int Quantity { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public OrderClass(string customerID,string productID,double totalPrice,DateTime purchaseDate, int quantity,OrderStatus orderStatus)
        {
            s_orderID++;
            OrderID="OID"+s_orderID;
            CustomerID=customerID;
            ProductID=productID;
            TotalPrice=totalPrice;
            PurchaseDate=purchaseDate;
            Quantity=quantity;
            OrderStatus=orderStatus;

        }
    }
}