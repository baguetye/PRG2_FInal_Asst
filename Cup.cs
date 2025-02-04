using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

//==========================================================
// Student Number : S10258609
// Student Name : Bryan Lim Aik Sian
// Partner Name : Balakrishnan Rubanaasri
//==========================================================

namespace S10258609_PRG2Assignment
{
    public class Cup : IceCream
    {
        //properties
        public Cup() { }
        public Cup(string option, int scoops, List<Flavour> flavours, List<Topping> toppings) : base(option, scoops, flavours, toppings) { }

        //overriding abstract method - calculate total price ( check if can declare outside as such)!!!!!!
        public override double CalculatePrice()
        {
            double sPrice = 4.00; // initialising sPrice with the default pricing for 1 scoop
            double tPrice;
            double totalPrice;
            //amending sPrice accd to num. of scoops 
            if (Scoops == 2)
            {
                sPrice = 5.50;
            }
            else if (Scoops == 3) //else if OR else??????
            {
                sPrice = 6.50;
            }

            //flavour pricings accd to whether flavour is premium or not
            foreach (Flavour flav in Flavours)
            {
                if (flav.Premium)
                {
                    sPrice += 2.00;
                }
            }

            //default topping price of $1.00
            tPrice = Toppings.Count * 1.00;

            //calculation of total price
            totalPrice = sPrice + tPrice;
            return totalPrice;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
