using System;
using System.Collections;
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
    public static class BasicReq1
    {
        // method to read the customers.csv file & display it as a table
        public static ArrayList ReadCustomersFile()
        {
            using (StreamReader sr = new StreamReader("customers.csv"))
            {
                ArrayList arrayList = new ArrayList();
                string line = sr.ReadLine();
                string[] headerArray = line.Split(',');

                Dictionary<int, Customer> customersDict = new Dictionary<int, Customer>();

                while ((line = sr.ReadLine()) != null)
                {
                    // creating customer object & adding to dict
                    string[] customerDetails = line.Split(",");
                    Customer customer = new Customer(customerDetails[0], Convert.ToInt32(customerDetails[1]), DateTime.ParseExact(customerDetails[2], "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture));
                    customer.Rewards = new PointCard(Convert.ToInt32(customerDetails[4]), Convert.ToInt32(customerDetails[5]));
                    customer.Rewards.Tier = customerDetails[3];
                    customersDict.Add(Convert.ToInt32(customerDetails[1]), customer);
                }
                arrayList.Add(headerArray);
                arrayList.Add(customersDict);
                return arrayList;
            }
        }

        // method to display all customer details
        public static void ListAllCustomers(ArrayList arrayList)
        {
            string[] headerArray = (string[])arrayList[0]; // initialising the header array
            Dictionary<int, Customer> customerDict = (Dictionary<int, Customer>)arrayList[1]; // initialising the customerDict

            //displaying header & all of the customer details
            Console.WriteLine("{0,-10} {1,-10} {2,-15} {3,-20} {4,-20} {5,-10}", headerArray[0], headerArray[1], headerArray[2], headerArray[3], headerArray[4], headerArray[5]);

            foreach (Customer customer in customerDict.Values)
            {
                Console.WriteLine("{0,-10} {1,-10} {2,-15} {3,-20} {4,-20} {5}", customer.Name, customer.Memberid, customer.Dob.ToString("dd/MM/yyyy"), customer.Rewards.Tier, customer.Rewards.Points, customer.Rewards.PunchCard);
            }
        }
    }
}
