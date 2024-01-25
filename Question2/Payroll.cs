using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
public enum Location { India, Africa, USA }
public enum Gender { Male, Female }

namespace Question2
{
    public class Payroll
    {
        // AutoIncrement ID
        private static int s_EmpID = 1000;

        // Properties
        public string EmpID { get; }
        public string EmpName { get; set; }
        public string Role { get; set; }
        public Location Location { get; set; }
        public string TeamName { get; set; }
        public DateTime Doj { get; set; }
        public int WorkDays { get; set; }
        public int LeaveDays { get; set; }
        public Gender Gender { get; set; }

        public Payroll(string empName, string role, Location location, string teamName, DateTime doj, int workDays, int leaveDays, Gender gender)
        {
            s_EmpID++;
            EmpID = "SF" + s_EmpID;
            EmpName = empName;
            Role = role;
            Location = location;
            TeamName = teamName;
            Doj = doj;
            WorkDays = workDays;
            LeaveDays = leaveDays;
            Gender = gender;
        }

        public double SalaryCalculation()
        {
            return (WorkDays - LeaveDays) * 500;
        }

    }
}