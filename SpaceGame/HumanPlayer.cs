using System;

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
            bool isCorrectInput = false;
            int input = 0;

            while (!isCorrectInput)
            {
                isCorrectInput = int.TryParse(Console.ReadKey().KeyChar.ToString(), out input);
            }

            CheckerForPoints = input;

            if (CheckerForPoints == 0)
            {
                CanAddGamePoints = false;
            }
            else
            {
                GamePoints += new Random().Next(1, 7);
                Console.Clear();
                Console.Write($"GamePoints: ");
                ColorGamePoints();
                Console.WriteLine($"/12");
            }
        }
    }
}
