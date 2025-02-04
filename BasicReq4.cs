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
    public static class BasicReq4
    {
        public static void CreateOrder(Dictionary<int, Customer> customerDict, List<int> orderIdList, Queue<Order> goldQueue, Queue<Order> regQueue)
        {
            // prompting user for memberId to place order accordingly
            // VALIDATE IF ID NOT FOUND > NEW CUSTOMER? > ASK FIRST OR ?
            int memberId;
            while (true)
            {
                try
                {
                    Console.Write("Enter your id number: ");
                    if (int.TryParse(Console.ReadLine(), out memberId))
                    {
                        string stringMemberId = memberId.ToString();
                        //ensuring id isn't negative, its a 6digit number & it alr exists
                        if (stringMemberId.Length != 6 || memberId < 0)
                        {
                            throw new ArgumentException("MemberId should be a 6-digit positive integer only. Please try again!");
                        }
                        else if (!customerDict.ContainsKey(memberId))
                        {
                            throw new KeyNotFoundException("Invalid memberId entered. MemberId doesn't exist. Please try again.");
                        }
                        break; // exiting loop if valid memberId is entered
                    }
                    else
                    {
                        //handling invalid data
                        throw new FormatException("MemberId should be an integer only. Please try again!");
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (KeyNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Customer customerRetrieved = customerDict[memberId];

            if (customerRetrieved.CurrentOrder == null) //ensuring 2 orders isnt placed at once when, currentorder isnt fulfilled yet
            {
                // create order obj 
                string timeRetrieved = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                Order order = customerRetrieved.MakeOrder(orderIdList, DateTime.ParseExact(timeRetrieved, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture));
                orderIdList.Add(order.Id); // updating the list of ids everytime an order has been made

                // making icecream order
                OrderDetails(order);
                while (true)
                {
                    try
                    {
                        // checking if more icecreams are to be added 
                        Console.Write("Would you like to add another ice cream to your order? [Y/N]: ");
                        string addReply = (Console.ReadLine()).ToUpper();
                        if (addReply == "Y")
                        {
                            OrderDetails(order);
                        }
                        else if (addReply == "N")
                        {
                            customerRetrieved.CurrentOrder = order; // linking new order to currentOrder
                            if (customerRetrieved.Rewards.Tier == "Gold")
                            {
                                goldQueue.Enqueue(customerRetrieved.CurrentOrder);
                            }
                            else
                            {
                                regQueue.Enqueue(customerRetrieved.CurrentOrder);
                            }
                            Console.WriteLine("Order had been made successfully!");
                            break;
                        }
                        else
                        {
                            throw new ArgumentException("Invalid option entered. Please enter either Y or N only!");
                        }
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            else
            {
                Console.WriteLine("Any modifications (add, modify, delete icecream) can be done in Option 6. Choose Option 6 instead!"); // what exception??
            }
        }

        public static void OrderDetails(Order order)
        {
            // prompts for making an ice cream order
            string option;
            int icecreamOpt;

            DisplayAndRead.DisplayOptions();
            while (true)
            {
                try
                {
                    Console.Write("Enter icecream option: ");
                    if (int.TryParse(Console.ReadLine(), out icecreamOpt))
                    {
                        // ensuring user enters existing options only
                        if (icecreamOpt < 1 || icecreamOpt > 3)
                        {
                            throw new ArgumentException("Invalid option entered. Please enter either 1,2 or 3 only!");
                        }
                        else
                        {
                            option = DisplayAndRead.GetOption(icecreamOpt);
                        }
                        break; // exiting loop if valid option is entered
                    }
                    else
                    {
                        //handling invalid data
                        throw new FormatException("Option should be an integer only. Please try again!");
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            // checking for cone or waffle addOns
            bool dipped = false;
            string waffleFlavour = "";
            int flavOpt;

            while (true)
            {
                try
                {
                    if (icecreamOpt == 2)
                    {
                        Console.Write("Do you want the cone to be dipped? [Y/N]: ");
                        string dippedAns = (Console.ReadLine()).ToUpper();
                        if (dippedAns == "Y")
                        {
                            dipped = true;
                        }
                        else if (dippedAns == "N")
                        {
                            dipped = false;
                        }
                        else
                        {
                            throw new ArgumentException("Invalid option chosen. Please enter either Y or N only!");
                        }
                    }
                    else if (icecreamOpt == 3)
                    {
                        DisplayAndRead.DisplayWaffleFlavour();
                        Console.Write("What waffle flavour would you like?: ");
                        if (int.TryParse(Console.ReadLine(), out flavOpt))
                        {
                            if (flavOpt != 1 && flavOpt != 2 && flavOpt != 3 && flavOpt != 4)
                            {
                                throw new ArgumentException("Invalid flavour. Please enter either 1,2,3 or 4 only!");
                            }
                            else
                            {
                                waffleFlavour = DisplayAndRead.GetWaffleFlavour(flavOpt);
                            }
                        }
                        else
                        {
                            //handling invalid data
                            throw new FormatException("Waffle flavour option should be an integer only. Please try again!");
                        }
                    }
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            // checking for num of scoops
            int scoops;
            while (true)
            {
                try
                {
                    Console.Write("Enter number of scoops: ");
                    if (int.TryParse(Console.ReadLine(), out scoops))
                    {
                        //ensuring scoops isn't negative & more than 3
                        if (scoops <= 0 || scoops > 3)
                        {
                            throw new ArgumentException("Invalid number of scoops. Mininum & maximum number of scoops is 1 and 3 respectively. Please try again!");
                        }
                        break; // exiting loop if valid num of scoops is entered
                    }
                    else
                    {
                        //handling invalid data
                        throw new FormatException("Invalid number of scoops. Mininum & maximum number of scoops is 1 and 3 respectively. Please try again!");
                    }
                    break; //????????????
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            // making flavour list to store customer's desired flavours
            // validate properly. incrct flav > currently repormpts from first flavour!!!
            List<Flavour> Flavours = new List<Flavour>();
            int type;
            bool premium;

            DisplayAndRead.ICFlavoursDisplay();
            while (true)
            {
                try
                {
                    // to store num of each flavour user wants
                    Dictionary<int, int> flavCount = new Dictionary<int, int>();

                    for (int num = 0; num < scoops; num++)
                    {
                        Console.Write($"Enter your desired flavour {num + 1}: ");
                        if (int.TryParse(Console.ReadLine(), out type))
                        {
                            if (type == 1 || type == 2 || type == 3 || type == 4 || type == 5 || type == 6)
                            {
                                if (flavCount.ContainsKey(type)) // if flavour alr exists, add on quantity
                                {
                                    flavCount[type] += 1;
                                }
                                else
                                {
                                    flavCount[type] = 1; // if flavour doesnt exist, create it & add quantity as one
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid option entered. Please enter either option 1,2,3,4,5 or 6 only!");
                                num--;
                                continue;
                                //throw new ArgumentException("Invalid flavour entered. Please enter either vanilla, chocolate, strawberry, durain, ube or sea salt flavour only!");
                            }
                        }
                        else
                        {
                            //handling invalid data
                            throw new FormatException("Flavour option should be integer only. Please try again!");
                        }

                    }
                    // iterating through flavCount dict to create flavour objects 
                    foreach (int num in flavCount.Keys)
                    {
                        if (num == 1 || num == 2 || num == 3)
                        {
                            premium = false;
                        }
                        else
                        {
                            premium = true;
                        }
                        string flav = DisplayAndRead.GetICFlavour(num);
                        Flavour flavour = new Flavour(flav, premium, flavCount[num]);
                        Flavours.Add(flavour); // adding flavour to FlavoursDict
                    }
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            // making toppings list to store customer's desired toppings
            List<Topping> Toppings = new List<Topping>();
            int toppingOpt;
            string topping;

            DisplayAndRead.DisplayToppings();
            while (true)
            {
                try
                {
                    for (int i = 1; i <= 4; i++)
                    {
                        Console.Write($"Enter your desired topping {i} (enter 0, if no toppings): ");
                        if (int.TryParse(Console.ReadLine(), out toppingOpt))
                        {
                            if (toppingOpt == 1 || toppingOpt == 2 || toppingOpt == 3 || toppingOpt == 4)
                            {
                                topping = DisplayAndRead.GetTopping(toppingOpt);
                                Topping addTopping = new Topping(topping);
                                Toppings.Add(addTopping);
                            }
                            else if (toppingOpt == 0)
                            {
                                break; // exiting loop if no topping wanted
                            }
                            else
                            {

                                Console.WriteLine("Invalid topping entered. Please enter either sprinkles, mochi, sago or oreos topping only!");
                                i--;
                                continue;
                            }
                        }
                        else
                        {
                            //handling invalid data
                            throw new FormatException("Topping option should be an integer only. Please try again!");
                        }
                    }
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            // make icecream obj
            IceCream iceCream;
            if (option == "Cup")
            {
                iceCream = new Cup(option, scoops, Flavours, Toppings);
            }
            else if (option == "Cone")
            {
                iceCream = new Cone(option, scoops, Flavours, Toppings, dipped);
            }
            else
            {
                iceCream = new Waffle(option, scoops, Flavours, Toppings, waffleFlavour);
            }

            // add iceCream obj to order
            order.AddIceCream(iceCream);
        }
    }
}

