using System;

namespace SpaceGame
{
    public class GameLogic
    {
        static bool fight;
        public void Game()
        {
            fight = true;
            Player player = new HumanPlayer();
            Player enemy = new ComputerPlayer();

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

                    attacker.Attack(defender);
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
            Console.ReadKey();
            Console.Clear();
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
    }
}
