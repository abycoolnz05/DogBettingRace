using System;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace DogBettingRace
{
    class RaceDog
    {
        public int StartingPosition;       // Start Position
        public int RaceTrackLength;       // The RaceTrackLength 
        public PictureBox MyPictureBox;   // The picturebox 
        public int Location = 0;
        public Random random;

        //  Picturebox, Racetrack length and Starting position
        public RaceDog(PictureBox pb, int raceTrackLength, int startingPosition)
        {
            MyPictureBox = pb;
            RaceTrackLength = raceTrackLength;
            StartingPosition = startingPosition;
        }
  
        public bool Race()
        {
            random = new Random();
            Thread.Sleep(5);           
            Point p = MyPictureBox.Location; // Sets the point to the current picturebox location
            int distance = random.Next(1, 10); // Random Distance for dog to move
            MoveMyPictureBox(distance);
            Location += distance;

            // If dog = at the finish line  
            if (Location >= (RaceTrackLength - StartingPosition))
            {
                return true;
            }
            return false;
        }

        public void MoveMyPictureBox(int distance) // Function to move pic box
        {
            Point p = MyPictureBox.Location;
            p.X += distance;
            MyPictureBox.Location = p;
        }

        public void TakeStartingPosition()  //Resets location to the starting position
        {
            MoveMyPictureBox(-Location);
            Location = 0;
        }
    }
}
