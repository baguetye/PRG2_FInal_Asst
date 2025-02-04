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
    public class Cone : IceCream
    {
        //property
        public bool Dipped { get; set; }

        //constructors
        public Cone() { }
        public Cone(string option, int scoops, List<Flavour> flavours, List<Topping> toppings, bool dipped) : base(option, scoops, flavours, toppings)
        {
            Dipped = dipped;
        }

        //overriding abstract method - calculate total price
        double sPrice;
        double tPrice;
        double totalPrice;
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

            //addOns pricings accd to whether cone is dipped or not
            if (Dipped)
            {
                sPrice += 2.00;
            }

            //default topping price of $1.00
            tPrice = Toppings.Count * 1.00;

            //calculation of total price
            totalPrice = sPrice + tPrice;
            return totalPrice;

        }

        public override string ToString()
        {
            return base.ToString() + "\t" + "Dipped: " + Dipped;
        }
    }
}