using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Question3
{
    public class Bill
    {
        private static int s_meterID=1000;

        public string MeterID { get; }
        public string UserName { get; set; }
        public long Phone { get; set; }
        public string MailID { get; set; }
        public double Unit { get; set; }

        public Bill(string userName,long phone,string mailID,double unit)
        {
            s_meterID++;
            MeterID="EB"+s_meterID;
            UserName=userName;
            Phone=phone;
            MailID=mailID;
            Unit=unit;
        }

        public double CalculateAmount(double unit)
        {
            Unit=unit;
            return Unit*5;
        }
    }
}