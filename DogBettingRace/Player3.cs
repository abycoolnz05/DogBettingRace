using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DogBettingRace
{
    class Player3 : Gambler
    {

        public Player3(string Name, Bet MyBet, int Cash, RadioButton MyRadioButton, Label MyLabel)

        {
            this.Name = Name;
            this.MyBet = MyBet;
            this.Cash = Cash;
            this.MyRadioButton = MyRadioButton;
            this.MyLabel = MyLabel;
        }


    }
}
