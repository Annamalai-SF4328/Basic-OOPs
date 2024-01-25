using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Question1
{
    public enum Gender { select, Male, Female, Transgender }
    public class BankClass
    {
        // Autoincrement ID
        private static int s_CusID = 1000;
        // property
        public string CusID { get; }
        public string CusName { get; set; }
        public double Balance { get; set; }
        public Gender Gender { get; }
        public long Phone { get; set; }
        public string MailID { get; set; }
        public DateTime Dob { get; set; }

        //Parametaraised constructor
        public BankClass(string cusName, double balance, Gender gender, long phone, string mailID, DateTime dob)
        {
            s_CusID++;
            CusID = "HDFC" + s_CusID;
            CusName = cusName;
            Balance = balance;
            Gender = gender;
            Phone = phone;
            MailID = mailID;
            Dob = dob;
        }
        public double Deposit(double amount)
        {
            Balance += amount;
            return Balance;
        }
        public double Withdraw(double amount)
        {
            Balance -= amount;
            return Balance;
        }
    }
}