using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineLibrary
{
    public enum Gender {select, Male, Female, Transgender}
    public enum Department{select, ECE, EEE, CSE}
    public class UserDetails
    {
        private static int s_userID = 3000;
        // property
        public string UesrID { get; }
        public string UserName { get; set; }
        public Gender Gender { get; set; }
        public Department Department { get; set; }
        public long MobileNumber { get; set; }
        public string MailID { get; set; }
        public double WalletBalance { get; set; }

        // constructor
        public UserDetails(string userName, Gender gender, Department department, long mobileNumber,string mailID, double walletBalance)
        {
            s_userID++;
            UesrID="SF"+s_userID;
            UserName=userName;
            Gender=gender;
            Department=department;
            MobileNumber=mobileNumber;
            MailID=mailID;
            WalletBalance=walletBalance;
        }

        // method
        public double WalletRecharge(double amount)
        {
            WalletBalance+=amount;
            return WalletBalance;
        }

        public void DeductBalance(double amount)
        {
            WalletBalance-=amount;
        }

    }
}