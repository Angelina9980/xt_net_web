using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_2_1_GAME
{
    class Apple:Bonus
    {
        internal string color;

        new int benefit = 5;
        public Apple(string color)
        {
            this.color = color;
        }
    }
}
