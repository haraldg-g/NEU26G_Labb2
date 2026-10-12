using System;
using System.Collections.Generic;
using System.Text;

namespace Labb2
{    
    class Dice
    {
        private int numberOfDice;
        private int sidesPerDice;
        private int modifier;
        public Dice(int numberOfDice, int sidesPerDie, int modifier)
        {
            this.numberOfDice = numberOfDice;
            this.sidesPerDice = sidesPerDie;
            this.modifier = modifier;
        }
        public int Throw()
        {
            Random random = new Random();
            int total = 0;
            for (int i = 0; i < numberOfDice; i++)
            {
                total += random.Next(1, sidesPerDice + 1);
            }
            return total + modifier;
        }

        public override string ToString()
        {
            return $"{numberOfDice}d{sidesPerDice}+{modifier}";
        }
    }
}
