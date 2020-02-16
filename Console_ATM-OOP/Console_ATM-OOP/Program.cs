using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Console_ATM_OOP
{
    class Program
    {
        string date = DateTime.Now.ToString();

        static void Main(string[] args)
        {

            List<Customer> customerList = new List<Customer>();
            customerList.Add(new Customer { Name = "Banker", Passcode = "Money", Balance = 2500000 });

            while (true)
            {
                Console.WriteLine("==================================================");
                Console.WriteLine("    Customer Confirmation. Choose below:          ");
                Console.WriteLine("==================================================");
                Console.WriteLine("[A]Returning customer [B]New customer [C]Exit ATM");

                string checkCustomer = Console.ReadLine();

                if (checkCustomer == "B")
                {
                    Console.Clear();
                    Console.WriteLine("================================================");
                    Console.WriteLine("                Hello New Customer!             ");
                    Console.WriteLine("================================================");
                    Thread.Sleep(1000);
                    Console.WriteLine("Please enter your desired Username:");
                    var userName = Console.ReadLine();
                    Console.WriteLine("Please enter your desired Passcode:");
                    var passCode = Console.ReadLine();
                    customerList.Add(new Customer { Name = userName, Passcode = passCode, Balance = 0 });

                    Thread.Sleep(3000);
                    Console.Clear();
                }
                //var listQuery = customerList.Where(w => w.Name == "Banker").Select(s => s.Balance).Sum();
                //Check specific valuee

                else if (checkCustomer == "A")
                {
                    Console.Clear();
                    Console.WriteLine("================================================");
                    Console.WriteLine("           Hello Returning Customer!            ");
                    Console.WriteLine("================================================");
                    Thread.Sleep(1000);

                    Console.WriteLine("Please enter your registered Username:");
                    var name = Console.ReadLine();

                    Console.WriteLine("Enter enter your registered Passcode:");
                    var passcode = Console.ReadLine();

                    Thread.Sleep(3000);
                    Console.Clear();

                    var customerQuery_Name = customerList.Any(p => String.Equals(p.Name, name, StringComparison.CurrentCulture));
                    var customerQuery_Passcode = customerList.Any(p => String.Equals(p.Passcode, passcode, StringComparison.CurrentCulture));

                    if (customerQuery_Name & customerQuery_Passcode == true)
                    {
                        //initialization
                        int moneyBalance = customerList.Where(w => w.Name == name).Select(s => s.Balance).Sum();


                        //List for History of Deposit and Withdraw
                        List<int> withdrawHistory = new List<int>();
                        List<int> depositHistory = new List<int>();
                        List<string> History = new List<string>();
                        
                        while (true)
                        {
                            //Program Menu
                            Console.WriteLine("================================================");
                            Console.WriteLine("            Automated Teller Machine            ");
                            Console.WriteLine("              By : Eadrian Basila               ");
                            Console.WriteLine("================================================");
                            Thread.Sleep(1000);

                            //Time
                            Program myObj = new Program();
                            Console.WriteLine(myObj.date);
                            Console.WriteLine();
                            Thread.Sleep(2000);

                            //ATM Menu
                            Console.WriteLine("================================================");
                            Console.WriteLine("What do you want to do?");
                            Console.WriteLine("[1] Deposit");
                            Console.WriteLine("[2] Withdraw");
                            Console.WriteLine("[3] Check Balance");
                            Console.WriteLine("[4] Review ATM History");
                            Console.WriteLine("[5] Exit");
                            Console.WriteLine("================================================");
                            Console.WriteLine();

                            //choosing transaction
                            Console.Write("Please enter your choice:  ");
                            int option = Convert.ToInt32(Console.ReadLine());

                            if (option == 1)
                            {
                                Thread.Sleep(1000);
                                Console.WriteLine("You chose to Deposit");
                                Console.WriteLine("================================================");
                                Thread.Sleep(1000);
                                Console.WriteLine("Preparing ATM...");
                                Thread.Sleep(3000);

                                Console.WriteLine("Please enter the amount you want to Deposit:  ");
                                int amountDeposit = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("================================================");
                                Thread.Sleep(2000);

                                if ((amountDeposit % 100 == 0) && (amountDeposit > 99))
                                {
                                    Console.WriteLine("You have succesfully deposited {0} pesos.", amountDeposit);
                                    moneyBalance += amountDeposit;
                                    depositHistory.Add(amountDeposit);
                                    History.Add(myObj.date);
                                    Thread.Sleep(4000);
                                    Console.Clear();
                                }
                                else
                                {
                                    Console.WriteLine("You have not succesfully deposited {0} pesos.", amountDeposit);
                                    Console.WriteLine("[!]Transaction Error");
                                    Thread.Sleep(4000);
                                    Console.Clear();
                                }
                            }

                            else if (option == 2)
                            {
                                Thread.Sleep(1000);
                                Console.WriteLine("You chose to Withdraw");
                                Console.WriteLine("================================================");
                                Thread.Sleep(1000);
                                Console.WriteLine("Preparing ATM...");
                                Thread.Sleep(3000);

                                Console.WriteLine("Please enter the amount you want to withdraw:  ");
                                int amountWithdraw = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("================================================");
                                Thread.Sleep(2000);

                                if ((moneyBalance > amountWithdraw) && (amountWithdraw % 100 == 0))
                                {
                                    Console.WriteLine("You have succesfully withdrawn {0} pesos.", amountWithdraw);
                                    moneyBalance -= amountWithdraw;
                                    withdrawHistory.Add(amountWithdraw);
                                    History.Add(myObj.date);
                                    Thread.Sleep(4000);
                                    Console.Clear();
                                }
                                else if ((moneyBalance < amountWithdraw) && (amountWithdraw % 100 == 0))
                                {
                                    Console.WriteLine("You have not succesfully withdrawn {0} pesos.", amountWithdraw);
                                    Console.WriteLine(" [!]Insufficient Balance");
                                    Thread.Sleep(4000);
                                    Console.Clear();
                                }
                                else if ((moneyBalance > amountWithdraw) && (amountWithdraw % 100 != 0))
                                {
                                    Console.WriteLine("You have not succesfully withdrawn {0} pesos.", amountWithdraw);
                                    Console.WriteLine("[!]The amount should be in hundreds to continue");
                                    Thread.Sleep(4000);
                                    Console.Clear();
                                }
                                else
                                {
                                    Console.WriteLine("You have not succesfully withdrawn {0} pesos.", amountWithdraw);
                                    Console.WriteLine("[!]Transaction Error");
                                    Thread.Sleep(4000);
                                    Console.Clear();
                                }
                            }

                            else if (option == 3)
                            {
                                Thread.Sleep(1000);
                                Console.WriteLine("You chose to Check your Balance");
                                Console.WriteLine("================================================");
                                Thread.Sleep(1000);
                                Console.WriteLine("Preparing ATM...");
                                Thread.Sleep(3000);

                                Console.WriteLine("Your balance is {0} pesos.", moneyBalance);
                                Console.WriteLine("================================================");
                                Thread.Sleep(4000);
                                Console.Clear();
                            }

                            else if (option == 4)
                            {
                                Thread.Sleep(1000);
                                Console.WriteLine("You chose to Review your ATM History");
                                Console.WriteLine("================================================");
                                Thread.Sleep(1000);
                                Console.WriteLine("Preparing ATM...");
                                Thread.Sleep(2000);
                                Console.Clear();

                                Console.WriteLine("================================================");
                                Console.WriteLine("Your ATM Transaction");
                                Console.WriteLine();

                                Console.WriteLine("Transaction History:");
                                foreach (var transaction in History)
                                {
                                    Console.WriteLine("[ " + transaction + " ]");
                                }

                                Console.WriteLine();
                                Console.WriteLine("Your Deposit History:");
                                foreach (var amountDeposit in depositHistory)
                                {
                                    Console.WriteLine("[ " + amountDeposit + " ]");
                                }

                                Console.WriteLine();
                                Console.WriteLine("Your Withdraw History: ");
                                foreach (var amountWithdraw in withdrawHistory)
                                {
                                    Console.WriteLine("[ " + amountWithdraw + " ]");
                                }

                                Console.WriteLine();
                                Console.WriteLine("================================================");
                                Thread.Sleep(9000);
                                Console.Clear();
                            }

                            else if (option == 5)
                            {
                                Thread.Sleep(1000);
                                Console.WriteLine("You chose to exit ATM");
                                Console.WriteLine("================================================");
                                Thread.Sleep(1000);
                                Console.WriteLine("Preparing to shutdown ATM..");
                                Thread.Sleep(5000);
                                Console.WriteLine("Goodbye!");
                                Console.WriteLine("================================================");
                                Thread.Sleep(1000);
                                Console.Clear();
                                break;
                            }

                            else
                            {
                                Console.WriteLine("Invalid Entry, Try Again!");
                                Thread.Sleep(2000);
                                Console.Clear();
                            }
                        }
                    }

                    else
                    {
                        Console.WriteLine("================================================");
                        Console.WriteLine("Check your Name and Passcode. Please try again. ");
                        Console.WriteLine("================================================");

                    }
                }

                else if (checkCustomer == "C")
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("You chose to exit ATM");
                    Console.WriteLine("================================================");
                    Thread.Sleep(1000);
                    Console.WriteLine("Preparing to shutdown ATM..");
                    Thread.Sleep(5000);
                    Console.WriteLine("Goodbye!");
                    Console.WriteLine("================================================");
                    Thread.Sleep(1000);
                    Console.Clear();
                    break;
                }

                
                else
                {
                    Console.WriteLine("Kindly choose from the options above.");
                    Thread.Sleep(4000);
                    Console.Clear();
                }
            }
        }
    }
}