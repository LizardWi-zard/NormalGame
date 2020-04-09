using System;

namespace SpaceGame
{
    public abstract class Player
    {
        protected int MinHealth;
        protected int MaxHealth;
        protected int MinDamage;
        protected int MaxDamage;
        public int Damage
        {
            get;
            protected set;
        }

        public bool CanAddGamePoints = true;

        public int Health;
        public int StartHealth;

        public int GamePoints;

        public void ResetGamePoints()
        {
            GamePoints = 0;
        }
        public void Initialization()
        {
            Random random = new Random();
            Health = random.Next(MinHealth, MaxHealth);
            StartHealth = Health;
            Damage = random.Next(MinDamage, MaxDamage);
        }

        public abstract void TakeScores();

        public void CheckPointsRange()
        {
            if (GamePoints > 12)
            {
                GamePoints = 6;
                CanAddGamePoints = false;
            }
        }

        public void OutPutStats()
        {
            Console.Write($"Health: ");
            ColorHealth();
            Console.WriteLine($"/{StartHealth}");
            Console.WriteLine($"Damage: {Damage}");
            Console.Write($"GamePoints: ");
            ColorGamePoints();
            Console.WriteLine($"/12");
            Console.WriteLine(" ");
        }
        public void Attack(Player target)
        {
            target.Health -= Damage * (GamePoints - target.GamePoints);
        }
        public void ColorHealth() //TODO упростить выражение | изменить название
        {
            Console.ForegroundColor = Health > StartHealth * 0.66 ? ConsoleColor.Green : (Health < StartHealth * 0.33) ? ConsoleColor.Red : ConsoleColor.Yellow; ;
            Console.Write($"{Health}");
            Console.ResetColor();
        }
        public void ColorGamePoints() //TODO упростить выражение 
        {
            Console.ForegroundColor = GamePoints >= 9 ? ConsoleColor.Green : (GamePoints < 5) ? ConsoleColor.Red : ConsoleColor.Yellow; ;
            Console.Write($"{GamePoints}");
            Console.ResetColor();
        }
    }
}

