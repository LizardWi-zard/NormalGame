using System;

namespace SpaceGame
{
    public class Program
    {
        static bool fight = true;
        public static void Main()
        {
            Player player = new HumanPlayer();
            Player enemy = new ComputerPlayer();

            player.OutPutStats();
            enemy.OutPutStats();

            Console.WriteLine("/ / / / Игра начата / / / /");

            while (fight)
            {
                player.ResetGamePoints();
                enemy.ResetGamePoints();

                while (CanAddGamePoints(player) && CanAddGamePoints(enemy))
                {
                    player.AddPersonalPoints();
                    enemy.AddPersonalPoints();
                }

                player.CheckIfOutOfBounds();
                enemy.CheckIfOutOfBounds();

                var attacked = WhoGetDamage(player, enemy);
                attacked?.GetDamage(CountGamePoints(player, enemy));

                player.OutPutStats();
                enemy.OutPutStats();

                Console.WriteLine("Turn ended");
                Console.WriteLine(" ");

                fight = CheckIsFightContinue(player, enemy);
            }

            Console.WriteLine("/ / / / Игра окончена / / / /");

            player.OutPutStats();
            enemy.OutPutStats();

            Console.WriteLine($"Проигравший: {WhoGetDamage(player, enemy)}");

            Console.ReadKey();
        }

        static int CountGamePoints(Player player, Player bot)
        {
            if (player.GamePoints > bot.GamePoints)
            {
                return player.GamePoints - bot.GamePoints;
            }
            else if (player.GamePoints < bot.GamePoints)
            {
                return bot.GamePoints - player.GamePoints;
            }
            else
            {
                return 0;
            }
        }

        static Player WhoGetDamage(Player player, Player bot)
        {
            if (player.GamePoints > bot.GamePoints)
            {
                return bot;
            }
            else if (player.GamePoints < bot.GamePoints)
            {
                return player;
            }
            else
            {
                return null;
            }
        }

        static bool CheckIsFightContinue(Player player, Player bot)
        {
            if (player.Health <= 0 || bot.Health <= 0)
            {
                return false;
            }
            else return true;
        }

        static bool CanAddGamePoints(Player currentPlayer)
        {
            if (currentPlayer.GamePoints >= 9)
            {
                return false;
            }
            else return true;
        }
    }
}