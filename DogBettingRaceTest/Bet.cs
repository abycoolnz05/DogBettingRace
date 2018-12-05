using System;

namespace DogBettingRaceTest
{
    public class Bet
    {
        internal int Amount;
        private int dogNumber;
        private UnitTest1 unitTest1;

        public Bet(int amount, int dogNumber, UnitTest1 unitTest1)
        {
            Amount = amount;
            this.dogNumber = dogNumber;
            this.unitTest1 = unitTest1;
        }

        internal int Payout(int winner)
        {
            throw new NotImplementedException();
        }

        internal string GetDescription()
        {
            throw new NotImplementedException();
        }
    }
}