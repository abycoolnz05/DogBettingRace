using System.Windows.Forms;

namespace DogBettingRace
{
    class Player1 : Gambler
    {

        public Player1(string Name, Bet MyBet, int Cash, RadioButton MyRadioButton, Label MyLabel)

        {
            this.Name = Name;
            this.MyBet = MyBet;
            this.Cash = Cash;
            this.MyRadioButton = MyRadioButton;
            this.MyLabel = MyLabel;
        }
    }
}
