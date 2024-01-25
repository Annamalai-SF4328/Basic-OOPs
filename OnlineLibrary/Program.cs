using System;
using System.Collections.Generic;
namespace OnlineLibrary;
class Program
{
    static List<UserDetails> userList = new List<UserDetails>();
    static List<BookDetails> bookList = new List<BookDetails>();
    static List<BorrowDetails> borrowList = new List<BorrowDetails>();
    static UserDetails currentUserID;
    public static void Main(string[] args)
    {
        LoadData();
        Console.WriteLine("\nWelcome to Syncfusion college.");
        bool flag = true;
        do
        {
            Console.WriteLine("\nMain Menu\n1. User Registration\n2. User Login\n3. Exit.");
            int choice = int.Parse(Console.ReadLine());
            
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
    public static void Registration()
    {
        Console.WriteLine("\nEnter Student Name : ");
        string userName = Console.ReadLine();
        Console.WriteLine("Enter student Gender : ");
        Gender gender = Enum.Parse<Gender>(Console.ReadLine(),true);
        Console.WriteLine("Enter student Department : ");
        Department department = Enum.Parse<Department>(Console.ReadLine(),true);
        Console.WriteLine("Enter student Mobile number : ");
        long mobileNumber = long.Parse(Console.ReadLine());
        Console.WriteLine("Enter student Mail ID : ");
        string mailID = Console.ReadLine();
        double walletBalance = 0;
        Console.WriteLine("student Wallet Balnce : " + walletBalance);

        UserDetails user = new UserDetails(userName,gender,department,mobileNumber,mailID,walletBalance);
        Console.WriteLine("student ID : "+user.UesrID);
        userList.Add(user);

    }
    public static void Login()
    {
        Console.WriteLine("\nEnter Student ID : ");
        string loginID = Console.ReadLine().ToUpper();
        bool checkStudentID = true;
        foreach(UserDetails user in userList)
        {
            if(loginID==user.UesrID)
            {
                currentUserID=user;
                checkStudentID=false;
                SubMenu();
                break;
            }
        }
        if(checkStudentID)
        {
            Console.WriteLine("Invalid User ID. Please enter a valid one.");
        }
    }
    public static void SubMenu()
    {
        bool flag=true;
        do
        {
            Console.WriteLine("\nSub menu\n1. Borrow book.\n2. Show Borrowed history.\n3. Return Books\n4. Wallet Recharge \n5. Exit");
            int choice = int.Parse(Console.ReadLine());

            switch(choice)
            {
                case 1:
                {
                    BorrowBook();
                    break;
                }
                case 2:
                {
                    ShowBorrowedHistory();
                    break;
                }
                case 3:
                {
                    ReturnBook();
                    break;
                }
                case 4:
                {
                    WalletRecharge();
                    break;
                }
                case 5:
                {
                    flag=false;
                    break;
                }
                default:
                {
                    Console.WriteLine("Invalid Option.\nPlese enter valid option.");
                    break;
                }
            }
        }while(flag);

    }
    public static void BorrowBook()
    {
        // show available book details
        foreach(BookDetails book in bookList)
        {
            Console.WriteLine("\nBook ID : "+book.BookID);
            Console.WriteLine("Book name : "+book.BookName);
            Console.WriteLine("Book author name : "+book.AuthorName);
            Console.WriteLine("Book count : "+book.BookCount);
        }
        // get book
        Console.WriteLine("\nEnter book ID : ");
        string borrowBookID = Console.ReadLine().ToUpper();
        bool checkBook=true;

        foreach(BookDetails book in bookList)
        {
            // check book ID is available
            if(borrowBookID==book.BookID)
            {
                checkBook=false;

                // check book count and get wanted book count
                Console.WriteLine("\nEnter the count of the book : ");
                int wanted = int.Parse(Console.ReadLine());

                if(book.BookCount>=wanted)
                {
                    // check sttudent how much book was borrowed
                    int count=wanted;
                    int count1=0;
                    foreach(BorrowDetails borrow in borrowList)
                    {
                        if(borrow.UserID==currentUserID.UesrID)
                        {
                            count++;
                            count1++;
                        }
                    }
                    if(count>3)
                    {
                        Console.WriteLine("You have borrowed 3 books already");
                        Console.WriteLine($"You can have maximum of 3 borrowed books. Your already borrowed books count is {count1} and requested count is {count1-3}.");
                    }
                    else
                    {
                        BorrowDetails borrow = new BorrowDetails(book.BookID,currentUserID.UesrID,DateTime.Today,wanted,Status.Borrowed,0);
                        borrowList.Add(borrow);
                        Console.WriteLine("Book borrowed successfully.");
                    }
                }
                else
                {
                    Console.WriteLine("Books are not available for the selected count.");
                    // print next available on this book ID
                    foreach(BorrowDetails borrow in borrowList)
                    {
                        if(borrow.BookID==borrowBookID)
                        {
                            DateTime date = borrow.BorrowDate.AddDays(15);
                            Console.WriteLine("\nThe book will be available on {date}");
                        }
                    }
                }
            }
        }
        if(checkBook)
        {
            Console.WriteLine("Invalid Book ID, Please enter valid ID.");
        }        
    }
    public static void ShowBorrowedHistory()
    {
        foreach(BorrowDetails borrow in borrowList)
        {
            if(currentUserID.UesrID==borrow.UserID)
            {
                Console.WriteLine("\nBorrow ID : "+borrow.BorrowID);
                Console.WriteLine("Book ID : "+borrow.BookID);
                Console.WriteLine("Borrow Date : "+borrow.BorrowDate);
                Console.WriteLine("Borrow Book Count : "+borrow.BorrowBookCount);
                Console.WriteLine("Status : "+borrow.Status);
                Console.WriteLine("Paid Fine Amount : "+borrow.PaidFineAmount);
            }
        }
    }
    public static void ReturnBook()
    {
        int calculateDays = 0;
        // show current user borrowed list
        foreach(BorrowDetails borrow in borrowList)
        {
            if(currentUserID.UesrID==borrow.UserID && borrow.Status==Status.Borrowed)
            {
                Console.WriteLine("\nBorrow ID : "+borrow.BorrowID);
                Console.WriteLine("Book ID : "+borrow.BookID);
                Console.WriteLine("Borrow date : "+borrow.BorrowDate);
                Console.WriteLine("Borrow book count : "+borrow.BorrowBookCount);
                DateTime date = borrow.BorrowDate.AddDays(15);
                Console.WriteLine("\nReturn Date : "+date);

                // calculate fine amount
                while(date.CompareTo(DateTime.Today)!=0)
                {
                    date.AddDays(1);
                    calculateDays++;
                }
            }
        }
        // print fine amount
        Console.WriteLine("\nTotal Fine amount of current user : "+calculateDays);

        // get borrow ID 
        Console.WriteLine("\nEnter return book borrow ID : ");
        string currentBorrowID = Console.ReadLine().ToUpper();

        // validate the borrow ID
        int calculateDays1 = 0;
        foreach(BorrowDetails borrow in borrowList)
        {
            if(currentBorrowID==borrow.BorrowID)
            {
                // check late return book
                DateTime date = borrow.BorrowDate.AddDays(15);
                while(date.CompareTo(DateTime.Today)!=0)
                {
                    date.AddDays(1);
                    calculateDays1++;
                }
                if(calculateDays1>0)
                {
                    if(currentUserID.WalletBalance>=calculateDays1)
                    {
                        currentUserID.DeductBalance(calculateDays1);
                        borrow.Status=Status.Returned;
                        borrow.PaidFineAmount=calculateDays1;
                        Console.WriteLine("Book returned successfully.");
                        foreach(BookDetails book in bookList)
                        {
                            if(book.BookID==borrow.BookID)
                            {
                                book.BookCount+=calculateDays1;
                            }
                        }
                    }
                    else{
                        Console.WriteLine("Insufficient balance. Please rechange and proceed");
                    }
                }
            }
        }
    }

    public static void WalletRecharge()
    {
        Console.WriteLine("\nIf you wish to recharge wallet, Enter yes : ");
        string temp = Console.ReadLine();
        if(temp=="yes")
        {
            Console.WriteLine("Enter amount : ");
            double amount = double.Parse(Console.ReadLine());
            Console.WriteLine($"\nYour balance is {currentUserID.WalletRecharge(amount)}");
        }
    }

    public static void LoadData()
    {
        UserDetails user1 = new UserDetails("Ravichandran", Gender.Male, Department.EEE, 9938388333, "ravi@gmail.com", 100);
        UserDetails user2 = new UserDetails("Priyadharshini", Gender.Female, Department.CSE, 9944444455, "priya@gmail.com", 150);

        userList.Add(user1);
        userList.Add(user2);

        BookDetails book1 = new BookDetails("C#", "Author1", 3);
        BookDetails book2 = new BookDetails("HTML", "Author2", 5);
        BookDetails book3 = new BookDetails("CSS", "Author1", 3);
        BookDetails book4 = new BookDetails("JS", "Author1", 3);
        BookDetails book5 = new BookDetails("TS", "Author2", 2);
         
        bookList.Add(book1);
        bookList.Add(book2);
        bookList.Add(book3);
        bookList.Add(book4);
        bookList.Add(book5);

        BorrowDetails borrow1 = new BorrowDetails("BID1001",	"SF3001", DateTime.ParseExact("09/10/2023","MM/dd/yyyy",null), 2, Status.Borrowed, 0);
        BorrowDetails borrow2 = new BorrowDetails("BID1003", "SF3001", DateTime.ParseExact("09/12/2023","MM/dd/yyyy",null), 1, Status.Borrowed, 0);
        BorrowDetails borrow3 = new BorrowDetails("BID1004",	"SF3001", DateTime.ParseExact("09/14/2023","MM/dd/yyyy",null), 1, Status.Returned, 16);
        BorrowDetails borrow4 = new BorrowDetails("BID1002",	"SF3002", DateTime.ParseExact("09/11/2023","MM/dd/yyyy",null), 2, Status.Borrowed, 0);
        BorrowDetails borrow5 = new BorrowDetails("BID1005",	"SF3002", DateTime.ParseExact("09/09/2023","MM/dd/yyyy",null), 1, Status.Returned, 20);

        borrowList.Add(borrow1);
        borrowList.Add(borrow2);
        borrowList.Add(borrow3);
        borrowList.Add(borrow4);
        borrowList.Add(borrow5);
    }
}