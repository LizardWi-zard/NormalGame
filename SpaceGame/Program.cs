using System;

namespace SpaceGame
{
    public class Program
    {
        static bool fight = true;
        public static void Main()
        {
            PrintRules();

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

                if (player.GamePoints != enemy.GamePoints)
                {
                    var attacker = (player.GamePoints > enemy.GamePoints) ? player : enemy;
                    var defender = (attacker == player) ? enemy : player;

                    Battle(attacker, defender);
                }
                
                Console.Clear();
                Console.WriteLine("");
                player.OutPutStats();
                enemy.OutPutStats();

                if (player.GamePoints == enemy.GamePoints)
                    Console.WriteLine("Nobody get damage");
                else if (player.GamePoints > enemy.GamePoints)
                    Console.WriteLine("Computer get damage");
                else Console.WriteLine("Player get damage");



                Console.WriteLine("Turn ended");

                fight = CheckIsFightContinue(player, enemy);
            }

            Console.WriteLine("/ / / / Game ended / / / /");

            player.OutPutStats();
            enemy.OutPutStats();

            Console.WriteLine($"Winner: {(player.Health < 0 ? "computer" : "player")}");
            //Console.WriteLine($"Loser: {WhoGetDamage(player, enemy)}");

            Console.ReadKey();
        }
        static void Battle(Player attacker, Player defender)
        {
            defender.Health -= attacker.Damage * (attacker.GamePoints - defender.GamePoints);
        }
        static bool CheckIsFightContinue(Player player, Player enemy)
        {
            if (player.Health <= 0 || enemy.Health <= 0)
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

        static void PrintRules()
        {
            Console.WriteLine("You have to defeat your enemy");
            Console.WriteLine("You can add GAMEPOINTS by pressing any number exept 0");
            Console.WriteLine("Press 0 if you want to stop adding points");
            Console.WriteLine("If your point will be more than 12 they will be equal 6");
            Console.WriteLine("Good luck!");
            Console.WriteLine("");
        }
    }
}
