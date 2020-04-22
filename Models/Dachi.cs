using System;

namespace DojoDachi.Models
{
    public class Dachi
    {
        public int Fullness;
        public int Happiness;
        public int Energy;
        public int Meals;
        public Dachi()
        {
            Fullness = 20;
            Happiness = 20;
            Energy = 50;
            Meals = 3;
        }
        public bool Winner()
        {
            if (Fullness > 99 && Happiness > 99 && Energy > 99)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Loser()
        {
            if (Fullness < 1 || Happiness < 1 || Energy < 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}