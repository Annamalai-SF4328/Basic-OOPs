using System;
using System.Collections.Generic;
namespace Question1;

class Program
{
    static List<BankClass> BankList = new List<BankClass>();
    static BankClass CurrentCustomer;
    public static void Main(string[] args)
    {

        bool exit = true;
        do
        {
            Console.WriteLine("Main menu\n1. Registration  \n2. Login \n3. Exit");
            int temp = int.Parse(Console.ReadLine());
            switch (temp)
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
            }

        } while (exit);
    }

    static void Registration()
    {
        Console.WriteLine("Enter your name : ");
        string cusName = Console.ReadLine();
        Console.WriteLine("Your Balance is 0.");
        double balance = 0;
        Console.WriteLine("Enter gender : ");
        Gender gender = Enum.Parse<Gender>(Console.ReadLine(), true);
        Console.WriteLine("Enter your phone number : ");
        long phone = Convert.ToInt64(Console.ReadLine());
        Console.WriteLine("Enter your mail ID : ");
        string mailID = Console.ReadLine();
        Console.WriteLine("Enter your Date of Birth in MM/dd/yyyy : ");
        DateTime dob = DateTime.ParseExact(Console.ReadLine(), "MM/dd/yyyy", null);


        BankClass Bank = new BankClass(cusName, balance, gender, phone, mailID, dob);
        Console.WriteLine("Your customer ID is " + Bank.CusID);

        BankList.Add(Bank);
    }

    static void Login()
    {
        bool flag = true;
        Console.WriteLine("Enter your customer ID: ");
        string loginID = Console.ReadLine().ToUpper();

        foreach (BankClass Banking in BankList)
        {
            if (loginID == Banking.CusID)
            {
                flag = false;
                CurrentCustomer = Banking;
                SubMenu();
            }
        }
        if (flag)
        {
            Console.WriteLine("Invalid Customer ID.");
        }
    }

    static void SubMenu()
    {
        bool flag = true;
        do
        {
            Console.WriteLine("Sub menu\n1. Deposit, \n2. withdraw, \n3.balance check \n4. exit");
            int ch = Convert.ToInt32(Console.ReadLine());
            switch (ch)
            {
                case 1:
                    {
                        Deposit();
                        break;
                    }
                case 2:
                    {
                        Withdraw();
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Your Balance is " + CurrentCustomer.Balance);
                        break;
                    }
                case 4:
                    {
                        flag = false;
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Invalid Option");
                        break;
                    }
            }
        } while (flag);
    }

    static void Deposit()
    {
        Console.WriteLine("Enter amount to deposit : ");
        double amount = double.Parse(Console.ReadLine());
        Console.WriteLine(CurrentCustomer.Deposit(amount));
    }
    static void Withdraw()
    {
        Console.WriteLine("Enter amount you want :");
        double amount = Convert.ToInt64(Console.ReadLine());
        if (amount <= CurrentCustomer.Balance)
        {
            Console.WriteLine("Current balance : " + CurrentCustomer.Withdraw(amount));
        }
        else
        {
            Console.WriteLine("Invalid amount. Your balance is " + CurrentCustomer.Balance);
        }
    }
}