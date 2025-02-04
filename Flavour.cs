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
    public class Flavour
    {
        //properties
        public string Type { get; set; }
        public bool Premium { get; set; }
        public int Quantity { get; set; }

        //constructor
        public Flavour() { }

        public Flavour(string type, bool premium, int quantity)
        {
            Type = type;
            Premium = premium;
            Quantity = quantity;
        }

        //methods
        public override string ToString()
        {
            return "Type: " + Type + "\t" + "Premium: " + Premium + "\t" + "Quantity: " + Quantity;
        }
    }
}
