using System;

namespace SpaceGame
{
    public class GameLogic
    {
        static bool fight;

        static Player player = new HumanPlayer();
        static Player enemy = new ComputerPlayer();

        public void StartNewGame()
        {
            CreateNewStats();

            fight = true;

            AskForOutPut();

            Console.WriteLine("/ / / / Game started / / / /");

            while (fight)
            {
                SetNewTurn();

                while (player.CanAddGamePoints)
                {
                    player.TakeScores();
                    player.CheckPointsRange();
                }

                while (CanAddGamePoints(enemy))
                {
                    enemy.TakeScores();
                }

                enemy.CheckPointsRange();

                if (player.GamePoints != enemy.GamePoints)
                {
                    var attacker = (player.GamePoints > enemy.GamePoints) ? player : enemy;
                    var defender = (attacker == player) ? enemy : player;

                    attacker.Attack(defender);
                }

                Console.Clear();

                AskForOutPut();

                if (player.GamePoints == enemy.GamePoints)
                    Console.WriteLine("Nobody get damage");
                else if (player.GamePoints > enemy.GamePoints)
                    Console.WriteLine("Computer get damage");
                else Console.WriteLine("Player get damage");

                Console.WriteLine("Turn ended");

                fight = IsFightContinue();
            }

            Console.Clear();
            Console.WriteLine("/ / / / Game ended / / / /");

            AskForOutPut();

            Console.WriteLine($"Winner: {(player.Health < 0 ? "computer" : "player")}");
            Console.ReadKey();
            Console.Clear();
        }

        static void CreateNewStats()
        {
            player = new HumanPlayer();
            enemy = new ComputerPlayer();
        }

        static void SetNewTurn() //TODO изменить имя метода
        {
            player.ResetGamePoints();
            player.CanAddGamePoints = true;

            enemy.ResetGamePoints();
            enemy.CanAddGamePoints = true;
        }

        static void AskForOutPut() //TODO изменить имя метода
        {
            Console.WriteLine("   You");
            player.OutPutStats();
            Console.WriteLine("   Enemy");
            enemy.OutPutStats();
        }

        static bool IsFightContinue()
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