using System;
namespace Question2;
using System.Collections.Generic;
class Program
{
    static List<Payroll> PayList = new List<Payroll>();
    static Payroll CurrentEmployee;
    public static void Main(string[] args)
    {
        bool exit = true;
        do
        {
            Console.WriteLine("Main Menu\n1. Registration\n2. Login\n3. exit");
            int ch = int.Parse(Console.ReadLine());
            switch (ch)
            {
                case 1:
                    {
                        Registration();
                        break;
                    }
                case 2:
                    {
                        Login();
                        break;
                    }
                case 3:
                    {
                        exit = false;
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Invalid option.");
                        break;
                    }
            }

        } while (exit);
    }
    static void Registration()
    {
        Console.WriteLine("Enter your name : ");
        string empName = Console.ReadLine();
        Console.WriteLine("Enter your Role : ");
        string role = Console.ReadLine();
        Console.WriteLine("Enter your Work Location : ");
        Location location = Enum.Parse<Location>(Console.ReadLine(), true);
        Console.WriteLine("Enter your team name : ");
        string teamName = Console.ReadLine();
        Console.WriteLine("Enter your Date of Joining : ");
        DateTime doj = DateTime.ParseExact(Console.ReadLine(), "MM/dd/yyyy", null);
        Console.WriteLine("Enter your Working Days in Month : ");
        int workDays = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter your Leave Days : ");
        int leaveDays = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter your Gender : ");
        Gender gender = Enum.Parse<Gender>(Console.ReadLine(), true);

        Payroll Empdetail = new Payroll(empName, role, location, teamName, doj, workDays, leaveDays, gender);
        Console.WriteLine("Your Employee ID : " + Empdetail.EmpID);
        PayList.Add(Empdetail);
    }

    static void Login()
    {
        bool flag = true;
        Console.WriteLine("Enter your employee ID : ");
        string loginID = Console.ReadLine().ToUpper();
        foreach (Payroll Pay in PayList)
        {
            if (Pay.EmpID == loginID)
            {
                flag = false;
                CurrentEmployee = Pay;
                SubMenu();
            }
        }
        if (flag)
        {
            Console.WriteLine("Invalid Employee ID");
        }
    }

    static void SubMenu()
    {
        bool flag = true;
        do
        {
            Console.WriteLine("Sub menu\n1. Calculate salary \n2. display details \n3. exit");
            int option = int.Parse(Console.ReadLine());
            switch (option)
            {
                case 1:
                    {
                        Console.WriteLine("Month Salary : "+CurrentEmployee.SalaryCalculation());
                        break;
                    }
                case 2:
                    {
                        Display();
                        break;
                    }
                case 3:
                    {
                        flag = false;
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Invalid option");
                        break;
                    }
            }
        } while (flag);
    }
    static void Display()
    {
        Console.WriteLine("Employee Name : " + CurrentEmployee.EmpName);
        Console.WriteLine("Employee ID : " + CurrentEmployee.EmpID);
        Console.WriteLine("Employee Role : " + CurrentEmployee.Role);
        Console.WriteLine("Employee Work Location : " + CurrentEmployee.Location);
        Console.WriteLine("Employee Team Name : " + CurrentEmployee.TeamName);
        Console.WriteLine("Employee Date of Joining : " + CurrentEmployee.Doj);
        Console.WriteLine("Employee Working Days : " + CurrentEmployee.WorkDays);
        Console.WriteLine("Employee Leave Days : " + CurrentEmployee.LeaveDays);
        Console.WriteLine("Employee Gender : " + CurrentEmployee.Gender);
    }
}