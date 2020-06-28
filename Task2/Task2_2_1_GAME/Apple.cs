using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_2_1_GAME
{
    class Apple:Bonus
    {
        protected string colour;

        protected int benefits = 5;
        public Apple(string colour)
        {
            this.colour = colour;
        }


    }
}
