using System;

namespace SpaceGame
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            GameLogic game = new GameLogic();

            Menu menu = new Menu();
            menu.AddMenuItem("Start", () => { Console.Clear(); game.StartNewGame();});
            menu.AddMenuItem("Rules", () => PrintRules());
            menu.AddMenuItem("About", () => PrintAbout());
            menu.AddMenuItem("Exit", () => Environment.Exit(0));

            menu.Show();
        }

        public static void PrintRules()
        {
            Console.Clear();
            Console.WriteLine("You have to defeat your enemy");
            Console.WriteLine("You can add GAMEPOINTS by pressing any number exept 0");
            Console.WriteLine("Press 0 if you want to stop adding points");
            Console.WriteLine("If your point will be more than 12 they will be equal 6");
            Console.WriteLine("Good luck!");
            Console.WriteLine("\nPress [Esc] for return.");

            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
            }
        }

        public static void PrintAbout()
        {
            Console.Clear();
            Console.WriteLine("Made by Artem Efremov (Lizard_W1zard)");
            Console.WriteLine("2020");
            Console.WriteLine("\nPress [Esc] for return.");

            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
            }
        }
    }
}

