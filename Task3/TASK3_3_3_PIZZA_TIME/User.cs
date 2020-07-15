using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TASK3_3_3_PIZZA_TIME
{
    public class User
    {
        public event ReadinessOfTheOrder IsMake;

        public string Name;
        public int UserId,
            userCash;

        public User(string name, int id, int money)
        {
            Name = name;
            UserId = id;
            userCash = money;
        }
        public bool UserOrder (PizzaMenu pizza, Pizzeria pizzeria)
        {
            bool IsPaid = false;

            if (UserId % 3 == 0)
            {
               Console.WriteLine($"The user [{UserId}, {Name}] gets a 20% discount!");
                pizzeria.PizzaCost -=(pizzeria.PizzaCost * 0.2);
            }
            if (userCash < pizzeria.PizzaCost)
            {
                Console.WriteLine($"Pay attention: the customer's [{UserId}, {Name}] order has not been paid!");
               IsPaid = false;
            }
            else
            {
                Console.WriteLine($"The user [{UserId}, {Name}] ordered a {pizza} pizza");
                IsPaid = true;
            }
            return IsPaid;
        }
       
        public void IssuingOrder(PizzaMenu pizza, Pizzeria pizzeria)
        {
            if (UserOrder(pizza, pizzeria))
            {
                Console.WriteLine($"The user [{UserId}, {Name}] took the {pizza} pizza");
            }
            else
            {
               Console.WriteLine($"The user [{UserId}, {Name}] didnt took the {pizza} pizza :(");
            }
        }

        
        
    }
}
