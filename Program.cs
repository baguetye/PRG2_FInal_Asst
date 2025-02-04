using S10257201_PRG2Assignment;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//==========================================================
// Student Number : S10258609
// Student Name : Bryan Lim Aik Sian
// Partner Name : Balakrishnan Rubanaasri
//==========================================================

namespace S10258609_PRG2Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // retrieve the customerDict from BasicReq1.cs
            ArrayList arrayList = BasicReq1.ReadCustomersFile();
            Dictionary<int, Customer> customerDict = (Dictionary<int, Customer>)arrayList[1];

            // creating gold & reg queues to add the orders to
            Queue<Order> goldQueue = new Queue<Order>();
            Queue<Order> regQueue = new Queue<Order>();

            // orderId list & order dict
            List<int> orderIdList = new List<int>();
            Dictionary<int, List<Order>> ordersDict = DisplayAndRead.ReadOrdersFile(orderIdList);
            BasicReq5.AddOrderDetails(customerDict, ordersDict);
            DisplayAndRead.UpdateQueues(goldQueue, regQueue, customerDict);

            // list containing all orderObjs
            List<Order> orderObjs = new List<Order>();

            //Display table for First Submission
            while (true)
            {
                DisplayAndRead.DisplayTable();
                try
                {
                    Console.Write("Please enter an option: ");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    if (choice == 1)
                    {
                        //basic req 1 code
                        Console.WriteLine("---------------------------------- List all customers' information ---------------------------------\n");
                        BasicReq1.ListAllCustomers(arrayList);
                        continue;
                    }
                    else if (choice == 2)
                    {
                        //basic req 2 code
                        BasicReq2.ListAllCurrentOrders(regQueue, goldQueue);

                    }
                    else if (choice == 3)
                    {
                        //basic req 3 code
                        Console.WriteLine("-------------------------------------- Register a new customer -------------------------------------\n");
                        BasicReq3.RegisterNewCustomer(customerDict);
                        arrayList = BasicReq1.ReadCustomersFile();
                        customerDict = (Dictionary<int, Customer>)arrayList[1];
                        continue;
                    }
                    else if (choice == 4)
                    {
                        //basic req 4
                        Console.WriteLine("---------------------------------------- Create an order --------------------------------------------\n");

                        BasicReq1.ListAllCustomers(arrayList);
                        BasicReq4.CreateOrder(customerDict, orderIdList, goldQueue, regQueue);
                    }
                    else if (choice == 5)
                    {
                        Console.WriteLine("-------------------------------- Display Order Details Of a Customer -------------------------------\n");
                        BasicReq1.ListAllCustomers(arrayList);
                        Customer chosenCustomer = BasicReq5.RetrieveCustomer(customerDict, orderIdList);
                        BasicReq5.DisplayOrderDetails(chosenCustomer);
                        continue;
                    }
                    else if (choice == 6)
                    {
                        Console.WriteLine("--------------------------------------- Modify Order Details ---------------------------------------\n");
                        BasicReq1.ListAllCustomers(arrayList);
                        Customer chosenCustomer = BasicReq5.RetrieveCustomer(customerDict, orderIdList);
                        if (chosenCustomer.CurrentOrder != null) // if there is an order
                        {
                            while (true)
                            {
                                try
                                {
                                    DisplayAndRead.Option6Table();
                                    Console.Write("Please enter an option: ");
                                    int option = Convert.ToInt32(Console.ReadLine());
                                    if (option == 1)
                                    {
                                        if (chosenCustomer.CurrentOrder.IceCreamList.Count == 1) // if there is only one order
                                        {
                                            chosenCustomer.CurrentOrder.ModifyIceCream(0);
                                            continue;
                                        }

                                        else
                                        {
                                            while (true)
                                            {
                                                try
                                                {
                                                    Console.WriteLine("\n----------------------------------------------------------------------------------------------------\n");
                                                    Console.WriteLine("Select which Ice Cream you would like to modify");
                                                    int index = 1;
                                                    foreach (IceCream iceCream in chosenCustomer.CurrentOrder.IceCreamList)
                                                    {
                                                        Console.WriteLine($"[{index}] Ice Cream {iceCream.Option} ({iceCream.Scoops} Scoop)");
                                                        index++;
                                                    }
                                                    Console.Write("Please enter an option: ");
                                                    int edit = Convert.ToInt32(Console.ReadLine()) - 1;
                                                    if (edit < 0 || edit > chosenCustomer.CurrentOrder.IceCreamList.Count)
                                                    {
                                                        Console.WriteLine("Please enter a valid option. ");
                                                        continue;
                                                    }
                                                    //code to modify ice cream 
                                                    chosenCustomer.CurrentOrder.ModifyIceCream(edit);
                                                    continue;
                                                }
                                                catch (FormatException)
                                                {
                                                    Console.WriteLine("Please enter an integer. ");
                                                    continue;
                                                }
                                                catch (Exception)
                                                {
                                                    Console.WriteLine("Please try again. ");
                                                    continue;
                                                }
                                            }
                                        }

                                    }
                                    else if (option == 2)
                                    {
                                        BasicReq4.OrderDetails(chosenCustomer.CurrentOrder);
                                    }
                                    else if (option == 3)
                                    {
                                        Console.WriteLine("\n----------------------------------------------------------------------------------------------------\n");
                                        if (chosenCustomer.CurrentOrder.IceCreamList.Count == 1)
                                        {
                                            Console.WriteLine("There is only one Ice Cream in the order. The order cannot have 0 Ice Cream.");
                                            Console.WriteLine("Please select another option. ");
                                            continue;
                                        }
                                        while (true)
                                        {
                                            try
                                            {
                                                Console.WriteLine("Select which Ice Cream you would like to Delete");
                                                int index = 1;
                                                foreach (IceCream iceCream in chosenCustomer.CurrentOrder.IceCreamList)
                                                {
                                                    Console.WriteLine($"[{index}] Ice Cream {iceCream.Option} ({iceCream.Scoops} Scoop)");
                                                    index++;
                                                }
                                                Console.Write("Please enter an option: ");
                                                int delete = Convert.ToInt32(Console.ReadLine()) - 1;
                                                if (delete < 0 || delete > chosenCustomer.CurrentOrder.IceCreamList.Count)
                                                {
                                                    Console.WriteLine("Please enter a valid option. ");
                                                    continue;
                                                }
                                                chosenCustomer.CurrentOrder.DeleteIceCream(delete);
                                                Console.WriteLine("Ice Cream has been deleted from the current order");
                                                break;
                                            }
                                            catch (FormatException)
                                            {
                                                Console.WriteLine("Please enter an integer. ");
                                                continue;
                                            }
                                            catch (Exception)
                                            {
                                                Console.WriteLine("Please try again. ");
                                                continue;
                                            }
                                        }
                                    }
                                    else if (option == 0)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Please enter a valid option. ");
                                        continue;
                                    }
                                    break;
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Please enter an integer.");
                                    continue;
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("Please try again.");
                                    continue;
                                }

                            }
                        }
                        else
                        {
                            Console.WriteLine("There are no current orders, please choose option 4 if you would like to make an order");
                            continue;
                        }

                        BasicReq6.UpdateQueue(chosenCustomer.CurrentOrder, goldQueue, regQueue);
                    }
                    else if (choice == 7)
                    {
                        customerDict = AdvancedPartA.ProcessOrderCheckout(customerDict, goldQueue, regQueue);
                    }
                    else if (choice == 8)
                    {
                        Console.WriteLine("-------------------------------------- Display charged amount breakdown -------------------------------------\n");
                        AdvancedPartB.ChargeBreakdowns(customerDict);
                    }
                    else if (choice == 0)
                    {
                        DisplayAndRead.RetrieveOrders(orderObjs, goldQueue, regQueue, customerDict);
                        DisplayAndRead.AppendOrders(orderObjs, customerDict);
                        DisplayAndRead.OverwriteCustomerFile(customerDict);
                        Console.WriteLine("Thank you for visiting our I.C.Treats, see you soon!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid option");
                        continue;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter an integer");
                    continue;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Please try again.");
                }

            }





        }

    }
}