using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeAdmission
{
    public class DepartmentDetails
    {
        // Autoincrement ID
        private static int s_departmentID = 100;

        // property
        public string DepartmentID { get; }
        public string DepartmentName { get; set; }
        public long NumberOfSeats { get; set; }

        // Parametraised Constructor
        public DepartmentDetails(string departmentName, long numberOfSeats)
        {
            s_departmentID++;
            DepartmentID = "DID" + s_departmentID;
            DepartmentName = departmentName;
            NumberOfSeats = numberOfSeats;
        }
    }
}