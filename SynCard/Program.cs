using System;
using System.Collections.Generic;
namespace SynCard;
class Program
{
    // list creation 
    static List<ProductClass> productsList = new List<ProductClass>();
    static List<OrderClass> orderList = new List<OrderClass>();
    static List<CustomerClass> customersList = new List<CustomerClass>();
    static CustomerClass currentCustomer;
    public static void Main(string[] args)
    {
        LoadDefaultData();
        string option="yes";
        do
        {
            Console.WriteLine();
            Console.WriteLine("Main Menu\n1. Customer Registration\n2. Login\n3. Exit");
            int choice =int.Parse(Console.ReadLine());
            switch(choice)
            {
                case 1:
                {
                    Registeration();
                    break;
                }
                case 2:
                {
                    Login();
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
    static void Registeration()
    {
        // Get the detail from customer
        Console.WriteLine("Enter Customer Name : ");
        string customerName = Console.ReadLine();
        Console.WriteLine("Enter Customer city : ");
        string city = Console.ReadLine();
        Console.WriteLine("Enter Customer Mobile number : ");
        long mobileNumber = long.Parse(Console.ReadLine());
        Console.WriteLine("Enter Customer Balance : ");
        double walletBalance=double.Parse(Console.ReadLine());
        Console.WriteLine("Enter Customer Email ID : ");
        string emailID = Console.ReadLine();

        // object create
        CustomerClass customer = new CustomerClass(customerName,city,mobileNumber,walletBalance,emailID);
        // Display customer ID
        Console.WriteLine("Your registration is successfull.");
        Console.WriteLine("Customer ID : "+customer.CustomerID);
        // add to the list
        customersList.Add(customer);
    }
    static void Login()
    {
        // get customer ID from user
        Console.WriteLine("Enter Customer ID : ");
        string loginID = Console.ReadLine().ToUpper();
        
        // validate the customer ID from customer list
        bool flag= true;
        foreach(CustomerClass customer in customersList)
        {
            if(loginID==customer.CustomerID)
            {
                currentCustomer=customer;
                flag=false;
                // Display submenu
                SubMenu();
            }
        }
        if(flag)
        {
            Console.WriteLine("Invalid Customer ID");
        }
        
    }

    static void SubMenu()
    {
        bool flag1 = true;
        do
        {
            Console.WriteLine();
            Console.WriteLine("Submenu \n1. Purchase\n2. Order History\n3. Cancel Order\n4. Wallet Balance\n5. Wallet Recharge\n6. Exit");
            int choice1 = int.Parse(Console.ReadLine());
            switch(choice1)
            {
                case 1:
                {
                    Purchase();
                    break;
                }
                case 2:
                {
                    OrderHistory();
                    break;
                }
                case 3:
                {
                    CancelOrder();
                    break;
                }
                case 4:
                {
                    WalletBalance();
                    break;
                }
                case 5:
                {
                    WalletRecharge();
                    break;
                }
                case 6:
                {
                    flag1=false;
                    break;
                }
                default:
                {
                    Console.WriteLine("Invalid Choice");
                    break;
                }
            }
        }while(flag1);
    }

    static void LoadDefaultData()
    {
        ProductClass product1 = new ProductClass("Mobile (Samsung)", 10, 10000, 3);
        ProductClass product2 = new ProductClass("Tablet (Lenovo)",	5, 15000, 2);
        ProductClass product3 = new ProductClass("Camara (Sony)", 3, 20000, 4);
        ProductClass product4 = new ProductClass("iPhone", 5, 50000, 6);
        ProductClass product5 = new ProductClass("Laptop (Lenovo I3)", 3, 40000, 3);
        ProductClass product6 = new ProductClass("HeadPhone (Boat)", 5,	1000, 2);
        ProductClass product7 = new ProductClass("Speakers (Boat)",	4, 500, 2);
        
        productsList.Add(product1);
        productsList.Add(product2);
        productsList.Add(product3);
        productsList.Add(product4);
        productsList.Add(product5);
        productsList.Add(product6);
        productsList.Add(product7);

        CustomerClass Customer1 = new CustomerClass("Ravi", "Chennai", 9885858588, 50000, "ravi@mail.com");
        CustomerClass Customer2 = new CustomerClass("Baskaran", "Chennai", 9888475757, 60000, "baskaran@mail.com");
        
        customersList.Add(Customer1);
        customersList.Add(Customer2);

        OrderClass order1 = new OrderClass("CID1001", "PID101",	20000,	DateTime.Now,	2,	OrderStatus.Ordered);
        OrderClass order2 = new OrderClass("CID1002", "PID102",	40000,	DateTime.Now,	2,OrderStatus.Ordered);
        
        orderList.Add(order1);
        orderList.Add(order2);
    }
    static void Purchase()
    {
        // display product details
        Console.WriteLine("**************Product Details******************");
        foreach(ProductClass product in productsList)
        {
            Console.WriteLine();
            Console.WriteLine("Product ID : "+product.ProductID+"\nProduct : "+ product.ProductName+"\nProduct Price : "+product.Price+"\nProduct in stock : "+product.Stock+"\nProduct Shipping Duration : "+product.ShippingDuration);
        }

        // Get product ID to be purchased by customer
        Console.WriteLine("\nEnter product ID : ");
        string productLoginID = Console.ReadLine().ToUpper();

        bool checkProductID = true;
        // validate the product ID
        foreach(ProductClass product in productsList)
        {
            if(product.ProductID==productLoginID)
            {
                checkProductID = false;
                // If valid get the quantity from the customer
                Console.WriteLine("\nEnter how much quantity you want : ");
                int wanted =  int.Parse(Console.ReadLine());

                // ensure the stock avalibility
                if(product.Stock>=wanted)
                {
                    // calculate total price
                    double price = ((product.Price)*wanted);
                    Console.WriteLine("\nTotal Price : "+(price+50));

                    // validate wallet balance
                    if(price<=currentCustomer.WalletBalance)
                    {
                        
                        // deduct the total amount from the customer wallet
                        currentCustomer.DeductBalance(price);

                        // reduce the purchase count from stock
                        product.Stock-=wanted;

                        // create object for order ID
                        OrderClass neworder = new OrderClass(currentCustomer.CustomerID,product.ProductID,price,DateTime.Now,wanted,OrderStatus.Ordered);
                        orderList.Add(neworder);

                        // display the order detail and delivary date
                        Console.WriteLine("\nOrder placed successfully. Order ID = "+neworder.OrderID);
                        Console.WriteLine("Order placed successfully. Your order will be delivered on "+DateTime.Now.AddDays(product.ShippingDuration));

                    }
                    else{
                        Console.WriteLine("Insufficient Wallet Balance. Please recharge your wallet and do purchase again");
                    }

                }
                else
                {
                    Console.WriteLine($"Required count not available. Current availability is {product.Stock}");
                }
            }
        }
        // if invalid product ID print invalid 
        if(checkProductID)
        {
            Console.WriteLine("Invalid ProductID.");
        }
    }
    static void OrderHistory()
    {
        // display current customer order history
        foreach(OrderClass order in orderList)
        {
            if(currentCustomer.CustomerID==order.CustomerID)
            {
                Console.WriteLine("Order ID = "+order.OrderID);
                Console.WriteLine("Customer ID = "+order.CustomerID);
                Console.WriteLine("Product ID = "+order.ProductID);
                Console.WriteLine("TotalPrice = "+order.TotalPrice);
                Console.WriteLine("Quantity = "+order.Quantity);
                Console.WriteLine("OrderStatus = "+order.OrderStatus);
                Console.WriteLine();
            }
        }
        
    }
    static void CancelOrder()
    {
        // display the order status of current customer
        foreach(OrderClass order in orderList)
        {
            // validate current customer order ID
            if(currentCustomer.CustomerID==order.CustomerID && OrderStatus.Ordered==order.OrderStatus)
            {
                Console.WriteLine("\nOrder ID = "+order.OrderID);
                Console.WriteLine("Customer ID = "+order.CustomerID);
                Console.WriteLine("Product ID = "+order.ProductID);
                Console.WriteLine("TotalPrice = "+order.TotalPrice);
                Console.WriteLine("Quantity = "+order.Quantity);
                Console.WriteLine("OrderStatus = "+order.OrderStatus);
            }
        }
        // get the order id from the customer
        Console.WriteLine("Enter order ID : ");
        string tempOrderID = Console.ReadLine().ToUpper();
        bool flag = true;

        // validate the order id and order status
        foreach(OrderClass order1 in orderList)
        {
            if(order1.OrderID==tempOrderID && currentCustomer.CustomerID==order1.CustomerID && order1.OrderStatus==OrderStatus.Ordered)
            {
                // refund the amount to the customer
                flag=false;
                Console.WriteLine("\nYour balance is "+currentCustomer.WalletRecharge(order1.TotalPrice));

                // refund the product quantity to product stock
                foreach(ProductClass product in productsList)
                {
                    if(product.ProductID==order1.ProductID)
                    {
                        product.Stock+=order1.Quantity;
                    }
                }

                // order status change to cancelled.
                order1.OrderStatus=OrderStatus.Cancelled;
                Console.WriteLine($"\nYour order ID {order1.OrderID} cancelled successfully.");
            }
        }
        if(flag)
        {
            // if oder ID is not valid print invalid
            Console.WriteLine("\nInvalid Order ID");
        }
        
    }
    static void WalletBalance()
    {
        // priint wallet balance
        Console.WriteLine("Your balance is "+currentCustomer.WalletBalance);
    }
    static void WalletRecharge()
    {
        // get amount to add wallet
        Console.WriteLine("Enter amount to add wallet : ");
        double amount1 = double.Parse(Console.ReadLine());

        // priint wallet balance
        Console.WriteLine("Your balance is "+currentCustomer.WalletRecharge(amount1));

    }
}