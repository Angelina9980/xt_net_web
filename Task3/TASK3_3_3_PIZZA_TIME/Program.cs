using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TASK3_3_3_PIZZA_TIME
{
    public delegate void ReadinessOfTheOrder(PizzaMenu m);
    class Program
    {
        static void Main(string[] args)
        {
            
            User pizzaCustomer = new User("Ivan",1, 300);
            User pizzaCustomer2 = new User("Nikolya", 2, 1500);
            User pizzaCustomer3 = new User("Petya", 3, 470);

            Pizzeria pizzeria = new Pizzeria("SweetPizza", 300);
            Pizzeria pizzeria2 = new Pizzeria("HotPizza", 750);
            Pizzeria pizzeria3 = new Pizzeria("HomemadePizza", 400);

            PizzeriaWorkingProcess(pizzaCustomer, pizzeria, PizzaMenu.FourCheeses);
            PizzeriaWorkingProcess(pizzaCustomer2, pizzeria2, PizzaMenu.Vegan);
            PizzeriaWorkingProcess(pizzaCustomer3, pizzeria3, PizzaMenu.Seafood);

            bool isWorking = true;
            while (isWorking)
            {
                int personChoice;
                Console.WriteLine("Please enter the action:");
                Console.WriteLine("1 - Visit a pizzeria");
                Console.WriteLine("2 - Exit");
                Console.Write("Your choice is : ");
                personChoice = int.Parse(Console.ReadLine());
                switch (personChoice)
                {
                    case 1:
                        Console.WriteLine("Please choose which pizzeria to visit.");
                        Console.WriteLine("1 - {0}", pizzeria.Name);
                        Console.WriteLine("2 - {0}", pizzeria2.Name);
                        Console.WriteLine("3 - {0}", pizzeria3.Name);
                        Console.WriteLine();
                        Console.Write("Your choice is : ");
                        int pizzeriaChoice = int.Parse(Console.ReadLine());

                        switch(pizzeriaChoice)
                        {
                            case 1:
                            case 2:
                            case 3:
                            default:
                        }
                        break;
                    case 2:
                        isWorking = false;
                        Console.WriteLine("Good luck!");
                        Console.WriteLine("Press any key to exit");
                        break;
                }
            }

            Console.ReadKey();
        }

        static void PizzeriaWorkingProcess (User customer, Pizzeria pizzeria, PizzaMenu pizza)
        {
           
        }
    }
}
