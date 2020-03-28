using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceGame
{
    public class HumanPlayer : Player
    {
        public HumanPlayer()
        {
            MinHealth = 80;
            MaxHealth = 101;
            MinDamage = 5;
            MaxDamage = 16;

            Initialization();
        }
    }
}
