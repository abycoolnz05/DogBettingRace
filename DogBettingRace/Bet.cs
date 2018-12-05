using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogBettingRace
{
    class Bet
    {
        public int Amount; // The amount of cash that was bet
        public int DogNumber;// The number of the dog being bet on
        public Gambler Bettor; // The gambler who placed the bet

        public Bet(int Amount, int DogNumber, Gambler Bettor)
        {
            this.Amount = Amount;
            this.DogNumber = DogNumber;
            this.Bettor = Bettor;
        }

        public string GetDescription()
        {
            string description = "";

            if (Amount > 0)
            {
                description = string.Format("{0} bets {1} dollars on dog #{2}",
                    Bettor.Name, Amount, DogNumber);
            }
            else
            {
                description = string.Format("{0} hasn't placed any bets",
                    Bettor.Name);
            }
            return description;
        }

        public int Payout(int Winner)
        {

            if (DogNumber == Winner)
            {
                return Amount;
            }
            else
            {
                return -Amount;
            }
        }

    }
}
