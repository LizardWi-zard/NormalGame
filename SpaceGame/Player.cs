using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceGame
{
    public class Player
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

        public bool CanAddGamePoints;

        public int Health;

        public int GamePoints;

        public void AddPersonalPoints()
        {
            GamePoints += new Random().Next(1, 7);
        }

        public void ResetGamePoints()
        {
            GamePoints = 0;
        }

        public void Initialization()
        {
            Random random = new Random();
            Health = random.Next(MinHealth, MaxHealth);
            Damage = random.Next(MinDamage, MaxDamage);
        }

        public void GetDamage(int countOfHits)
        {
            Health -= Damage * countOfHits;
        }
        public void CheckIfOutOfBounds()
        {
            if (GamePoints > 12)
                GamePoints = 6;
        }
        public void OutPutStats()
        {
            Console.WriteLine($"{Health}, {Damage}, {GamePoints}");
        }
    }
}
