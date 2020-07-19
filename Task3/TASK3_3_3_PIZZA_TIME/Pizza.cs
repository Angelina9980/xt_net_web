using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TASK3_3_3_PIZZA_TIME
{
    public class Pizza
    {
        public string Name { get; set; }
        public double Cost { get; set;}
    }

    public class Margaret: Pizza
    {
        public Margaret (double cost)
        {
            Cost = cost;
            Name = "Margaret";
        }
    }

    public class FourCheeses : Pizza
    {
        public FourCheeses(double cost)
        {
            Cost = cost;
            Name = "FourCheeses";
        }
    }

    public class FourSeasons : Pizza
    {
        public FourSeasons(double cost)
        {
            Cost = cost;
            Name = "FourSeasons";
        }
    }

    public class Carbonara : Pizza
    {
        public Carbonara(double cost)
        {
            Cost = cost;
            Name = "Carbonara";
        }
    }

    public class Vegan : Pizza
    {
        public Vegan(double cost)
        {
            Cost = cost;
            Name = "Vegan";
        }
    }

}
