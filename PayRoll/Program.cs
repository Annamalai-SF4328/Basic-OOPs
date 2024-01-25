using System;
using System.Collections.Generic;
namespace PayRoll;
class Program
{
    static List<EmployeeDetails> employeeList = new List<EmployeeDetails>();
    static List<AttendanceDetails> attendanceList = new List<AttendanceDetails>();
    static EmployeeDetails currentEmployee;
    public static void Main(string[] args)
    {
        LoadData();
        string option="yes";
        do
        {
            Console.WriteLine();
            Console.WriteLine("Main Menu\n1. Employee Registration\n2. Login\n3. Exit");
            int choice =int.Parse(Console.ReadLine());
            switch(choice)
            {
                case 1:
                {
                    EmployeeRegistration();
                    break;
                }
                case 2:
                {
                    EmployeeLogin();
                    break;
                }
                case 3:
                {
                    Console.WriteLine("exit");
                    option="no";
                    break;
                }
                default:
                {
                    Console.WriteLine("invalid choice");
                    break;
                }
            }
            
        }while(option=="yes");
        
    }

    public static void EmployeeRegistration()
    {
        // Get the detail from employee
        Console.WriteLine("Enter Employee Name : ");
        string employeeName = Console.ReadLine();
        Console.WriteLine("Enter Employee DOB : ");
        DateTime dob = DateTime.ParseExact(Console.ReadLine(),"MM/dd/yyyy",null);
        Console.WriteLine("Enter Employee Mobile number : ");
        long mobileNumber = long.Parse(Console.ReadLine());
        Console.WriteLine("Enter Employee Gender : ");
        Gender gender=Enum.Parse<Gender>(Console.ReadLine(),true);
        Console.WriteLine("Enter Employee Branch : ");
        Branch branch=Enum.Parse<Branch>(Console.ReadLine(),true);
        Console.WriteLine("Enter Employee Team : ");
        Team team=Enum.Parse<Team>(Console.ReadLine(),true);

        // object create
        EmployeeDetails employee = new EmployeeDetails(employeeName, dob, mobileNumber, gender, branch, team);
        // Display employee ID
        Console.WriteLine("Employee added successfully your id is : "+employee.EmployeeID);
        // add to the list
        employeeList.Add(employee);
    }

    static void EmployeeLogin()
    {
        // get Employee ID from user
        Console.WriteLine("Enter Employee ID : ");
        string loginID = Console.ReadLine().ToUpper();
        
        // validate the Employee ID from Employee list
        bool flag= true;
        foreach(EmployeeDetails employee in employeeList)
        {
            if(loginID==employee.EmployeeID)
            {
                currentEmployee=employee;
                flag=false;
                // Display submenu
                SubMenu();
            }
        }
        if(flag)
        {
            Console.WriteLine("Invalid Employee ID");
        }  
    }

    static void SubMenu()
    {
        bool flag = true;
        do
        {
            Console.WriteLine();
            Console.WriteLine("Sub Menu \n1. Add Attendance\n2. Display Details\n3. Calculate Salary\n4. Exit");
            int choice1 = int.Parse(Console.ReadLine());
            switch(choice1)
            {
                case 1:
                {
                    AddAttendance();
                    break;
                }
                case 2:
                {
                    DisplayDetails();
                    break;
                }
                case 3:
                {
                    CalculateSalary();
                    break;
                }
                case 4:
                {
                    flag=false;
                    break;
                }
                default:
                {
                    Console.WriteLine("Invalid Choice.");
                    break;
                }
            }
        }while(flag);
    }

    public static void AddAttendance()
    {
        // get check in Date and time
        Console.WriteLine("If you want to check in, Give Date of check in : (as MM/dd/yyyy)");
        DateTime checkInDate = DateTime.ParseExact(Console.ReadLine(),"MM/dd/yyyy",null);
        Console.WriteLine("Give Time of check in : (as hh:mm tt)");
        DateTime checkInTime = DateTime.ParseExact(Console.ReadLine(),"hh:mm tt",null);
        
        // get check out Date and time
        Console.WriteLine("If you want to check out, Give Date of check out : as(MM/dd/yyyy)");
        DateTime checkOutDate = DateTime.ParseExact(Console.ReadLine(),"MM/dd/yyyy",null);
        Console.WriteLine("Give time of check out : as(hh:mm tt)");
        DateTime checkOutTime = DateTime.ParseExact(Console.ReadLine(),"hh:mm tt",null);

        // check check in and check out
        if(checkInDate.Equals(checkOutDate))
        {
            TimeSpan span = checkOutTime-checkInTime;
            if(span.Hours>8)
            {
                int hour=8;
                AttendanceDetails attendance = new AttendanceDetails(currentEmployee.EmployeeID,checkInDate,checkInTime,checkOutTime,hour);
                Console.WriteLine("Check-in and Checkout Successful and today you have worked 8 Hours.");
                attendanceList.Add(attendance);
            }
            else
            {
                AttendanceDetails attendance = new AttendanceDetails(currentEmployee.EmployeeID,checkInDate,checkInTime,checkOutTime,span.Hours);
                Console.WriteLine($"Check-in and Checkout Successful and today you have worked {span.Hours} Hours.");
                attendanceList.Add(attendance);
            }
        }
    }

    public static void DisplayDetails()
    {
        foreach(EmployeeDetails employee in employeeList)
        {
            if(employee.EmployeeID==currentEmployee.EmployeeID)
            {
                Console.WriteLine("\nEmployee ID : "+employee.EmployeeID);
                Console.WriteLine("Employee Name : "+employee.EmployeeName);
                Console.WriteLine("Employee DOB : "+employee.DOB);
                Console.WriteLine("Employee Mobile number : "+employee.MobileNumber);
                Console.WriteLine("Employee gender : "+employee.Gender);
                Console.WriteLine("Employee Branch : "+employee.Branch);
                Console.WriteLine("Employee team : "+employee.Team);
            }
        }
    }

    public static void CalculateSalary()
    {
        int hoursSum = 0;
        int daysSum = 0;

        foreach(AttendanceDetails attendance in attendanceList)
        {
            DateTime date=DateTime.Now;
            string month = date.ToString("MM");
            if(currentEmployee.EmployeeID == attendance.EmployeeID && month.Equals(attendance.Date.ToString("MM")))
            {
                Console.WriteLine("\nAttentance ID : "+attendance.AttendanceID);
                Console.WriteLine("Attentance Date : "+attendance.Date);
                Console.WriteLine("Attentance check-in time : "+attendance.CheckInTime);
                Console.WriteLine("Attentance check-out time : "+attendance.CheckOutTime);
                Console.WriteLine("Attentance hour : "+attendance.HoursWorked);

                hoursSum += attendance.HoursWorked;
                daysSum++;
            }
        }
        double salary = daysSum*500;
        Console.WriteLine("\nSalary : "+salary);
    }
    public static void LoadData()
    {
        EmployeeDetails employee = new EmployeeDetails("Ravi",DateTime.ParseExact("11/11/1999","MM/dd/yyyy",null), 9958858888,Gender.Male,Branch.Eymard, Team.Developer);
        
        employeeList.Add(employee);

        AttendanceDetails attendance = new AttendanceDetails("SF3001",DateTime.ParseExact("12/12/2023","MM/dd/yyyy",null),DateTime.ParseExact("09:00 AM","hh:mm tt",null),DateTime.ParseExact("06:10 PM","hh:mm tt",null), 8);
        AttendanceDetails attendance1 = new AttendanceDetails("SF3002", DateTime.ParseExact("12/12/2023","MM/dd/yyyy",null),DateTime.ParseExact("09:10 AM","hh:mm tt",null),DateTime.ParseExact("06:50 PM","hh:mm tt",null), 8);

        attendanceList.Add(attendance);
        attendanceList.Add(attendance1);
    }
}