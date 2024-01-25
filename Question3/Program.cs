using System;
namespace Question3;
using System.Collections.Generic;
class Program
{
    static List<Bill> BillList = new List<Bill>();
    static Bill CurrentID;
    public static void Main(string[] args)
    { 
        bool exit = true;
        do
        {
            Console.WriteLine("Main Menu\n1. Registration\n2. Login\n3. Exit");
            int choice=int.Parse(Console.ReadLine());
            switch(choice)
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
                    exit=false;
                    break;
                }
                default:
                {
                    Console.WriteLine("Invalid option.");
                    break;
                }
            }
        }while(exit);
    }
    static void Registration()
    {
        // data get
        Console.WriteLine("Enter your name : ");
        string userName=Console.ReadLine();
        Console.WriteLine("Enter your phone number : ");
        long phone=long.Parse(Console.ReadLine());
        Console.WriteLine("Enter your mail ID : ");
        string mailID=Console.ReadLine();
        double unit=0;

        // object creation and add to list
        Bill EBBill = new Bill(userName,phone,mailID,unit);
        Console.WriteLine("Your Meter ID is "+EBBill.MeterID);
        BillList.Add(EBBill);
    }
    static void Login()
    {
        Console.WriteLine("\nEnter meter ID : ");
        string loginID = Console.ReadLine().ToUpper();

        bool flag=true;
        foreach(Bill bill in BillList)
        {
            if(bill.MeterID==loginID)
            {
                flag=false;
                CurrentID=bill;
                SubMenu();
            }
        }
        if(flag)
        {
            Console.WriteLine("Invalid Meter ID.");
        }
    }
    static void SubMenu()
    {
        bool flag=true;
        do
        {
            Console.WriteLine("\nSubmenu\n1. Calculate Amount \n2. Display user Details \n3. Exit");
            int choice = int.Parse(Console.ReadLine());
            switch(choice)
            {
                case 1:
                {
                    CalculateAmount();
                    break;
                }
                case 2:
                {
                    Display();
                    break;
                }
                case 3:
                {
                    flag=false;
                    break;
                }
                default:
                {
                    Console.WriteLine("Invalid option.");
                    break;
                }
            }
        }while(flag);
    }
    static void CalculateAmount()
    {
        Console.WriteLine("Enter Unit : ");
        double unit=double.Parse(Console.ReadLine());

        Console.WriteLine($"Unit used : {unit} \nBill amount : {CurrentID.CalculateAmount(unit)}");
    }
    static void Display()
    {
        Console.WriteLine("Meter ID : "+CurrentID.MeterID);
        Console.WriteLine("User name : "+CurrentID.UserName);
        Console.WriteLine("Phone number : "+CurrentID.Phone);
        Console.WriteLine("Mail ID : "+CurrentID.MailID);
    }
}