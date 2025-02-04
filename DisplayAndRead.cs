using S10257201_PRG2Assignment;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    public static class DisplayAndRead
    {
        //method to display a table with options for the user to choose
        public static void DisplayTable()
        {
            Console.WriteLine("\n-------------------------------------------- I.C Treats --------------------------------------------\n");
            Console.WriteLine("[1] List All Customers");
            Console.WriteLine("[2] List All Current Orders");
            Console.WriteLine("[3] Register a New Customer");
            Console.WriteLine("[4] Create a Customer's Order");
            Console.WriteLine("[5] Display Order Details Of a Customer");
            Console.WriteLine("[6] Modify Order Details");
            Console.WriteLine("[7] Process Checkout");
            Console.WriteLine("[8] Get monthly charged amount breakdown for a specific year");
            Console.WriteLine("[0] Exit");
            Console.WriteLine("\n----------------------------------------------------------------------------------------------------\n");

        }
        //method to display modify order details table with options

        public static void Option6Table()
        {
            Console.WriteLine("\n----------------------------------------------------------------------------------------------------\n");
            Console.WriteLine("[1] Modify Existing Ice Cream Order");
            Console.WriteLine("[2] Create New Ice Cream Order");
            Console.WriteLine("[3] Delete Existing Ice Cream");
            Console.WriteLine("[0] Exit");
            Console.WriteLine("\n----------------------------------------------------------------------------------------------------\n");
        }
        public static void ModifyIceCreamDisplay(string option)
        {
            Console.WriteLine("\n------------------------------------- Modifying Ice Cream Order ------------------------------------\n");
            Console.WriteLine("[1] Modify Ice Cream Option");
            Console.WriteLine("[2] Modify Ice Cream Scoops");
            Console.WriteLine("[3] Modify Ice Cream Flavour");
            Console.WriteLine("[4] Modify Ice Cream Toppings");
            if (option == "Waffle")
            {
                Console.WriteLine("[5] Modify Waffle Flavour");
            }
            else if (option == "Cone")
            {
                Console.WriteLine("[5] Modify Ice Cream Cone Details");
            }
            Console.WriteLine("[0] Return to previous section");
            Console.WriteLine("\n----------------------------------------------------------------------------------------------------\n");
        }
        public static void ICFlavoursDisplay()
        {
            Console.WriteLine("\n---------------------------------------- Ice Cream Flavours ----------------------------------------\n");
            Console.WriteLine("Regular Flavours:");
            Console.WriteLine("[1] Vanilla");
            Console.WriteLine("[2] Chocolate");
            Console.WriteLine("[3] Strawberry");
            Console.WriteLine("Premium Flavours:");
            Console.WriteLine("[4] Durian");
            Console.WriteLine("[5] Ube");
            Console.WriteLine("[6] Sea Salt");
            Console.WriteLine("\n----------------------------------------------------------------------------------------------------\n");
        }
        public static void DisplayOptions()
        {
            Console.WriteLine("\n--------------------------------------------- IceCream Options ---------------------------------------------\n");
            Console.WriteLine("[1] Cup");
            Console.WriteLine("[2] Cone");
            Console.WriteLine("[3] Waffle");
            Console.WriteLine("\n----------------------------------------------------------------------------------------------------\n");
        }

        public static void DisplayToppings()
        {
            Console.WriteLine("\n--------------------------------------------- Toppings ---------------------------------------------\n");
            Console.WriteLine("[1] Sprinkles");
            Console.WriteLine("[2] Mochi");
            Console.WriteLine("[3] Sago");
            Console.WriteLine("[4] Oreos");
            Console.WriteLine("\n----------------------------------------------------------------------------------------------------\n");
        }
        public static void DisplayWaffleFlavour()
        {
            Console.WriteLine("\n--------------------------------------- Choose Waffle Flavour --------------------------------------\n");
            Console.WriteLine("[1] Original");
            Console.WriteLine("[2] Red Velvet");
            Console.WriteLine("[3] Charcoal");
            Console.WriteLine("[4] Pandan");
            Console.WriteLine("\n----------------------------------------------------------------------------------------------------\n");
        }
        //method to read the orders.csv file
        public static Dictionary<int, List<Order>> ReadOrdersFile(List<int> orderIdList)
        {

            Dictionary<int, List<Order>> orders = new Dictionary<int, List<Order>>();
            using (StreamReader sr = new StreamReader("orders.csv"))
            {
                string line = sr.ReadLine();
                while ((line = sr.ReadLine()) != null)
                {
                    string[] data = line.Split(",");

                    // adding orderIds to list to be used later to generate orderId
                    int orderId = Convert.ToInt32(data[0]);
                    orderIdList.Add(orderId);

                    int memberId = Convert.ToInt32(data[1]);

                    List<Order> ordersList = new List<Order>();

                    //This code is to check if the order is already in the Dictionary and create order objects if it is not
                    if (!(orders.ContainsKey(memberId)))
                    {
                        //If the order is not in the Dictionary
                        Order createOrderObject = new Order(Convert.ToInt32(data[0]), DateTime.ParseExact(data[2], "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture));
                        ordersList.Add(createOrderObject);
                        orders.Add(memberId, ordersList);
                        if (data[3] != "")
                        {
                            orders[memberId][orders[memberId].Count - 1].TimeFulfilled = DateTime.ParseExact(data[3], "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                        }

                    }
                    else
                    {

                        //If the Member ID is in the dictionary
                        bool newOrder = true;
                        foreach (Order order in orders[memberId])
                        {

                            if (order.Id == Convert.ToInt32(data[0]))
                            {
                                newOrder = false;
                            }
                        }
                        if (newOrder)
                        {
                            ordersList = orders[memberId];
                            Order createOrderObject = new Order(Convert.ToInt32(data[0]), DateTime.ParseExact(data[2], "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture));
                            ordersList.Add(createOrderObject);
                            orders[memberId] = ordersList;
                            //orders.Add(memberId, ordersList);
                            if (data[3] != "")
                            {
                                orders[memberId][orders[memberId].Count - 1].TimeFulfilled = DateTime.ParseExact(data[3], "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                            }

                        }
                    }




                    //This is to create the flavour list
                    List<Flavour> flavours = new List<Flavour>();
                    for (int i = 8; i <= 10; i++)
                    {
                        if (data[i] != "")
                        {

                            bool prem = BasicReq6.CheckPremium(data[i]);
                            //loop and selection structure to see if the flavour is repeated
                            bool notRepeat = true;
                            foreach (Flavour flavour1 in flavours)
                            {
                                if (flavour1.Type == data[i])
                                {
                                    flavour1.Quantity++;
                                    notRepeat = false;
                                }
                            }
                            // loop to add the flavour if it is not repeated
                            while (notRepeat)
                            {
                                flavours.Add(new Flavour(data[i], prem, 1));
                                break;
                            }
                        }

                    }

                    //This is to create the toppings list
                    List<Topping> toppings = new List<Topping>();
                    for (int i = 11; i <= 14; i++)
                    {
                        if (data[i] != "")
                        {
                            toppings.Add(new Topping(data[i]));
                        }
                    }

                    //selection structure to create and determine if the ice cream is cup cone or waffle
                    IceCream iceCream = null;
                    if (data[4] == "Waffle")
                    {
                        iceCream = new Waffle(data[4], Convert.ToInt32(data[5]), flavours, toppings, data[7]);
                    }
                    else if (data[4] == "Cone")
                    {
                        iceCream = new Cone(data[4], Convert.ToInt32(data[5]), flavours, toppings, Convert.ToBoolean(data[6]));
                    }
                    else
                    {
                        iceCream = new Cup(data[4], Convert.ToInt32(data[5]), flavours, toppings);
                    }
                    //This code is to add ice cream object that has been created to the order
                    orders[memberId][orders[memberId].Count - 1].AddIceCream(iceCream);


                }
                return orders;
            }
        }

        public static void RetrieveOrders(List<Order> orderObjs, Queue<Order> goldQueue, Queue<Order> regQueue, Dictionary<int, Customer> customerDict)
        {
            foreach (Order order in goldQueue)
            {
                orderObjs.Add(order);
            }

            foreach (Order order1 in regQueue)
            {
                orderObjs.Add(order1);
            }

            foreach (Customer customer in customerDict.Values)
            {
                foreach (Order order in customer.OrderHistory)
                {
                    orderObjs.Add(order);
                }
            }

        }

        public static void AppendOrders(List<Order> orderObjs, Dictionary<int, Customer> customerDict)
        {
            string flavourOne = "", flavourTwo = "", flavourThree = "", toppingOne = "", toppingTwo = "", toppingThree = "", toppingFour = "", option = "", scoops = "", dipped = "", waffleFlavour = "";

            List<Order> sortedOrderObjs = orderObjs.OrderBy(order => order.Id).ToList();

            using (StreamWriter sw = new StreamWriter("orders.csv", false))
            {
                sw.WriteLine("Id,MemberId,TimeReceived,TimeFulfilled,Option,Scoops,Dipped,WaffleFlavour,Flavour1,Flavour2,Flavour3,Topping1,Topping2,Topping3,Topping4");

                foreach (Order order in sortedOrderObjs)
                {
                    string orderId = order.Id.ToString();
                    Customer customer = AdvancedPartA.RetrieveCustomer(order, customerDict);
                    int memberid = customer.Memberid;
                    string dateTimeReceived = order.TimeReceived.ToString();
                    string dateTimeFulfilled = order.TimeFulfilled.ToString() ?? "";

                    foreach (IceCream iceCream in order.IceCreamList)
                    {
                        option = iceCream.Option;
                        scoops = iceCream.Scoops.ToString(); // get scoops
                        if (iceCream is Waffle)
                        {
                            Waffle waffle = (Waffle)iceCream;
                            waffleFlavour = waffle.WaffleFlavour;
                            dipped = null;
                        }
                        else if (iceCream is Cone)
                        {
                            Cone cone = (Cone)iceCream;
                            dipped = cone.Dipped.ToString();
                            waffleFlavour = null;
                        }
                        else
                        {
                            waffleFlavour = null;
                            dipped = null;
                        }

                        if (iceCream.Scoops == 1)
                        {
                            flavourOne = iceCream.Flavours[0].Type;
                            flavourTwo = null;
                            flavourThree = null;
                        }
                        if (iceCream.Scoops == 2)
                        {
                            if (iceCream.Flavours.Count == 1)
                            {
                                flavourOne = iceCream.Flavours[0].Type;
                                flavourTwo = iceCream.Flavours[0].Type;
                                flavourThree = null;
                            }
                            else
                            {
                                flavourOne = iceCream.Flavours[0].Type;
                                flavourTwo = iceCream.Flavours[1].Type;
                                flavourThree = null;
                            }
                        }
                        if (iceCream.Scoops == 3)
                        {

                            if (iceCream.Flavours.Count == 1)
                            {
                                flavourOne = iceCream.Flavours[0].Type;
                                flavourTwo = iceCream.Flavours[0].Type;
                                flavourThree = iceCream.Flavours[0].Type;
                            }
                            else if (iceCream.Flavours.Count == 2)
                            {
                                if (iceCream.Flavours[0].Quantity == 2)
                                {
                                    flavourOne = iceCream.Flavours[0].Type;
                                    flavourTwo = iceCream.Flavours[0].Type;
                                    flavourThree = iceCream.Flavours[1].Type;
                                }
                                else
                                {
                                    flavourOne = iceCream.Flavours[0].Type;
                                    flavourTwo = iceCream.Flavours[1].Type;
                                    flavourThree = iceCream.Flavours[1].Type;
                                }
                            }
                            else
                            {
                                flavourOne = iceCream.Flavours[0].Type;
                                flavourTwo = iceCream.Flavours[1].Type;
                                flavourThree = iceCream.Flavours[2].Type;
                            }
                        }
                        if (iceCream.Toppings.Count == 0)
                        {
                            toppingOne = null;
                            toppingTwo = null;
                            toppingThree = null;
                            toppingFour = null;
                        }
                        if (iceCream.Toppings.Count >= 1)
                        {
                            toppingOne = iceCream.Toppings[0].Type;
                            toppingTwo = null;
                            toppingThree = null;
                            toppingFour = null;
                        }
                        if (iceCream.Toppings.Count == 2)
                        {
                            toppingTwo = iceCream.Toppings[1].Type;
                        }
                        if (iceCream.Toppings.Count == 3)
                        {
                            toppingThree = iceCream.Toppings[2].Type;
                        }
                        if (iceCream.Toppings.Count == 4)
                        {
                            toppingFour = iceCream.Toppings[3].Type;
                        }

                        string orderDetails = $"{order.Id},{memberid},{dateTimeReceived},{dateTimeFulfilled},{option},{scoops},{dipped},{waffleFlavour},{flavourOne},{flavourTwo},{flavourThree},{toppingOne},{toppingTwo},{toppingThree},{toppingFour}";
                        sw.WriteLine(orderDetails);
                    }
                }
            }
        }


        public static void UpdateQueues(Queue<Order> goldQueue, Queue<Order> regQueue, Dictionary<int, Customer> customersDict)
        {
            List<Order> goldQueueSort = new List<Order>();
            List<Order> regQueueSort = new List<Order>();
            foreach (KeyValuePair<int, Customer> kvp in customersDict)
            {
                //check if customer has an order
                if (kvp.Value.CurrentOrder != null)
                {
                    //check customer status
                    if (kvp.Value.Rewards.Tier == "Gold")
                    {
                        goldQueueSort.Add(kvp.Value.CurrentOrder);
                    }
                    else
                    {
                        regQueueSort.Add(kvp.Value.CurrentOrder);
                    }
                }
            }
            //sort the lists
            goldQueueSort.OrderBy(order => order.TimeReceived);
            regQueueSort.OrderBy(order => order.TimeReceived);
            //enqueue the lists
            foreach (Order order in goldQueueSort)
            {
                goldQueue.Enqueue(order);
            }
            foreach (Order order in regQueueSort)
            {
                regQueue.Enqueue(order);
            }
        }

       



        public static string GetICFlavour(int choice)
        {
            if (choice == 1)
            {
                return "Vanilla";
            }
            else if (choice == 2)
            {
                return "Chocolate";
            }
            else if (choice == 3)
            {
                return "Strawberry";
            }
            else if (choice == 4)
            {
                return "Durian";
            }
            else if (choice == 5)
            {
                return "Ube";
            }
            else
            {
                return "Sea Salt";
            }
        }

        public static string GetOption(int choice)
        {
            if (choice == 1)
            {
                return "Cup";
            }
            else if (choice == 2)
            {
                return "Cone";
            }
            else
            {
                return "Waffle";
            }
        }
        public static string GetWaffleFlavour(int choice)
        {
            if (choice == 1)
            {
                return "Original";
            }
            else if (choice == 2)
            {
                return "Red Velvet";
            }
            else if (choice == 3)
            {
                return "Charcoal";
            }
            else
            {
                return "Pandan";
            }

        }

        public static string GetTopping(int choice)
        {
            if (choice == 1)
            {
                return "Sprinkles";
            }
            else if (choice == 2)
            {
                return "Mochi";
            }
            else if (choice == 3)
            {
                return "Sago";
            }
            else
            {
                return "Oreos";
            }
        }
        public static void OverwriteCustomerFile(Dictionary<int, Customer> customerDict)
        {
            using (StreamWriter sw = new StreamWriter("customers.csv", false))
            {
                sw.WriteLine("Name,MemberId,DOB,MembershipStatus,MembershipPoints,PunchCard");

                foreach (KeyValuePair<int, Customer> kvp in customerDict)
                {
                    string name = kvp.Value.Name;
                    string memberId = kvp.Value.Memberid.ToString();
                    string dob = kvp.Value.Dob.ToString();
                    string status = kvp.Value.Rewards.Tier.ToString();
                    string points = kvp.Value.Rewards.Points.ToString();
                    string punchCard = kvp.Value.Rewards.PunchCard.ToString();

                    string updatedDetails = $"{name},{memberId},{dob},{status},{points},{punchCard}";
                    sw.WriteLine(updatedDetails);
                }
            }
        }
    }
}

