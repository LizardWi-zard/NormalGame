using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceGame
{
    public class HumanPlayer : Player
    {
        int CheckerForPoints;
        public HumanPlayer()
        {
            MinHealth = 80;
            MaxHealth = 101;
            MinDamage = 9;
            MaxDamage = 16;

            Initialization();
        }

        public override void TakeScores()
        {
            //Console.WriteLine("Add points?");
            //Console.WriteLine("0 for NO / 1 to YES");

            CheckerForPoints = Convert.ToInt32(Console.ReadLine());
                                                                         
            if(CheckerForPoints == 0)
            {
                CanAddGamePoints = false;
            } 
            else
            {
                GamePoints += new Random().Next(1, 7);
                Console.WriteLine($"Current gamePoints: {GamePoints}/12");
            }
        }
    }
}
