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
    public class Customer
    {
        //properties
        public string Name { get; set; }
        public int Memberid { get; set; }
        public DateTime Dob { get; set; }
        public Order CurrentOrder { get; set; }
        public List<Order> OrderHistory { get; set; } = new List<Order>();
        public PointCard Rewards { get; set; }

        //constructors
        public Customer() { }
        public Customer(string name, int memberid, DateTime dob)
        {
            Name = name;
            Memberid = memberid;
            Dob = dob;
        }

        //methods
        public Order MakeOrder(List<int> orderIdList, DateTime timeReceived)
        {
            int latestId = orderIdList.Last();
            Console.WriteLine(string.Join(",", orderIdList));
            CurrentOrder = new Order(latestId + 1, timeReceived);
            return CurrentOrder;
        }

        public bool IsBirthday()
        {
            if (DateTime.Now.ToString("dd/MM") == Dob.ToString("dd/MM"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return "Name: " + Name + "\t" + "Member ID: " + Memberid + "\t" + "Date of Birth: " + Dob.ToString("dd/mm/yyyy") +
                "\t" + "Current Order: \n" + CurrentOrder + "\n" + "Order History:\n" + string.Join('|', OrderHistory) + "\n" + "Rewards:\n" + Rewards;
        }

    }
}
