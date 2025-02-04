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
    public class Topping
    {
        //properties
        public string Type { get; set; }

        //constructors
        public Topping() { }

        public Topping(string type)
        {
            Type = type;
        }

        //method
        public override string ToString()
        {
            return "Type: " + Type;
        }
    }
}


