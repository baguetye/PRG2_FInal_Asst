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
    public class Waffle : IceCream
    {
        //property
        public string WaffleFlavour { get; set; }

        //constructors
        public Waffle() { }
        public Waffle(string option, int scoops, List<Flavour> flavours, List<Topping> toppings, string waffleFlavour) : base(option, scoops, flavours, toppings)
        {
            WaffleFlavour = waffleFlavour;
        }

        //overriding abstract method - calculate total price
        public override double CalculatePrice()
        {
            double sPrice = 7.00; // initialising sPrice with the default pricing for 1 scoop
            double tPrice;
            double totalPrice;
            //scoop pricings accd to num. of scoops 
            if (Scoops == 2)
            {
                sPrice = 8.50;
            }
            else if (Scoops == 3) //else if OR else??????
            {
                sPrice = 9.50;
            }

            //flavour pricings accd to whether icecream flavour is premium or not
            foreach (Flavour flav in Flavours)
            {
                if (flav.Premium)
                {
                    sPrice += 2.00;
                }
            }

            //addOns pricings accd to whether waffle is specific flavour or not
            if (WaffleFlavour.ToLower() == "red velvet" || WaffleFlavour.ToLower() == "charcoal" || WaffleFlavour.ToLower() == "pandan")
            {
                sPrice += 3.00;
            }

            //default topping price of $1.00
            tPrice = Toppings.Count * 1.00;

            //calculation of total price
            totalPrice = sPrice + tPrice;
            return totalPrice;
        }

        public override string ToString()
        {
            return base.ToString() + "\t" + "Waffle Flavour: " + WaffleFlavour;
        }
    }
}