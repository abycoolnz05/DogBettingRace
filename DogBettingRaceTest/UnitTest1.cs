using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace DogBettingRaceTest
{
    [TestClass]
    public class UnitTest1
    {
       
        public Bet MyBet;
        public int Cash;
        public int Amount;

        public int DogNumber;// The number of the dog being bet on
        public Gambler Bettor;
        public PictureBox MyPictureBox;   // The picturebox 
       

        public string Name { get; private set; }

        [TestMethod ]
        public void TestMethod1()
        {
             bool PlaceBet(int Amount, int DogNumber)
            {
                if (Amount <= Cash)
                {
                    MyBet = new Bet(Amount, DogNumber, this);
                    return true;
                }
                return false;
            }

            Assert.IsTrue(Amount<=Cash);
        }

        [TestMethod]
        public void TestMethod2()
        {  
            Assert.IsFalse(MyBet != null);
        }

        
    }
}
