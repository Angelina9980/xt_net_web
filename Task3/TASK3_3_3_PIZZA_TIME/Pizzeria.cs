using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TASK3_3_3_PIZZA_TIME
{
    public class Pizzeria
    {
        public event ReadinessOfTheOrder IsSsure;

        public string Name;
        public double PizzaCost;

        public Pizzeria(string name, double cost)
        {
            Name = name;
            PizzaCost = cost;
        }

        //2
        public bool CookingProcess(User customer, PizzaMenu pizza, Pizzeria pizzeria)
        {
            if (customer.UserOrder(pizza, pizzeria))
            {
                Console.WriteLine($"The {Name} started prepearing {pizza} pizza");
                return true;
            }
            else
            {
                Console.WriteLine($"The {Name} cant be cooks {pizza} .");
                return false;
            }
        }

        //3
        //очередь (по id) (выдача по тому, кто первый добавился)
        public void ReadinessOrder(User customer , PizzaMenu pizza, Pizzeria pizzeria)
        {
                Console.WriteLine($"The {pizza} is ready!");

                Console.WriteLine($"The {pizza} is not ready.");

        }
    }

    public enum PizzaMenu
    {
        Margaret,
        FourCheeses,
        FourSeasons,
        Carbonara,
        Seafood,
        Crudo,
        Vegan
    }
}
