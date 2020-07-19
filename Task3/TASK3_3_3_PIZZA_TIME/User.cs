using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TASK3_3_3_PIZZA_TIME
{
    public class User
    {
        public string Name { get; }
        public int UserId { get; }
        public double userCash { get; private set; }
        public double orderValue { get; private set; }

        public User(string name, int id, double money)
        {
            Name = name;
            UserId = id;
            userCash = money;
            Pizzeria.IsSsure += IssuingOrder;
        }

        public void UserOrder(Pizza pizza)
        {
            orderValue = pizza.Cost;
            if (userCash < pizza.Cost)
                Console.WriteLine($"Sorry, but the customer's [{UserId}, {Name}] order has not been paid!");
            else
            {
                //Pizzeria gives a discount to every third customer
                if (UserId % 3 == 0)
                {
                    Console.WriteLine($"The user [{UserId}, {Name}] gets a 20% discount!");
                    orderValue = pizza.Cost - (pizza.Cost * 0.2);
                }
                Console.WriteLine($"The user [{UserId}, {Name}] ordered a {pizza.Name} pizza at the price of {orderValue}");
                Pizzeria.CookingProcess(this.Name, pizza);
                userCash -= orderValue;
            }
        }

        public void IssuingOrder(string name)
        {
            if (name == this.Name)
            Console.WriteLine($"The user {name} took the pizza");
        }

    }
}
