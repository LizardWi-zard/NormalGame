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

        public void CheckIfOutOfBounds()
        {
            if (GamePoints > 12)
            {
                GamePoints = 6;
                CanAddGamePoints = false;
            }
        }

        public void OutPutStats()
        {
            Console.WriteLine($"{Health}/{StartHealth}, {Damage}, {GamePoints}/12");
        }
        public void Attack(Player target)
        {
            target.Health -= Damage * (GamePoints - target.GamePoints);
        }
    }
}
