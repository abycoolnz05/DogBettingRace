using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DogBettingRace
{
    public partial class Form1 : Form
    {
        private List<RaceDog> Contestants = new List<RaceDog>();
        private List<Gambler> Gamblers = new List<Gambler>();
        private int gamblerNumber = 0;
        
        public Form1()
        {
            InitializeComponent();
            SetupRaceTrack();
        }

        private void SetupRaceTrack()
        {
            Gamblers.Clear();
            Contestants.Clear();

            int startingPosition = imgDog1.Right - imgRacingTrack.Left;  // Sets the starting position 
            // Sets the race track length
            int raceTrackLength = imgRacingTrack.Size.Width;

            // Instantiates and adds the 4 RacingCar objects to the Contestants List and gives values to their properties
            Contestants.Add(new RaceDog(imgDog1, raceTrackLength, startingPosition));
            Contestants.Add(new RaceDog(imgDog2, raceTrackLength, startingPosition));
            Contestants.Add(new RaceDog(imgDog3, raceTrackLength, startingPosition));
            Contestants.Add(new RaceDog(imgDog4, raceTrackLength, startingPosition));

            // Adds the Gamblers to the List
            AddTheGamblers();

            // Set the labels and radio text for the gamblers
            foreach (Gambler g in Gamblers)
            {
                g.UpdateLabels();
            }
            assignRadioText();     //Radio BUttons Eanabled Function
        }

        private void btnRace_Click(object sender, EventArgs e) // Button Race
        {
            bool NoWinner = true;
            int winningDog;
            btnRace.Enabled = false;
            btnPlaceBet.Enabled = false;

            //While  no winner
            while (NoWinner)
            {
                Application.DoEvents();
                for (int i = 0; i < Contestants.Count; i++)
                {
                    if (Contestants[i].Race())
                    {
                        winningDog = i + 1;
                        NoWinner = false;
                        MessageBox.Show("We have a winner - Dog # " + winningDog);

                        foreach (Gambler gambler in Gamblers )
                        {
                            if (gambler.MyBet != null)
                            {
                                gambler.Collect(winningDog);
                                gambler.MyBet = null;
                                gambler.UpdateLabels();
                            }
                        }
                        foreach (RaceDog dog in Contestants)
                        {
                            dog.TakeStartingPosition();
                        }
                        break;
                    }
                }
            }

            btnRace.Enabled = true;                   //Enable Buttons
            btnPlaceBet.Enabled = true;

            CheckCash();
            rbDisabledCheck();
        }

        private void imgRacingTrack_Click(object sender, EventArgs e)
        {

        }

        private void rbPunter0_CheckedChanged(object sender, EventArgs e)    // Check Boxes
        {
            // Player1 checkbox
            inputBetAmount.Maximum = Gamblers[0].Cash;
            labelMaxBet.Text = Gamblers[0].Cash.ToString();
        }
        private void rbPunter1_CheckedChanged(object sender, EventArgs e)
        {
            // Player2 checkbox
            inputBetAmount.Maximum = Gamblers[1].Cash;
            labelMaxBet.Text = Gamblers[1].Cash.ToString();
        }

        private void RbPunter2_CheckedChanged(object sender, EventArgs e)
        {
            // Player3 checkbox
            inputBetAmount.Maximum = Gamblers[2].Cash;
            labelMaxBet.Text = Gamblers[2].Cash.ToString();
        }

        private void btnPlaceBet_Click(object sender, EventArgs e)     // Place Bet Button
        {
          
            if (rbGambler0.Checked)
            {
                gamblerNumber = 0;
            }

            if (rbGambler1.Checked)
            {
                gamblerNumber = 1;
            }

            if (rbGambler2.Checked)
            {
                gamblerNumber = 2;
            }

            // If the gambler[number] cash property value is less then the amount bet
            if (Gamblers[gamblerNumber].Cash < inputBetAmount.Value)
            {
                MessageBox.Show("You cannot bet $" + inputBetAmount.Value + " You only have $" +
                Gamblers[gamblerNumber].Cash);
            }
            else
            {
                Gamblers[gamblerNumber].PlaceBet((int)inputBetAmount.Value, (int)inputDogNumber.Value);

                // Update the labels on the form for the Gambler
                Gamblers[gamblerNumber].UpdateLabels();

            }
        }
  
        // Set the RadioButtons for the associated Gambler and Enables the radio buttons if Disabled
  
        private void assignRadioText()
        {
            labelMaxBet.Text = null;

            rbGambler0.Enabled = true;
            rbGambler1.Enabled = true;
            rbGambler2.Enabled = true;

            rbGambler0.Text = Gamblers[0].Name;
            rbGambler1.Text = Gamblers[1].Name;
            rbGambler2.Text = Gamblers[2].Name;

            foreach (Gambler g in Gamblers)
            {
                g.UpdateLabels();
            }
        }

        /// Checks all of the Gamblers cash and updates their labels, if they finish betting all amount
        ///  Radiobuttons r  disabled and label text is changed
        private void CheckCash()
        {
            foreach (Gambler p in Gamblers)
            {
                p.UpdateLabels();

                if (p.Cash == 0)
                {
                    p.MyRadioButton.Enabled = false;
                    p.MyLabel.Text = p.Name + " is BUSTED !";
                }
            }
        }
     
        private void btnReset_Click(object sender, EventArgs e)   // Reset Button
        {
           
        }

        private void rbDisabledCheck()
        {
            if (rbGambler0.Enabled == false & rbGambler1.Enabled == false & rbGambler2.Enabled == false)
            {
                btnPlaceBet.Enabled = false;
                btnRace.Enabled = false;
            }
        }
        /// Adds Player1, Player2 and Player3 and their property values to the Gambler List
        public void AddTheGamblers()
        {
            Gamblers.Add(new Player1("Player1", null, 15, rbGambler0, label5));
            Gamblers.Add(new Player2("Player2", null, 15, rbGambler1, label6));
            Gamblers.Add(new Player3("Player3", null, 15, rbGambler2, label7));
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnReset_Click_1(object sender, EventArgs e) // Reset click
        {
            SetupRaceTrack();
            btnPlaceBet.Enabled = true;
            btnRace.Enabled = true;
            labelMaxBet.Text = Gamblers[0].Cash.ToString();
        }

        private void rbGroup_Enter(object sender, EventArgs e)
        {

        }
    }
}
