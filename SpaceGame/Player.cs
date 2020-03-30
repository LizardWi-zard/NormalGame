using System;
using System.Collections.Generic;
using System.Text;

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

        //public int EnemyDamage;

        public bool CanAddGamePoints = true;

        public int Health;

        public int GamePoints;

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

        public abstract void TakeScores();

        /*
        public void GetDamage(int countOfHits)
        {
            Health -= EnemyDamage * countOfHits;
        }
        */

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
            Console.WriteLine($"{Health}, {Damage}, {GamePoints}");
        }
    }
}
