using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynCard
{
    public class CustomerClass
    {
        // Autoincrement ID
        private static int s_customerID = 1000;
        // property
        public string CustomerID { get; }
        public string CustomerName { get; set; }
        public string City { get; set; }
        public long MobileNumber { get; set; }
        public double WalletBalance { get; set; }
        public string EmailID { get; set; }

        public CustomerClass(string customerName, string city,long mobileNumber,double walletBalance,string emailID)
        {
            s_customerID++;
            CustomerID="CID"+s_customerID;
            CustomerName=customerName;
            City=city;
            MobileNumber=mobileNumber;
            WalletBalance=walletBalance;
            EmailID=emailID;
        }

        public void DeductBalance(double price)
        {
            WalletBalance=WalletBalance-price-50;
        }

        public double WalletRecharge(double amount)
        {
            return WalletBalance+=amount;
        }
    }
}