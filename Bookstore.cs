using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace BookstoreSystem
{
    abstract class Features
    { 
        protected abstract void SignUp();
        protected abstract void LogIn();
        protected abstract void BookstoreInterface(Account acc);
        protected abstract void BrowseBooks(Account acc);
        protected abstract void SearchBook(Account acc);
        protected abstract void CartInventory(Account acc);
        protected abstract void AddToCart(Account acc, Book book);
        protected abstract void Buy(Account acc, double Total);
    }
    class Bookstore : Features
    {
        static List<Book> Library = new List<Book>
        { 
            new Book("Chess with Garry","12412",1222.45,"Garry Kasparov"),
            new Book("How to C++ with Shann", "16432", 560.65, "Shann Delfin C. Salamingan III"),
            new Book("Be better", "1240", 785.97, "Shaina Kylie Salamingan")
        };
        static List<Account> Accounts = new List<Account>
        {
            new Account("helloshann@gmail.com", "ok1232", "2541521","Caturla Salamingan", "Purok 4 San Juan, Surigao City",
                8400),
            new Account("salamingan@gmail.com", "Shann123", "093125211","Shann Delfin C. Salamingan III", "Purok 4 San Juan, Surigao City",
                8400, new Dictionary<Book, int>{{Library[1], 2}}),
            new Account("shann@gmail.com", "delfin123", "091242151", "Shanyny Caturla", "Purok 6 San Juan, Surigao City", 8400
                ,new Dictionary<Book, int>{ {Library[0], 2 },{Library[2], 1 } })
        };

        public void Run()
        {
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("Online Bookstore\n1. Log-In\n2. Sign Up");
                string chosenStr = Console.ReadLine();
                if (UInt16.TryParse(chosenStr, out UInt16 chosen))
                {
                    Console.Clear();
                    switch (chosen)
                    {
                        case 1:
                            LogIn();
                            break;
                        case 2:
                            SignUp();
                            break;
                        default:
                            Console.WriteLine("\nInvalid choice. Please choose 1 or 2.");
                            Console.Write("Press any key to exit. ");
                            Console.ReadKey();
                            break;
                    }
                    Console.Clear();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\nInvalid input. Please enter a valid number (1 or 2).");
                    Console.Write("Press any key to exit. ");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

        }
        // the very Bookstore
        protected override void BookstoreInterface(Account acc)
        {
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("Welcome {0}! ", acc.Username);
                Console.WriteLine("1. Browse Books\n2. Search Books\n3. Cart Inventory\n4. Exit");
                string chosenStr = Console.ReadLine();
                if (UInt16.TryParse(chosenStr, out UInt16 chosen))
                {
                    Console.Clear();
                    switch (chosen)
                    {
                        case 1:
                            BrowseBooks(acc);
                            break;
                        case 2:
                            SearchBook(acc);
                            break;
                        case 3:
                            CartInventory(acc);
                            break;
                        case 4:
                            Console.WriteLine("Thank You, Come Again!");
                            loop = false;
                            break;
                        default:
                            Console.WriteLine("\nInvalid choice. Please choose 1 or 2.");
                            Console.Write("Press any key to exit. ");
                            Console.ReadKey();
                            break;
                    }
                    Console.Clear();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\nInvalid input. Please enter a valid number (1 or 2).");
                    Console.Write("Press any key to exit. ");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
        protected override void Buy(Account acc, double Total)
        {
            double Cash;
            do
            {
                Console.Clear();
                Console.WriteLine("Total: {0}", Total);
                Console.Write("Enter your cash: ");
                Cash = Convert.ToDouble(Console.ReadLine());
                if(Cash > Total)
                {
                    double change = Cash - Total;
                    Console.WriteLine("Username: {0}",acc.Username);
                    Console.WriteLine("Address: {0}",acc.Address);
                    Console.WriteLine("ZipCode: {0}", acc.ZipCode);
                    Console.WriteLine("Change: {0}", change.ToString("F2")); // format it correctly
                    Console.WriteLine("Successfully Purchased!");
                    acc.CartInventory.Clear(); // remove all inventory
                    Console.Write("Press any key to exit. ");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Insufficient Cash!");
                    Console.Write("Press any key to exit. ");
                    Console.ReadKey();
                }
            } while (Total > Cash);

        }
        protected override void AddToCart(Account acc, Book book)
        {
            if (acc.CartInventory.ContainsKey(book))
            {
                // Increment the count if the element is a duplicate
                acc.CartInventory[book]++;
            }
            else
            {
                // Add the element to the dictionary with a count of 1
                acc.CartInventory[book] = 1;
            }  
        }
        protected override void CartInventory(Account acc)
        {
            if (acc.CartInventory.Count > 0)
            {             
                Console.WriteLine("Your Cart Inventory: ");
                UInt16 Count = 1;
                double Total = 0;
                foreach (var i in acc.CartInventory)
                {
                    Console.WriteLine("{0}. {1}x {2}, by {3}.", Count, i.Value, i.Key.Title, i.Key.Author);
                    Console.WriteLine("    Price each: {0}  ", i.Key.Price);
                    Total += i.Key.Price * i.Value; // Calculate the Piece
                    Count++;
                }
                Console.WriteLine("Total: {0}", Total);
                bool loop = true;
                while (loop)
                {
                    Console.WriteLine("Do you want to buy now?\n1. Yes\n2. No");
                    string chosenStr = Console.ReadLine();
                    if (UInt16.TryParse(chosenStr, out UInt16 chosen))
                    {
                        Console.Clear();
                        switch (chosen)
                        {
                            case 1:
                                Buy(acc, Total);
                                loop = false;
                                break;
                            case 2:
                                loop = false;
                                break;
                            default:
                                Console.WriteLine("\nInvalid choice. Please choose 1 or 2.");
                                Console.Write("Press any key to exit. ");
                                Console.ReadKey();
                                break;
                        }
                        Console.Clear();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("\nInvalid input. Please enter a valid number (1 or 2).");
                        Console.Write("Press any key to exit. ");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
            }
            else
            {
                Console.WriteLine("No Cart Yet! Try to browse or search for Books!");
                Console.Write("Press any key to exit. ");
                Console.ReadKey();
            }

        }
        protected override void BrowseBooks(Account acc)
        {
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("These are the Available Books: ");
                Console.WriteLine();

                for (UInt16 i = 0; i < Library.Count; i++)
                {
                    Console.WriteLine("Book #{0}: ", i + 1);
                    Console.WriteLine("Title: {0} ", Library[i].Title);
                    Console.WriteLine("BookID: {0} ", Library[i].BookID);
                    Console.WriteLine("Price: {0} ", Library[i].Price);
                    Console.WriteLine("Author: {0} ", Library[i].Author);
                    Console.WriteLine();
                }
                Console.Write("Choose the Number: ");
                string chosenStr = Console.ReadLine();
                Console.Clear();
                if (UInt16.TryParse(chosenStr, out UInt16 chosen))
                {
                    chosen--;
                    Console.Clear();
                    if (chosen < 0 || chosen > Library.Count)
                    {
                        Console.WriteLine("Out of Bounds!");
                    }
                    else
                    {
                        bool loop2 = true;
                        while (loop2)
                        {
                            Console.Clear();
                            Console.WriteLine("You chose this book:");
                            Console.WriteLine("Title: {0} ", Library[chosen].Title);
                            Console.WriteLine("BookID: {0} ", Library[chosen].BookID);
                            Console.WriteLine("Price: {0} ", Library[chosen].Price);
                            Console.WriteLine("Author: {0} ", Library[chosen].Author);
                            Console.WriteLine();
                            Console.WriteLine("Do you want to add to cart?\n1. Yes\n2. No");
                            string Yes_No = Console.ReadLine();
                            Console.Clear();
                            if (UInt16.TryParse(Yes_No, out UInt16 yes_no))
                            {
                                Console.Clear();
                                switch (yes_no)
                                {
                                    case 1:
                                        Console.WriteLine("Successfully Added to the Inventory!");
                                        Console.Write("Press any key to exit. ");
                                        Console.ReadKey();
                                        AddToCart(acc, Library[chosen]); // add to cart
                                        loop = false;
                                        loop2 = false;
                                        break;
                                    case 2:
                                        loop = false;
                                        loop2 = false;
                                        break;
                                    default:
                                        Console.WriteLine("\nInvalid choice. Please choose 1 or 2.");
                                        Console.Write("Press any key to exit. ");
                                        Console.ReadKey();
                                        break;
                                }
                                Console.Clear();
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("\nInvalid input. Please enter a valid number (1 or 2).");
                                Console.Write("Press any key to exit. ");
                                Console.ReadKey();
                                Console.Clear();
                            }
                        }
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\nInvalid input. Please enter a valid number.");
                    Console.Write("Press any key to exit. ");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
        protected override void SearchBook(Account acc)
        {
            bool loop = true;
            while (loop)
            {
                Console.Write("Enter Book ID: ");
                string BookID = Console.ReadLine();
                Book bookFound = Library.Find(book => book.BookID == BookID);
                Console.Clear();
                if (bookFound != null)
                {
                    bool loop2 = true;
                    while (loop2)
                    {
                    Console.WriteLine("Book Found!");
                    Console.WriteLine("Title: {0} ", bookFound.Title);
                    Console.WriteLine("BookID: {0} ", bookFound.BookID);
                    Console.WriteLine("Price: {0} ", bookFound.Price);
                    Console.WriteLine("Author: {0} ", bookFound.Author);
                    Console.WriteLine("Do you want to add to cart?\n1. Yes\n2. No");
                    string chosenStr = Console.ReadLine();
                    Console.Clear();
                        if (UInt16.TryParse(chosenStr, out UInt16 chosen))
                        {
                            Console.Clear();
                            switch (chosen)
                            {
                                case 1:
                                    Console.WriteLine("Successfully Added to the Inventory!");
                                    Console.Write("Press any key to exit. ");
                                    Console.ReadKey();
                                    AddToCart(acc, bookFound); // add to cart
                                    loop = false;
                                    loop2 = false;
                                    break;
                                case 2:
                                    loop = false;
                                    loop2 = false;
                                    break;
                                default:
                                    Console.WriteLine("\nInvalid choice. Please choose 1 or 2.");
                                    Console.Write("Press any key to exit. ");
                                    Console.ReadKey();
                                    break;
                            }
                            Console.Clear();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("\nInvalid input. Please enter a valid number (1 or 2).");
                            Console.Write("Press any key to exit. ");
                            Console.ReadKey();
                            Console.Clear();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Book Not Found!");
                    Console.WriteLine("Please Try Again!");
                    Console.Write("Press any key to continue. ");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
        // Sign Up
        protected override void SignUp()
        {
            Account acc = new Account();
            Console.Write("Enter your Email: ");
            acc.Email = Console.ReadLine();

            Console.Write("Create your Passowrd: ");
            acc.Password = Console.ReadLine();

            Console.Write("Enter your PhoneNumber: ");
            acc.PhoneNumber = Console.ReadLine();

            Console.Write("What Should we Call you?: ");
            acc.Username = Console.ReadLine();

            Console.Write("Enter your Address: ");
            acc.Address = Console.ReadLine();

            Console.Write("Enter your ZipCode: ");
            acc.ZipCode = Convert.ToInt32(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("Standby.......");
            Thread.Sleep(1000);
            Accounts.Add(acc);
            Console.Clear();
            Console.WriteLine("Successfully Added!");
            Console.Write("Press any key to continue. ");
            Console.ReadKey();
            Console.Clear();
        }
        // Log in
        protected override void LogIn()
        {
            Console.Write("Enter your Email: ");
            string Email = Console.ReadLine();
            Account foundEmail = Accounts.Find(acc => acc.Email == Email);
            Console.Clear();
            string Password;
            if(foundEmail != null)
            {
                do
                {
                    Console.WriteLine("Hi! {0}!", foundEmail.Username);
                    Console.Write("Please Enter your Password: ");
                    Password = Console.ReadLine();
                    Console.Clear();
                    if (foundEmail.Password == Password)
                    {
                        Console.WriteLine("Successfully Log-in!");
                        Console.Write("Press any key to continue. ");
                        Console.ReadKey();
                        Console.Clear();
                        BookstoreInterface(foundEmail);
                    }
                    else
                    {
                        Console.WriteLine("Not Correct Passowrd!");
                        Console.WriteLine("Please Try Again!");
                        Console.Write("Press any key to continue. ");
                        Console.ReadKey();
                        Console.Clear();
                    }
                } while (foundEmail.Password != Password);
            }
            else
            {
                Console.WriteLine("Email Not Found!");
                Console.WriteLine("Please Try Again!");
                Console.Write("Press any key to continue. ");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
