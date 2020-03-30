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

            //enemy.EnemyDamage = player.Damage;
            //player.EnemyDamage = enemy.Damage;

            player.OutPutStats();
            enemy.OutPutStats();

            Console.WriteLine("/ / / / Game started / / / /");

            while (fight)
            {
                player.CanAddGamePoints = true;
                enemy.CanAddGamePoints = true;

                player.ResetGamePoints();
                enemy.ResetGamePoints();

                while (player.CanAddGamePoints)
                {
                    player.TakeScores();
                    player.CheckIfOutOfBounds();
                }

                while (CanAddGamePoints(enemy))
                {
                    enemy.TakeScores();
                }
                
                enemy.CheckIfOutOfBounds();

                var defender = WhoGetDamage(player, enemy);
                var attacker = WhoGiveDamage(player, enemy);
                //attacked?.GetDamage(CountGamePoints(player, enemy));
                if (attacker != null && defender != null)
                {
                    GetDamage(CountGamePoints(player, enemy), attacker, defender);
                }



                player.OutPutStats();
                enemy.OutPutStats();

                Console.WriteLine("Turn ended");
                Console.WriteLine(" ");

                fight = CheckIsFightContinue(player, enemy);
            }

            Console.WriteLine("/ / / / Game ended / / / /");

            player.OutPutStats();
            enemy.OutPutStats();

            Console.WriteLine($"Loser: {WhoGetDamage(player, enemy)}");

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

        static Player WhoGiveDamage(Player player, Player bot)
        {
            if (player.GamePoints < bot.GamePoints)
            {
                return bot;
            }
            else if (player.GamePoints > bot.GamePoints)
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

        static void GetDamage(int countOfHits, Player attacker, Player defender)
        {
            defender.Health -= attacker.Damage * countOfHits; 
        }

    }
}