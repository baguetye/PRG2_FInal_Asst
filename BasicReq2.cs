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
    public static class BasicReq2
    {
        //Basic Requirement - 2) List all current orders in gold queue and reg queue
        //method to display the order details
        public static double[] DisplayDetails(Order order)
        {
            double mostEx = 0;
            Console.WriteLine("Order ID: " + order.Id);
            Console.WriteLine("Order Details: ");
            double cost = 0;
            foreach (IceCream iceCream in order.IceCreamList)
            {
                Console.WriteLine("\t- Option: " + iceCream.Option);
                Console.WriteLine("\t- Number of Scoops: " + iceCream.Scoops);
                //check how many scoops the ice cream has to determine the words displayed on console
                if (iceCream.Scoops > 1)
                {
                    Console.WriteLine("\t- Ice Cream Flavours: \n");
                    foreach (Flavour flavour in iceCream.Flavours)
                    {
                        if (flavour.Quantity > 1)
                        {
                            Console.WriteLine($"\t {flavour.Type} ( {flavour.Quantity} scoops )");
                        }
                        else
                        {
                            Console.WriteLine($"\t {flavour.Type} ({flavour.Quantity} scoop)");
                        }
                    }
                }
                else
                {
                    Console.Write($"\t- Ice Cream Flavour: {iceCream.Flavours[0].Type} ({iceCream.Flavours[0].Quantity} scoop)");
                }
                Console.WriteLine();
                //data validation to check if there are toppings since toppings are optional
                if (iceCream.Toppings.Count > 1)
                {
                    Console.WriteLine("\t- Ice Cream Toppings: \n");
                    foreach (Topping topping in iceCream.Toppings)
                    {
                        if (topping.Type != null)
                        {
                            Console.WriteLine("\t" + topping.Type);
                        }
                    }
                    Console.WriteLine();
                }
                else if (iceCream.Toppings.Count == 1)
                {
                    Console.WriteLine("\t- Ice Cream Topping: " + iceCream.Toppings[0].Type);
                }
                else
                {
                    Console.WriteLine();
                }
                //validation to check if it should show waffle flavour or cone details
                if (iceCream is Waffle)
                {
                    Waffle waffle = (Waffle)iceCream;
                    Console.WriteLine($"\t -Waffle Flavour: {waffle.WaffleFlavour}");
                }
                else if (iceCream is Cone)
                {
                    Cone cone = (Cone)iceCream;
                    if (cone.Dipped)
                    {
                        Console.WriteLine("\t -Cone: Chocolate-Dipped");
                    }
                    else
                    {
                        Console.WriteLine("\t -Cone: Normal");
                    }
                }
                Console.WriteLine($"Price: ${iceCream.CalculatePrice().ToString("0.00")}\n");
                cost += iceCream.CalculatePrice();
                if (iceCream.CalculatePrice() > mostEx)
                {
                    mostEx = iceCream.CalculatePrice();
                }
            }
            Console.WriteLine($"Total Price: ${cost.ToString("0.00")}");
            double[] prices = { mostEx, cost };
            return prices;
        }
        //method to display the details for the order
        public static void DisplayOrders(Queue<Order> orders)
        {
            foreach (Order order in orders)
            {
                DisplayDetails(order);
                Console.WriteLine("Time ordered: " + order.TimeReceived.ToString());
            }
        }

        public static void ListAllCurrentOrders(Queue<Order> regQueue, Queue<Order> goldQueue)
        {
            //Start with gold queue since their orders will be fulfilled first

            Console.WriteLine("\n---------------------------------------- Orders in Gold Queue ----------------------------------------\n");
            //Data validation to check if there are people in the Gold Queue
            if (goldQueue.Count == 0)
            {
                Console.WriteLine("There are no orders in the Gold Queue\n");
            }
            else
            {
                DisplayOrders(goldQueue);

            }

            //List the orders in regular queue
            Console.WriteLine("\n-------------------------------------- Orders in Regular Queue --------------------------------------\n");
            //Data validation to check if there are people in the regular queue
            if (regQueue.Count == 0)
            {
                Console.WriteLine("There are no orders in the Regular Queue\n");
            }
            else
            {
                DisplayOrders(regQueue);

            }

        }

    }
}
