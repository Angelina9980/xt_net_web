using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TASK3_3_3_PIZZA_TIME
{
    public static class Pizzeria
    {
        public delegate void ReadinessOfTheOrderDelegate(string name);
        public static event ReadinessOfTheOrderDelegate IsSsure;

        public static void CookingProcess(string name, Pizza pizza)
        {
            Console.WriteLine($"The {pizza.Name} started cooking...");
            ReadinessOrder(name, pizza);
        }

        public static void ReadinessOrder(string name, Pizza pizza)
        {
            Console.WriteLine($"Dear {name}, the {pizza.Name} pizza is ready!");
            IsSsure?.Invoke(name);
        }
    }

}
