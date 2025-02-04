using System;
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
    public static class BasicReq5
    {
        public static Customer RetrieveCustomer(Dictionary<int, Customer> customersDict, List<int> orderIdList) // added list into this
        {
            /* //call method to store customers as dictionary
             Dictionary<int, List<Order>> ordersDict = DisplayAndRead.ReadOrdersFile(orderIdList); //added list 
             AddOrderDetails(customersDict, ordersDict);*/

            //prompt user to select customer
            while (true)
            {
                try
                {
                    Console.Write("\nPlease enter the Member ID of the customer: ");
                    int memberID = Convert.ToInt32(Console.ReadLine());
                    if (customersDict.ContainsKey(memberID))
                    {
                        return customersDict[memberID];
                    }
                    else
                    {
                        Console.WriteLine("Member ID not found.");
                        Console.WriteLine("\n----------------------------------------------------------------------------------------------------");
                        continue;
                    }

                }
                catch (FormatException)
                {
                    Console.WriteLine("Member ID should only contain integers. Please try again.");
                    Console.WriteLine("\n----------------------------------------------------------------------------------------------------");
                    continue;
                }

            }
        }


        //method to add order Details for customers
        public static void AddOrderDetails(Dictionary<int, Customer> customersDict, Dictionary<int, List<Order>> ordersDict)
        {
            //
            foreach (KeyValuePair<int, Customer> kvp in customersDict)
            {
                if (ordersDict.ContainsKey(kvp.Key))
                {

                    //Check if it is order history or current order
                    foreach (Order order in ordersDict[kvp.Key])
                    {
                        if (order.TimeFulfilled != null)
                        {
                            kvp.Value.OrderHistory.Add(order);
                        }
                        else
                        {
                            kvp.Value.CurrentOrder = order;
                        }
                    }
                }
            }
        }
        //method to display order details

        //Method to display the order details

        public static void DisplayOrderDetails(Customer customer)
        {
            Console.WriteLine($"Name of Customer: {customer.Name}\n");
            //This code is to display the current order details
            Console.WriteLine("--------------------------------------- Current Order Details --------------------------------------\n");
            if (customer.CurrentOrder != null)
            {
                BasicReq2.DisplayDetails(customer.CurrentOrder);
                Console.WriteLine("Time Recieved: {0}", customer.CurrentOrder.TimeReceived.ToString());
            }
            else
            {
                Console.WriteLine("There are no current orders");
            }


            //This code is to display the order history details
            Console.WriteLine("\n--------------------------------------- Order History Details --------------------------------------\n");
            if (customer.OrderHistory.Count() != 0 && customer.OrderHistory.Count() > 1)
            {
                foreach (Order order in customer.OrderHistory)
                {
                    Console.WriteLine("----------------------------------------------------------------------------------------------------\n");
                    BasicReq2.DisplayDetails(order);
                    Console.WriteLine("Time Recieved: {0}", order.TimeReceived.ToString());
                    Console.WriteLine("Time Fulfilled: {0}\n", order.TimeFulfilled.ToString());

                }

                Console.WriteLine("----------------------------------------------------------------------------------------------------\n");
            }
            else
            {
                Console.WriteLine("There is no Order History saved");
            }

        }



    }
}
