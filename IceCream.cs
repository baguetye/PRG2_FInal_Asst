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
    public abstract class IceCream
    {
        //properties
        public string Option { get; set; }
        public int Scoops { get; set; }
        public List<Flavour> Flavours { get; set; } = new List<Flavour>();
        public List<Topping> Toppings { get; set; } = new List<Topping>();

        //constructors
        public IceCream() { }

        public IceCream(string option, int scoops, List<Flavour> flavours, List<Topping> toppings)
        {
            Option = option;
            Scoops = scoops;
            Flavours = flavours;
            Toppings = toppings;
        }

        //abstract method
        public abstract double CalculatePrice();

        public override string ToString()
        {
            return "Option: " + Option + "\t" + "Scoops: " + Scoops +
                "\t" + "Flavours: " + string.Join(" | ", Flavours) + "\t" + "Toppings: " + string.Join(" | ", Toppings);
        }

    }
}
