using System;
using System.Collections.Generic;
using System.Linq;

namespace SpaceGame
{
    class Menu
    {
        private int CoursorPosition;
        private ConsoleKey PressedKey;
        private Dictionary<string, Action> MenuItems = new Dictionary<string, Action>();

        public void AddMenuItem(string name, Action action)
        {
            MenuItems.Add(name, action);
        }

        public void Show()
        {
            while (PressedKey != ConsoleKey.Escape)
            {
                PrintMenu();
                PressedKey = Console.ReadKey().Key;

                switch (PressedKey)
                {
                    case ConsoleKey.UpArrow:
                        if (CoursorPosition > 0)
                            CoursorPosition--;
                        break;

                    case ConsoleKey.DownArrow:
                        if (CoursorPosition < MenuItems.Count - 1)
                            CoursorPosition++;
                        break;

                    case ConsoleKey.Enter:
                        MenuItems.ElementAt(CoursorPosition).Value();
                        break;

                    case ConsoleKey.Escape:
                        Console.Clear();
                        break;
                }
            }
        }

        void PrintMenu()
        {
            Console.Clear();
            System.Threading.Thread.Sleep(10);
            string prefix;

            for (int i = 0; i < MenuItems.Count; i++)
            {
                prefix = (i == CoursorPosition) ? ">" : " ";
                Console.WriteLine(prefix + MenuItems.ElementAt(i).Key);
            }
        }
    }
}

