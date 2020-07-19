using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TASK3_3_3_PIZZA_TIME
{
    class Program
    {
        static void Main(string[] args)
        {
                 
            User pizzaCustomer = new User("Ivan", 1, 250);
            User pizzaCustomer2 = new User("Nikolya", 2, 1500);
            User pizzaCustomer3 = new User("Petya", 3, 470);

            pizzaCustomer.UserOrder(new FourCheeses(300));
            Console.WriteLine();
            pizzaCustomer2.UserOrder(new Vegan(500));
            Console.WriteLine();
            pizzaCustomer3.UserOrder(new Carbonara(300));
            Console.WriteLine();

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
