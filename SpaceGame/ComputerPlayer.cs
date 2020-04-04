using System;

namespace SpaceGame
{
    public class ComputerPlayer : Player
    {
        public ComputerPlayer()
        {
            MinHealth = 80;
            MaxHealth = 91;
            MinDamage = 5;
            MaxDamage = 16;

            Initialization();
        }

        public override void TakeScores()
        {
            GamePoints += new Random().Next(1, 7);
        }     
    }
}
