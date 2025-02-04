using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

//==========================================================
// Student Number : S10258609
// Student Name : Bryan Lim Aik Sian
// Partner Name : Balakrishnan Rubanaasri
//==========================================================

namespace S10258609_PRG2Assignment
{
    public static class BasicReq3
    {
        public static void RegisterNewCustomer(Dictionary<int, Customer> customerDict)
        {
            // name input validation
            string name;
            while (true)
            {
                try
                {
                    Console.Write("Enter your name: ");
                    name = Console.ReadLine();

                    // ensuring user enters name that only has letters & no spaces
                    if (!Regex.IsMatch(name, "^[a-zA-Z]+$"))
                    {
                        throw new ArgumentException("Name should only consist of letters and no spaces. Please try again!");
                    }
                    break; // exiting loop if valid name is entered
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            // memberId input validation
            int memberId;
            while (true)
            {
                try
                {
                    Console.Write("Enter your id number: ");
                    if (int.TryParse(Console.ReadLine(), out memberId))
                    {
                        string stringMemberId = memberId.ToString();
                        //ensuring id isn't negative, its a 6digit number & it alr doesn't exist
                        if (stringMemberId.Length != 6 || memberId < 0)
                        {
                            throw new ArgumentException("MemberId should be a 6-digit positive integer only. Please try again!");
                        }
                        else if (customerDict.ContainsKey(memberId))
                        {
                            throw new ArgumentException("Existing memberId has been entered. Please try again!");
                        }
                        break; // exiting loop if valid memberId is entered
                    }
                    else
                    {
                        //handling invalid data
                        throw new ArgumentException($"MemberId should be an integer only. Please try again!");
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            // dob input validation
            DateTime dob;
            while (true)
            {
                try
                {
                    Console.Write("Enter your date of birth (dd/mm/yyyy): ");
                    if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dob))
                    {
                        if (dob > DateTime.Now)
                        {
                            throw new ArgumentException("Invalid date. Date of birth cannot be a future date. Please try again!");
                        }
                        break; // exiting loop if valid dob is entered
                    }
                    else
                    {
                        //handling invalid data
                        throw new ArgumentException($"Invalid format. Please enter date of birth only in (dd/MM/yyyy) format!");
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            //create new customer & pointcard objs
            Customer newCustomer = new Customer(name, memberId, dob);
            PointCard newPointCard = new PointCard(0, 0);
            newCustomer.Rewards = newPointCard; //assigning pointcard obj to new customer

            //append customer info to customers csv file
            string newDetails = $"{newCustomer.Name},{newCustomer.Memberid},{newCustomer.Dob.ToString("dd/MM/yyyy")},{newCustomer.Rewards.Tier},{newCustomer.Rewards.Points},{newCustomer.Rewards.PunchCard}";
            using (StreamWriter sw = new StreamWriter("customers.csv", true))
            {
                sw.WriteLine(newDetails);
            }
            Console.WriteLine("New customer added!"); //message to indicate registeration status
        }
    }
}
