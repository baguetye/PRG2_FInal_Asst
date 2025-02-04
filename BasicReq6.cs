using S10258609_PRG2Assignment;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

//==========================================================
// Student Number : S10257201
// Student Name : Balakrishnan Rubanaasri
// Partner Name : Bryan Lim Aik Sian
//==========================================================

namespace S10257201_PRG2Assignment
{
    public static class BasicReq6
    {
        private static Cup CreateCup(IceCream iceCream)
        {
            string oldOption = iceCream.Option;
            Cup newOption = new Cup("Cup", iceCream.Scoops, iceCream.Flavours, iceCream.Toppings);
            Console.WriteLine($"Ice Cream option modified from {oldOption} to Cup.");
            return newOption;
        }
        private static Waffle CreateWaffle(IceCream iceCream)
        {
            string oldOption = iceCream.Option;
            while (true)
            {
                DisplayAndRead.DisplayWaffleFlavour();
                Console.Write("Please enter an option number: ");
                Waffle newWaffle = new Waffle();
                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());
                    if (choice == 1)
                    {
                        newWaffle = new Waffle("Waffle", iceCream.Scoops, iceCream.Flavours, iceCream.Toppings, "Original");
                    }
                    else if (choice == 2)
                    {
                        newWaffle = new Waffle("Waffle", iceCream.Scoops, iceCream.Flavours, iceCream.Toppings, "Red Velvet");
                    }
                    else if (choice == 3)
                    {
                        newWaffle = new Waffle("Waffle", iceCream.Scoops, iceCream.Flavours, iceCream.Toppings, "Charcoal");
                    }
                    else if (choice == 4)
                    {
                        newWaffle = new Waffle("Waffle", iceCream.Scoops, iceCream.Flavours, iceCream.Toppings, "Pandan");
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid option.");
                        continue;
                    }

                    Console.WriteLine($"Ice Cream option modified from {oldOption} to Waffle.");
                    return newWaffle;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter an integer.");
                    continue;
                }
                catch (Exception)
                {
                    Console.WriteLine("Please try again.");
                }
            }
        }
        private static Cone CreateCone(IceCream iceCream)
        {
            string oldOption = iceCream.Option;
            Cone newCone = new Cone();
            while (true)
            {
                try
                {
                    Console.Write("Would you like your cone to be dipped? [y/n]: ");
                    string choice = Console.ReadLine();
                    if (choice.ToLower() == "y")
                    {
                        newCone = new Cone("Cone", iceCream.Scoops, iceCream.Flavours, iceCream.Toppings, true);
                    }
                    else if (choice.ToLower() == "n")
                    {
                        newCone = new Cone("Cone", iceCream.Scoops, iceCream.Flavours, iceCream.Toppings, false);
                    }
                    else
                    {
                        Console.WriteLine("Please enter either \"y\" or \"n\". ");
                        continue;
                    }
                    Console.WriteLine($"Ice Cream option modified from {oldOption} to Cone.");
                    return newCone;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter either \"y\" or \"n\". ");
                }
                catch (Exception)
                {
                    Console.WriteLine("Please try again.");
                }

            }
        }
        public static IceCream ModifyICOption(IceCream iceCream)
        {
            Console.WriteLine("\n--------------------------------------Modify Ice Cream Option-------------------------------------\n");
            Console.WriteLine($"Current Option: {iceCream.Option}");
            if (iceCream.Option == "Cone")
            {
                Console.WriteLine("[1] Change to Cup");
                Console.WriteLine("[2] Change to Waffle");
                Console.WriteLine("[0] Exit");
                Console.WriteLine("\n----------------------------------------------------------------------------------------------------\n");
                while (true)
                {
                    try
                    {
                        Console.Write("\nPlease enter an option number: ");
                        int choice = Convert.ToInt32(Console.ReadLine());
                        if (choice == 1)
                        {
                            iceCream = CreateCup(iceCream);
                        }
                        else if (choice == 2)
                        {
                            iceCream = CreateWaffle(iceCream);
                        }
                        else if (choice == 0)
                        {
                            return iceCream;
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid option.");
                            continue;
                        }
                        return iceCream;
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
            else if (iceCream.Option == "Waffle")
            {
                Console.WriteLine("[1] Change to Cup");
                Console.WriteLine("[2] Change to Cone");
                Console.WriteLine("[0] Exit");
                Console.WriteLine("\n----------------------------------------------------------------------------------------------------\n");
                while (true)
                {
                    try
                    {
                        Console.Write("\nPlease enter an option number: ");
                        int choice = Convert.ToInt32(Console.ReadLine());
                        if (choice == 1)
                        {
                            iceCream = CreateCup(iceCream);
                        }
                        else if (choice == 2)
                        {
                            iceCream = CreateCone(iceCream);
                        }
                        else if (choice == 0)
                        {
                            return iceCream;
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid option.");
                            continue;
                        }
                        return iceCream;
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
                Console.WriteLine("[1] Change to Waffle");
                Console.WriteLine("[2] Change to Cone");
                Console.WriteLine("[0] Exit");
                Console.WriteLine("\n----------------------------------------------------------------------------------------------------\n");
                while (true)
                {
                    try
                    {
                        Console.Write("\nPlease enter an option number: ");
                        int choice = Convert.ToInt32(Console.ReadLine());
                        if (choice == 1)
                        {
                            iceCream = CreateWaffle(iceCream);
                        }
                        else if (choice == 2)
                        {
                            iceCream = CreateCone(iceCream);
                        }
                        else if (choice == 0)
                        {
                            return iceCream;
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid option.");
                            continue;
                        }
                        return iceCream;
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
        }
        public static IceCream ModifyICScoops(IceCream iceCream)
        {
            int oldScoops = Convert.ToInt32(iceCream.Scoops);
            Console.WriteLine("-------------------------------------- Modify Ice Cream Scoops -------------------------------------");
            while (true)
            {
                try
                {
                    //get new number of scoops
                    Console.WriteLine($"Current Number of Scoops: {iceCream.Scoops}");
                    Console.Write("Please enter the number of scoops you would like from 1 to 3: ");
                    int newScoops = Convert.ToInt32(Console.ReadLine());
                    if (newScoops < 1 || newScoops > 3) //check if number of scoops is within acceptable range
                    {
                        Console.WriteLine("Please enter an integer from 1 to 3");
                        continue;
                    }
                    else if (newScoops < iceCream.Scoops) //if newScoops is less than the original, user will choose which flavour to delete
                    {
                        // iceCream.Scoops = newScoops;
                        Console.WriteLine("\n---------------------------------- Select Which Flavour to Delete ----------------------------------\n");
                        for (int times = iceCream.Scoops; times > newScoops; times--)
                        {
                            for (int i = 0; i < iceCream.Flavours.Count; i++)
                            {
                                if (iceCream.Flavours[i].Quantity > 1)
                                {
                                    Console.WriteLine($"[{i + 1}] {iceCream.Flavours[i].Type} ({iceCream.Flavours[i].Quantity} Scoops)");
                                }
                                else
                                {
                                    Console.WriteLine($"[{i + 1}] {iceCream.Flavours[i].Type} ({iceCream.Flavours[i].Quantity} Scoop)");
                                }
                            }
                            while (true)
                            {
                                try
                                {
                                    if (iceCream.Flavours.Count == 1)
                                    {
                                        iceCream.Flavours[0].Quantity = newScoops;
                                        Console.WriteLine($"The number of scoops have been decreased to {iceCream.Flavours[0].Quantity} for {iceCream.Flavours[0].Type}");
                                        break;
                                    }
                                    Console.Write("Enter option to reduce the number by 1: ");
                                    int choice = Convert.ToInt32(Console.ReadLine()) - 1;
                                    if (choice < 0 || choice >= iceCream.Flavours.Count)
                                    {
                                        Console.WriteLine("Please enter a valid option. ");
                                        continue;
                                    }
                                    else if (iceCream.Flavours[choice].Quantity > 1) //if there is more than one scoop for the same flavour
                                    {
                                        iceCream.Flavours[choice].Quantity -= 1;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"The number of scoops have been decreased to 0 for {iceCream.Flavours[choice].Type}");
                                        iceCream.Flavours.Remove(iceCream.Flavours[choice]);
                                    }
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
                                break;
                            }
                        }

                    }
                    else if (newScoops > iceCream.Scoops)// if there are more scoops the user will choose options to select the new flavour
                    {
                        while (true)
                        {
                            try
                            {
                                Console.WriteLine("Would you like to select flavours:");
                                Console.WriteLine("[1] for the new scoops only");
                                Console.WriteLine("[2] For every scoop (Reselect everything)");
                                Console.Write("Please select an option: ");
                                int choice = Convert.ToInt32(Console.ReadLine());
                                DisplayAndRead.ICFlavoursDisplay();
                                //this code is to add the scoops to the iceCream variable
                                iceCream.Scoops = newScoops;
                                if (choice == 1)
                                {

                                    for (int i = oldScoops; i < iceCream.Scoops; i++)
                                    {
                                        int flavNum = iceCream.Scoops;
                                        while (true)
                                        {
                                            try
                                            {

                                                Console.Write($"Select Flavour {flavNum}: ");
                                                int choiceFlav = Convert.ToInt32(Console.ReadLine());
                                                if (choiceFlav > 6 || choiceFlav < 1)
                                                {
                                                    Console.WriteLine("PLease enter a valid option number");
                                                    continue;
                                                }
                                                string flavChoice = DisplayAndRead.GetICFlavour(choiceFlav);
                                                //code to add the flavour
                                                bool newFlav = NewFlavour(iceCream.Flavours, flavChoice);
                                                if (newFlav)
                                                {
                                                    //check if flavour is premium and add it into the list
                                                    bool premium = CheckPremium(flavChoice);
                                                    iceCream.Flavours.Add(new Flavour(flavChoice, premium, 1));
                                                };
                                                break;
                                            }
                                            catch (FormatException)
                                            {
                                                Console.WriteLine("Please enter an integer");
                                                continue;
                                            }
                                            catch (Exception)
                                            {
                                                Console.WriteLine("Please try again");
                                                continue;
                                            }
                                        }
                                    }
                                }
                                else if (choice == 2)
                                {
                                    iceCream.Flavours.Clear();
                                    for (int i = 1; i <= iceCream.Scoops; i++)
                                    {
                                        while (true)
                                        {
                                            try
                                            {
                                                //add try catch
                                                Console.Write($"Select Flavour {i}: ");
                                                int choiceFlav = Convert.ToInt32(Console.ReadLine());
                                                if (choiceFlav > 6 || choiceFlav < 1)
                                                {
                                                    Console.WriteLine("PLease enter a valid option number");
                                                    continue;
                                                }
                                                string flavChoice = DisplayAndRead.GetICFlavour(choiceFlav);
                                                //code to add the flavour
                                                bool newFlav = NewFlavour(iceCream.Flavours, flavChoice);
                                                if (newFlav)
                                                {
                                                    //check if flavour is premium and add it into the list
                                                    bool premium = CheckPremium(flavChoice);
                                                    iceCream.Flavours.Add(new Flavour(flavChoice, premium, 1));
                                                };
                                                break;
                                            }
                                            catch (FormatException)
                                            {
                                                Console.WriteLine("Please enter an integer");
                                                continue;
                                            }
                                            catch (Exception)
                                            {
                                                Console.WriteLine("Please try again");
                                                continue;
                                            }
                                        }
                                    }
                                }
                                break;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Please enter 1 or 2");
                                continue;
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Please try again");
                                continue;
                            }

                        }
                        Console.WriteLine($"Scoops have been increased from {oldScoops} to {newScoops}");
                    }
                    else
                    {
                        Console.WriteLine("The number of scoops you have chosen is the same as the previous number of scoops. ");
                        while (true)
                        {
                            try
                            {
                                Console.Write("Would you like to select another number [y/n]? ");
                                string choice = Console.ReadLine();
                                if (choice.ToLower() == "y")
                                {
                                    break;
                                }
                                else if (choice.ToLower() == "n")
                                {
                                    return iceCream;
                                }
                                else
                                {
                                    Console.WriteLine("Please enter either \"y\" or \"n\". ");
                                    continue;
                                }
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Please enter either \"y\" or \"n\". ");
                                continue;
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Please try again.");
                            }
                        }
                        continue;
                    }
                    return iceCream;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter an integer");
                    continue;
                }
                catch (Exception)
                {
                    Console.WriteLine("Please try again");
                }
            }
        }
        //this method is to check if the ice cream flavour is premium
        public static bool CheckPremium(string flavChoice)
        {
            bool premium = false;
            if (flavChoice == "Durian" || flavChoice == "Ube" || flavChoice == "Sea Salt")
            {
                premium = true;
            }
            return premium;
        }
        //This method is to check if the flavour is repeated and return a boolean value as well as to increase the quantity if the flavour is repeated
        public static bool NewFlavour(List<Flavour> flavours, string flavChoice)
        {
            foreach (Flavour flavour in flavours)
            {
                if (flavour.Type == flavChoice)
                {
                    flavour.Quantity++;
                    return false;
                }

            }
            return true;
        }

        //this method is to modify the Ice Cream Flavour
        public static IceCream SelectICFlav(IceCream iceCream, int change, bool changeAllToSame)
        {
            //validation to check if there are multiple scoops
            if (iceCream.Flavours[change].Quantity > 1 && !changeAllToSame) // if the user wants to have different flavours for each scoop
            {
                int times = iceCream.Flavours[change].Quantity;
                string oldFlav = iceCream.Flavours[change].Type;
                iceCream.Flavours.Remove(iceCream.Flavours[change]);
                for (int i = 1; i <= times; i++)
                {
                    while (true) //validate number for chosen flavour
                    {
                        try
                        {
                            Console.Write($"Please Choose a Flavour for scoop {i}: ");
                            int option = Convert.ToInt32(Console.ReadLine());
                            if (option > 6 || option < 1)
                            {
                                Console.WriteLine("Please enter a valid option.");
                                continue;
                            }
                            string flavour = DisplayAndRead.GetICFlavour(option);
                            if (oldFlav != flavour) //if the new flavour is different from the old flavour
                            {

                                bool newFlav = NewFlavour(iceCream.Flavours, flavour);
                                if (newFlav) // the flavour is new
                                {
                                    bool premium = CheckPremium(flavour);
                                    Console.WriteLine($"Flavour has been changed from {oldFlav} to {flavour} for scoop {i}");
                                    iceCream.Flavours.Add(new Flavour(flavour, premium, 1));
                                }
                                else
                                {
                                    Console.WriteLine($"Flavour chosen was the same and has been added for scoop {i}. ");
                                }
                            }
                            else
                            {
                                if (i == 1)
                                {
                                    bool premium = CheckPremium(flavour);
                                    iceCream.Flavours.Add(new Flavour(flavour, premium, 1));
                                }
                                else
                                {
                                    NewFlavour(iceCream.Flavours, flavour);
                                }
                                Console.WriteLine($"Flavour chosen was the same and has been added for scoop {i}. ");
                            }
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
                        break;
                    }
                }


            }
            else
            {
                while (true) //validate number for chosen flavour
                {
                    try
                    {
                        Console.Write("Please Choose a Flavour you would like to change to: ");
                        int option = Convert.ToInt32(Console.ReadLine());
                        if (option > 6 || option < 1)
                        {
                            Console.WriteLine("Please enter a valid option.");
                            continue;
                        }
                        string flavour = DisplayAndRead.GetICFlavour(option);
                        if (iceCream.Flavours[change].Type != flavour)
                        {
                            bool premium = CheckPremium(flavour);
                            Console.WriteLine($"Flavour has been changed from {iceCream.Flavours[change].Type} to {flavour}");
                            iceCream.Flavours[change] = (new Flavour(flavour, premium, iceCream.Flavours[change].Quantity));
                        }
                        else
                        {
                            Console.WriteLine("Flavour chosen is the same as the Old Flavour. Please select again. ");
                            continue;
                        }
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
                    break;
                }
            }
            return iceCream;
        }

        public static void ModifyICFlav(IceCream iceCream)
        {
            Console.WriteLine("------------------------------------- Modify Ice Cream Flavour -------------------------------------\n");
            bool changeAllToSame = true;
            if (iceCream.Flavours.Count > 1)// if there are more than one flavours
            {
                Console.WriteLine("Current Chosen Flavours:");
                int count = 1; // count to display the number of flavours
                foreach (Flavour flav in iceCream.Flavours)
                {
                    if (flav.Quantity > 1)
                    {
                        Console.WriteLine($"[{count}] {flav.Type}: {flav.Quantity} Scoops");
                    }
                    else
                    {
                        Console.WriteLine($"[{count}] {flav.Type}: {flav.Quantity} Scoop");
                    }
                    count++;
                }
                while (true)
                {
                    try
                    {
                        Console.Write("Select Which Flavour you would like to change: ");
                        int choice = Convert.ToInt32(Console.ReadLine());
                        if (iceCream.Flavours[choice - 1].Quantity > 1) // if chosen flavour has more than 1 scoop
                        {
                            while (true)
                            {
                                try
                                {
                                    Console.WriteLine("The flavour chosen has more than 1 scoop. Would you like the flavours to be:");
                                    Console.WriteLine("[1] the same for every scoop");
                                    Console.WriteLine("[2] different For every scoop (Reselect everything)");
                                    Console.Write("Please select an option: ");
                                    int choice1 = Convert.ToInt32(Console.ReadLine());
                                    if (choice1 == 2) // if user wants to change everything
                                    {
                                        changeAllToSame = false;
                                    }
                                    break;

                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Please enter 1 or 2");
                                    continue;
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("Please try again");
                                    continue;
                                }


                            }
                        }
                        //iceCream.Flavours.Remove(changeFlav);
                        DisplayAndRead.ICFlavoursDisplay();
                        SelectICFlav(iceCream, choice - 1, changeAllToSame);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("PLease enter an integer. ");
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
            else
            {

                if (iceCream.Flavours[0].Quantity > 1)
                {
                    Console.WriteLine($"Current Chosen Flavour: {iceCream.Flavours[0].Type} {iceCream.Flavours[0].Quantity} Scoops");
                    while (true)
                    {
                        try
                        {
                            Console.WriteLine("The flavour chosen has more than 1 scoop. Would you like the flavours to be:");
                            Console.WriteLine("[1] the same for every scoop");
                            Console.WriteLine("[2] different For every scoop (Reselect everything)");
                            Console.Write("Please select an option: ");
                            int choice1 = Convert.ToInt32(Console.ReadLine());
                            if (choice1 == 2) // if user wants to change everything
                            {
                                Console.WriteLine("test");
                                changeAllToSame = false;
                            }

                            break;

                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Please enter 1 or 2");
                            continue;
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Please try again");
                            continue;
                        }


                    }
                    DisplayAndRead.ICFlavoursDisplay();
                    SelectICFlav(iceCream, 0, changeAllToSame);


                }
                else
                {
                    Console.WriteLine($"Current Chosen Flavour: {iceCream.Flavours[0].Type} {iceCream.Flavours[0].Quantity} Scoop");
                    DisplayAndRead.ICFlavoursDisplay();
                    SelectICFlav(iceCream, 0, changeAllToSame);
                }
            }

        }
        public static void DisplayCurrentTopping(List<Topping> toppings)
        {
            Console.WriteLine("\n----------------------------------------- Current Toppings -----------------------------------------\n");
            if (toppings.Count > 0)
            {
                int count = 1;
                foreach (Topping topping in toppings)
                {
                    Console.WriteLine($"[{count}] {topping.Type}");
                    count++;
                }
            }
            else
            {
                Console.WriteLine("There are currently no toppings");
            }
            Console.WriteLine("\n----------------------------------------------------------------------------------------------------\n");
        }
        public static void CreateToppings(IceCream iceCream)
        {
            //add try catch here
            while (true)
            {
                try
                {
                    Console.Write("Please enter the number of toppings you would like [0 to 4]: ");
                    int toppingCount = Convert.ToInt32(Console.ReadLine());
                    if (toppingCount > 4 || toppingCount < 0)
                    {
                        Console.WriteLine("Please enter a valid number of toppings. ");
                        continue;
                    }
                    else if (toppingCount > 0)
                    {
                        List<Topping> toppingAdd = new List<Topping>();
                        DisplayAndRead.DisplayToppings();
                        for (int i = 0; i < toppingCount; i++)
                        {
                            while (true)
                            {
                                try
                                {
                                    Console.Write($"Please select Topping {i + 1}: ");
                                    int choice = Convert.ToInt32(Console.ReadLine());
                                    if (toppingCount > 4 || toppingCount < 1)
                                    {
                                        Console.WriteLine("Please enter a valid option. ");
                                        continue;
                                    }
                                    else
                                    {
                                        string selectedTopping = DisplayAndRead.GetTopping(choice);
                                        toppingAdd.Add(new Topping(selectedTopping));
                                    }

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
                        iceCream.Toppings = toppingAdd;
                        Console.WriteLine($"{iceCream.Toppings.Count} Toppings have been added.");
                        DisplayCurrentTopping(iceCream.Toppings);
                    }
                    else if (toppingCount == 0)
                    {
                        iceCream.Toppings.Clear();
                        Console.WriteLine("Ice Cream has been updated to have no toppings. ");
                    }

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
                break;
            }

        }

        public static void ModifyICToppings(IceCream iceCream)
        {
            Console.WriteLine("----------------------------------- Modifying Ice Cream Toppings -----------------------------------");
            DisplayCurrentTopping(iceCream.Toppings);
            if (iceCream.Toppings.Count > 0)
            {
                while (true)
                {
                    try
                    {
                        Console.WriteLine("Would you like to:");
                        Console.WriteLine("[1] Change number of toppings");
                        Console.WriteLine("[2] Modify current toppings");
                        Console.Write("Please enter an option: ");
                        int choice = Convert.ToInt32(Console.ReadLine());
                        if (choice == 1)
                        {
                            CreateToppings(iceCream);
                        }

                        else if (choice == 2)
                        {
                            DisplayCurrentTopping(iceCream.Toppings);
                            while (true)
                            {
                                try
                                {


                                    Console.Write("Please select which Topping you would like to modify: ");
                                    int chTopping = Convert.ToInt32(Console.ReadLine());
                                    if (chTopping < 0 || chTopping > iceCream.Toppings.Count + 1)
                                    {
                                        Console.WriteLine("Please enter a valid topping number. ");
                                        continue;
                                    }
                                    DisplayAndRead.DisplayToppings();
                                    while (true)
                                    {
                                        try
                                        {
                                            Console.Write("Please select new Topping: ");
                                            int selectedTop = Convert.ToInt32(Console.ReadLine());
                                            if (selectedTop < 0 || selectedTop > 4)
                                            {
                                                Console.WriteLine("Please enter a valid option");
                                                continue;
                                            }
                                            else
                                            {
                                                string modTopping = DisplayAndRead.GetTopping(selectedTop);
                                                iceCream.Toppings[chTopping - 1] = new Topping(modTopping);
                                                Console.WriteLine($"Topping has been changed to {modTopping}");
                                            }
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
                                        break;
                                    }

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
                                break;
                            }

                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid option. ");
                            continue;
                        }
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
                    break;
                }



            }
            else if (iceCream.Toppings.Count == 0)
            {
                Console.Write("Would you like to add new toppings [y/n]?  ");
                string addTopp = Console.ReadLine();
                if (addTopp == "y")
                {
                    CreateToppings(iceCream);
                }

            }
        }
        public static void ModifyWaffleFlav(Waffle iceCream)
        {
            string oldFlav = iceCream.WaffleFlavour;
            Console.WriteLine("\n------------------------------------- Modifying Waffle Flavour -------------------------------------\n");
            Console.WriteLine($"Current Waffle Flavour: {oldFlav}");
            while (true)
            {
                try
                {
                    DisplayAndRead.DisplayWaffleFlavour();
                    Console.Write("Please enter an option number: ");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    //add try catch
                    if (choice < 5 && choice > 0)
                    {
                        string newFlav = DisplayAndRead.GetWaffleFlavour(choice);
                        if (newFlav != oldFlav)
                        {
                            iceCream.WaffleFlavour = newFlav;
                            Console.WriteLine($"Waffle Flavour changed from {oldFlav} to {newFlav}.");
                        }
                        else
                        {
                            Console.WriteLine("Flavour selected is the same as the Old Flavour.");
                        }
                    }

                    else
                    {
                        Console.WriteLine("Please enter a valid option.");
                        continue;
                    }
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
                break;

            }

        }

        public static void ModifyICConeDetails(Cone iceCream)
        {

            Console.WriteLine("------------------------------------- Modifying Ice Cream Cones ------------------------------------");
            while (true)
            {
                try
                {
                    if (iceCream.Dipped)
                    {
                        Console.WriteLine("Current Cone: Chocolate-Dipped Cone");
                        Console.Write("Would you like to change to a normal Cone [y/n]? ");
                        string choice = Console.ReadLine();
                        if (choice == "y")
                        {
                            iceCream.Dipped = false;
                            Console.WriteLine("Cone has been changed to a normal cone. ");
                        }
                        else if (choice == "n")
                        {
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Please enter the character \"y\" or \"n\". ");
                            continue;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Current Cone: Normal Cone");
                        Console.Write("Would you like to change to a Chocolate-Dipped Cone [y/n]? ");
                        string choice = Console.ReadLine();
                        if (choice == "y")
                        {
                            iceCream.Dipped = true;
                            Console.WriteLine("Cone has been changed to a Chocolate-Dipped Cone. ");
                        }
                        else if (choice == "n")
                        {
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Please enter the character \"y\" or \"n\". ");
                            continue;
                        }
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter the character \"y\" or \"n\". ");
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

        public static void UpdateQueue(Order currentOrder, Queue<Order> goldQueue, Queue<Order> regQueue)
        {
            foreach (Order item in goldQueue)
            {
                if (item.Id == currentOrder.Id)
                {
                    item.IceCreamList = currentOrder.IceCreamList;
                    return;
                }
            }
            foreach (Order item in regQueue)
            {
                if (item.Id == currentOrder.Id)
                {
                    item.IceCreamList = currentOrder.IceCreamList;
                    return;
                }
            }
        }
    }
}

