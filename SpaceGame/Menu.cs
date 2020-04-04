using System;
using System.Collections.Generic;
using System.Linq;

namespace SpaceGame
{
    class Menu
    {
        static GameLogic game = new GameLogic();
        static ConsoleKey pressedKey = Console.ReadKey().Key;
        static MenuDebug menu = new MenuDebug();
        static Dictionary<string, Action> MenuManager = new Dictionary<string, Action>{
            { "Start", () => { game.Game(); } },
            { "Rules", () => { menu.PrintRules(); } },
            { "About", () => { menu.PrintAbout(); } },
            { "Exit", () => {  System.Diagnostics.Process.GetCurrentProcess().Kill(); } }
        };
        public static void Main()
        {            
            int a = 0;
            PrintMenu(a);

            while (pressedKey != ConsoleKey.Escape)
            {
                pressedKey = Console.ReadKey().Key;
                Console.Clear();

                switch (pressedKey)
                {
                    case ConsoleKey.UpArrow:
                        if (a == 0)
                            a = 0;
                        else a--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (a == 3)
                            a = 3;
                        else a++;
                        break;
                    case ConsoleKey.Enter:
                        MenuManager.ElementAt(a).Value();
                        break;
                    case ConsoleKey.Escape:
                        Console.Clear();
                        break;
                }
                        PrintMenu(a);
            }
        }

        static void PrintMenu(int a)
        {
            for (int i = 0; i < MenuManager.Count; i++)
            {
                if (i == a)
                { Console.WriteLine(">" + MenuManager.ElementAt(i).Key); }
                else { Console.WriteLine(" " + MenuManager.ElementAt(i).Key); }
            }
        }
    }

    class MenuDebug
    {
        public void PrintRules()
        {
            Console.WriteLine("You have to defeat your enemy");
            Console.WriteLine("You can add GAMEPOINTS by pressing any number exept 0");
            Console.WriteLine("Press 0 if you want to stop adding points");
            Console.WriteLine("If your point will be more than 12 they will be equal 6");
            Console.WriteLine("Good luck!");
            Console.WriteLine("");

            ConsoleKey neededKey = Console.ReadKey().Key;
            while (neededKey != ConsoleKey.Escape)
            {
                neededKey = Console.ReadKey().Key;
            }
            Console.Clear();
        }
        public void PrintAbout()
        {
            Console.WriteLine("Made by Artem Efremov (Lizsrd_W1zard)");
            Console.WriteLine("2020");

            ConsoleKey neededKey = Console.ReadKey().Key;
            while (neededKey != ConsoleKey.Escape)
            {
                neededKey = Console.ReadKey().Key;
            }
            Console.Clear();
        }
    }

}

