using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10258609_PRG2Assignment
{
    public static class AdvancedPartA
    {
        //method to call the AdvancedPartA
        public static Dictionary<int, Customer> ProcessOrderCheckout(Dictionary<int, Customer> customerDict, Queue<Order> goldQueue, Queue<Order> regQueue)
        {
            Order orderTocheckout = new Order();
            if (goldQueue.Count > 0) //If there are orders in the Goldqueue
            {
                orderTocheckout = goldQueue.Dequeue();

            }
            else
            {
                orderTocheckout = regQueue.Dequeue();
            }
            //display order and get most expensive ice cream price
            double[] prices = BasicReq2.DisplayDetails(orderTocheckout);
            double totalPrice = prices[1];
            Console.WriteLine("\n----------------------------------------------------------------------------------------------------\n");
            Customer orderCustomer = RetrieveCustomer(orderTocheckout, customerDict);
            orderCustomer.CurrentOrder = null;
            Console.WriteLine($"Membership Status: {orderCustomer.Rewards.Tier}");
            Console.WriteLine($"Points: {orderCustomer.Rewards.Points}");
            Console.WriteLine("\n----------------------------------------------------------------------------------------------------\n");
            //check birthday
            DateTime today = DateTime.Now;
            bool isBirthday = orderCustomer.IsBirthday();
            if (isBirthday)
            {
                Console.WriteLine($"It is your birthday! Happy Birthday {orderCustomer.Name}, have an Ice Cream on the house!");
                totalPrice -= prices[0];
                Console.WriteLine($"Total Price After Birthday Discount: {totalPrice}");
                Console.WriteLine("\n----------------------------------------------------------------------------------------------------\n");

            }
            //check if customer has completed their punch card
            if (orderCustomer.Rewards.PunchCard == 10)
            {
                if (CheckIfFirst(prices[0], orderTocheckout) && isBirthday) // if the most expensive order isnt the first and it is the customers birthday
                {
                    double punchDeduct = orderTocheckout.IceCreamList[0].CalculatePrice();
                    totalPrice -= punchDeduct;
                    Console.WriteLine($"Your Punch Card is complete! payment will be offset by an additional ${punchDeduct.ToString("0.00")}");
                    orderCustomer.Rewards.PunchCard = 0; //reset punch card
                }
                else if (!isBirthday) //it is not the customer's birthday
                {
                    double punchDeduct = orderTocheckout.IceCreamList[0].CalculatePrice();
                    totalPrice -= punchDeduct;
                    Console.WriteLine($"Your Punch Card is complete! payment will be offset by ${punchDeduct.ToString("0.00")}");
                    orderCustomer.Rewards.PunchCard = 0; //reset punch card
                }
                /*else if (!CheckIfFirst(prices[0], orderTocheckout) && isBirthday) // most expensive order is the first (and there are no repeats) and it is the customer's birthday
                {

                }*/
                Console.WriteLine("\n----------------------------------------------------------------------------------------------------\n");

            }

            //Check if customer is silver tier or above

            if (orderCustomer.Rewards.Tier != "Ordinary")
            {
                Console.WriteLine($"Number of points: {orderCustomer.Rewards.Points}");
                while (true)
                {
                    try
                    {
                        Console.Write("How many points would you like to use to offset the total bill? ");
                        int redeemPoints = Convert.ToInt32(Console.ReadLine());
                        if (redeemPoints > orderCustomer.Rewards.Points)
                        {
                            Console.WriteLine("Not enough points to redeem, please enter a smaller number. ");
                            continue;
                        }
                        else if (redeemPoints < 0)
                        {
                            Console.WriteLine("Please enter a positive number. ");
                            continue;
                        }
                        else if (redeemPoints == 0)
                        {
                            Console.WriteLine("No points will be redeemed for this transaction. ");
                        }
                        else
                        {
                            orderCustomer.Rewards.Points -= redeemPoints;
                            double pointsOffset = redeemPoints * 0.02;
                            totalPrice -= pointsOffset;
                            Console.WriteLine($"Amount offset: ${pointsOffset.ToString("0.00")}");

                        }
                        Console.WriteLine("\n----------------------------------------------------------------------------------------------------\n");

                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("please enter an integer. ");
                        continue;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Please try again. ");
                        continue;
                    }
                    break;
                }
            }

            //check if total bill is 0
            if (totalPrice < 0)
            {
                totalPrice = 0;
            }
            //Print total bill
            Console.WriteLine($"Total bill: ${totalPrice.ToString("0.00")}");
            Console.WriteLine("Press any key to make payment. ");
            Console.ReadKey();

            //increment point card
            foreach (IceCream iceCream in orderTocheckout.IceCreamList)
            {
                orderCustomer.Rewards.Punch();
            }

            //add the points
            int pointsAdd = Convert.ToInt32(Math.Floor(totalPrice * 0.72));
            orderCustomer.Rewards.AddPoints(pointsAdd);

            //save order to customer order history
            string timeFulfilled = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            orderTocheckout.TimeFulfilled = DateTime.ParseExact(timeFulfilled, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            orderCustomer.OrderHistory.Add(orderTocheckout);

            customerDict[orderCustomer.Memberid] = orderCustomer;
            Console.WriteLine("Check out successful.");
            return customerDict;
        }
        public static Customer RetrieveCustomer(Order order, Dictionary<int, Customer> CustomerDict)
        {
            foreach (KeyValuePair<int, Customer> kvp in CustomerDict) // foreach key value pair in Customer Dictionary
            {
                if (kvp.Value.CurrentOrder?.Id == order.Id) // If the Current order of the customer is the same as the order
                {
                    return kvp.Value;
                }
                foreach (Order orderHistory in kvp.Value.OrderHistory)
                {
                    if (orderHistory.Id == order.Id)
                    {
                        return kvp.Value;
                    }
                }

            }
            return null;
        }
        //method to check if there are multiple expensive orders and whether the first ice cream is the most expensive
        public static bool CheckIfFirst(double mostEx, Order order)
        {
            int count = 0;
            //check if there are repeats of the same price which is the most expensive
            foreach (IceCream iceCream in order.IceCreamList)
            {
                if (iceCream.CalculatePrice() == mostEx)
                {
                    count++;
                }
            }
            if (order.IceCreamList[0].CalculatePrice() == mostEx && count > 1) //if the first ice cream is the most expensive but there are more than 1 ice cream with the same price
            {
                return true;
            }
            else if (order.IceCreamList[0].CalculatePrice() != mostEx) // if the first ice cream is not the most expensive
            {
                return true;
            }
            else
            {
                return false; //first ice cream is the most expensive and there is only 1
            }
        }
    }
}
