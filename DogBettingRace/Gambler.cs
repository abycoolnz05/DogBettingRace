using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DogBettingRace
{
    class Gambler
    {
        public string Name;
        public Bet MyBet; 
        public int Cash; 
        public RadioButton MyRadioButton; // MyRadioButton
        public Label MyLabel; //Label to hold data

        public void UpdateLabels()
        {
            if (MyBet == null)
            {
                MyLabel.Text = Name + " hasn't placed any bets";
                //   String.Format("{0} hasn't placed any bets", Name);
            }
            else
            {
                MyLabel.Text = MyBet.GetDescription();
            }
            MyRadioButton.Text = Name + " has " + Cash + " dollars";
        }

        public void ClearBet()
        {
            MyBet.Amount = 0;
        }

        public bool PlaceBet(int Amount, int DogNumber)
        {
            if (Amount <= Cash)
            {
                MyBet = new Bet(Amount,DogNumber, this);
                return true;
            }
            return false;
        }

        public void Collect(int Winner)
        {
            Cash += MyBet.Payout(Winner);
        }
    }
}
