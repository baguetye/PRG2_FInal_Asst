using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10258609_PRG2Assignment
{
    public static class AdvancedPartB
    {
        public static void ChargeBreakdowns(Dictionary<int, Customer> customerDict)
        {
            // prompting user for memberId to place order accordingly
            int memberId;
            while (true)
            {
                try
                {
                    Console.Write("Enter your id number: ");
                    if (int.TryParse(Console.ReadLine(), out memberId))
                    {
                        string stringMemberId = memberId.ToString();
                        //ensuring id isn't negative, its a 6digit number & it alr exists
                        if (stringMemberId.Length != 6 || memberId < 0)
                        {
                            throw new ArgumentException("MemberId should be a 6-digit positive integer only. Please try again!");
                        }
                        else if (!customerDict.ContainsKey(memberId))
                        {
                            throw new KeyNotFoundException("Invalid memberId entered. MemberId doesn't exist. Please try again.");
                        }
                        break; // exiting loop if valid memberId is entered
                    }
                    else
                    {
                        //handling invalid data
                        throw new FormatException("MemberId should be an integer only. Please try again!");
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (KeyNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Customer customerRetrieved = customerDict[memberId];

            while (true)
            {
                try
                {
                    Console.Write("Enter the year to retrieve amount breakdown: ");
                    if (int.TryParse(Console.ReadLine(), out int year))
                    {
                        if (year <= DateTime.Now.Year) //ensuring its either past or current year only
                        {
                            // dictionary to store monthly totals
                            Dictionary<int, double> monthlyTotals = new Dictionary<int, double>();
                            double yearTotal = 0.0;

                            List<Order> orderList = customerRetrieved.OrderHistory;
                            foreach (Order order in orderList)
                            {
                                int receivedYear = Convert.ToDateTime(order.TimeFulfilled).Year;

                                if (year == receivedYear) // looking through orders of that year only
                                {
                                    int month = Convert.ToDateTime(order.TimeFulfilled).Month;
                                    if (!monthlyTotals.ContainsKey(month))
                                    {
                                        monthlyTotals[month] = 0.0; // initialising total to 0.0 if month isn't alr in the dict
                                        foreach (IceCream iceCream in order.IceCreamList)
                                        {
                                            monthlyTotals[month] += iceCream.CalculatePrice(); // adding on to each month's total 
                                        }
                                    }
                                    else
                                    {
                                        foreach (IceCream iceCream in order.IceCreamList)
                                        {
                                            monthlyTotals[month] += iceCream.CalculatePrice(); // adding on to each month's total 
                                        }
                                    }
                                }
                            }

                            foreach (KeyValuePair<int, double> monthNum in monthlyTotals)
                            {
                                string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(monthNum.Key);
                                yearTotal += monthNum.Value;
                                Console.WriteLine();
                                Console.WriteLine($"{monthName} {year}: ${monthNum.Value:F2}");
                            }
                            Console.WriteLine();
                            Console.WriteLine($"Total: ${yearTotal:F2}"); // total for that year
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid year entered. Year that isnt past or current cannot be entered. Please try again!");
                            continue;
                        }

                    }
                    else
                    {
                        Console.WriteLine("Invalid format. Please enter year in integer only!");
                        continue;
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
