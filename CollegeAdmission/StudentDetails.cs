using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeAdmission
{
    public enum Gender { Select, Male, Female, Transgender }
    public class StudentDetails
    {
        // Autoincrement ID
        private static int s_studentID = 3000;


        // property
        public string StudentID { get; }
        public string StudentName { get; set; }
        public string FatherName { get; set; }
        public DateTime DOB { get; set; }
        public Gender Gender { get; set; }
        public double Physics { get; set; }
        public double Chemistry { get; set; }
        public double Maths { get; set; }

        // Parametraised Constructor
        public StudentDetails(string studentName, string fatherName, DateTime dob, Gender gender, double physics, double chemistry, double maths)
        {
            s_studentID++;
            StudentID = "SF" + s_studentID;
            StudentName = studentName;
            FatherName = fatherName;
            DOB = dob;
            Gender = gender;
            Physics = physics;
            Chemistry = chemistry;
            Maths = maths;
        }

        // method
        public bool CheckEligibility()
        {
            if (((Physics + Chemistry + Maths) / 3) >= 75)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}