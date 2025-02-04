using S10257201_PRG2Assignment;
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
    public class Order
    {
        //properties
        public int Id { get; set; }
        public DateTime TimeReceived { get; set; }
        public DateTime? TimeFulfilled { get; set; }
        public List<IceCream> IceCreamList { get; set; } = new List<IceCream>();

        //constructor
        public Order() { }
        public Order(int id, DateTime timeRecieved)
        {
            Id = id;
            TimeReceived = timeRecieved;
        }

        //methods
        public void ModifyIceCream(int index) //takes in an int to access the Ice Cream in the list
        {
            while (true)
            {
                try
                {
                    DisplayAndRead.ModifyIceCreamDisplay(IceCreamList[index].Option);
                    Console.Write("Please enter an option number: ");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    if (choice == 1)
                    {
                        IceCreamList[index] = BasicReq6.ModifyICOption(IceCreamList[index]);
                    }
                    else if (choice == 2)
                    {
                        BasicReq6.ModifyICScoops(IceCreamList[index]);
                    }
                    else if (choice == 3)
                    {
                        BasicReq6.ModifyICFlav(IceCreamList[index]);
                    }
                    else if (choice == 4)
                    {
                        BasicReq6.ModifyICToppings(IceCreamList[index]);
                    }
                    else if (choice == 5 && (IceCreamList[index] is Waffle || IceCreamList[index] is Cone))
                    {
                        if (IceCreamList[index] is Waffle)
                        {
                            BasicReq6.ModifyWaffleFlav((Waffle)IceCreamList[index]);
                        }
                        else
                        {
                            BasicReq6.ModifyICConeDetails((Cone)IceCreamList[index]);
                        }
                    }
                    else if (choice == 0)
                    {
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid option number");
                        continue;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter an integer for the option number");
                    continue;
                }
                catch (Exception)
                {
                    Console.WriteLine("Please try again. ");
                    continue;
                }
            }

        }

        public void AddIceCream(IceCream iceCream)
        {
            IceCreamList.Add(iceCream);
        }

        public void DeleteIceCream(int i)
        {
            IceCreamList.RemoveAt(i);
        }

        public double CalculateTotal()
        {
            double total = 0;
            foreach (IceCream c in IceCreamList)
            {
                total += c.CalculatePrice();
            }
            return total;
        }

        public override string ToString()
        {
            return "ID: " + Id + "\t" + "Time Recieved: " + TimeReceived.ToString() + "\t" + "Time Fulfilled: " + TimeFulfilled.ToString() + "\t" + "Ice Cream List: " + string.Join(" | ", IceCreamList);
        }
    }
}
