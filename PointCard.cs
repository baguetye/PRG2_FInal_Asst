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
    public class PointCard
    {
        //properties
        public int Points { get; set; }
        public int PunchCard { get; set; }
        public string Tier { get; set; } = "Ordinary";

        //constructor
        public PointCard() { }
        public PointCard(int points, int punchCard)
        {
            Points = points;
            PunchCard = punchCard;
            if (Points >= 50)
            {
                Tier = "Silver";
            }
            else if (Points >= 100)
            {
                Tier = "Gold";
            }
        }

        //methods
        public void AddPoints(int points)
        {
            Points += points;
            if (Points > 50 && Tier == "Ordinary")
            {
                Tier = "Silver";
            }
            if (Points > 100 && Tier != "Gold")
            {
                Tier = "Gold";
            }
        }

        public void RedeemPoints(int points)
        {
            Points -= points;
        }

        public void Punch()
        {
            if (PunchCard == 10)
            {
                return;
            }
            else if (PunchCard < 10)
            {
                PunchCard++;
            }
        }

        public override string ToString()
        {
            return "Points: " + Points + "\t" + "Punch Card: " + PunchCard + "\t" + "Tier: " + Tier;
        }

    }
}