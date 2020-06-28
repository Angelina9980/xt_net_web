using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Task2_1_2_CUSTOM_PAINT
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter your name :");
            string name = Console.ReadLine();
            User user = new User(name);

            List<User> listOfUsers = new List<User>();
            listOfUsers.Add(user);

            bool isWorking = true;
            while (isWorking)
            {
                Console.WriteLine("Choose your action:");
                Console.WriteLine("1 - Add a figure");
                Console.WriteLine("2 - Print figures");
                Console.WriteLine("3 - Clear canvas");
                Console.WriteLine("4 - Exit");
                Console.WriteLine("5 - Change user");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("1 - Point");
                        Console.WriteLine("2 - Line");
                        Console.WriteLine("3 - Triangle");
                        Console.WriteLine("4 - Rectangle");
                        Console.WriteLine("5 - Circle");
                        Console.WriteLine("6 - Ring");
                        Console.WriteLine("7 - Round");
                        int figureChoice = int.Parse(Console.ReadLine());
                        switch (figureChoice)
                        {
                            case 1:
                                Console.Write("Please enter the coordinates of point, {0}: \nx: ", listOfUsers[listOfUsers.Count - 1].Name);
                                double xPoint = double.Parse(Console.ReadLine());
                                Console.Write("y: ");
                                double yPoint = double.Parse(Console.ReadLine());
                                PointPlane point = new PointPlane(xPoint, yPoint);      
                                user.AddFigure(point);
                                break;
                            case 2:
                                Console.Write("Please enter the coordinates of line, {0}: \nx1: ", listOfUsers[listOfUsers.Count - 1].Name);
                                double x1Line = double.Parse(Console.ReadLine());
                                Console.Write("y1: ");
                                double y1Line = double.Parse(Console.ReadLine());
                                Console.Write("Please enter the coordinates of line, {0}: \nx2: ", listOfUsers[listOfUsers.Count - 1].Name);
                                double x2Line = double.Parse(Console.ReadLine());
                                Console.Write("y2: ");
                                double y2Line = double.Parse(Console.ReadLine());
                                Line line = new Line(x1Line, y1Line, x2Line, y2Line);
                                user.AddFigure(line);
                                break;
                            case 3:
                                Console.Write("Please enter the coordinates of triangle, {0}: \nx1: ", listOfUsers[listOfUsers.Count - 1].Name);
                                double x1Triangle = double.Parse(Console.ReadLine());
                                Console.Write("y1: ");
                                double y1Triangle = double.Parse(Console.ReadLine());
                                Console.Write("Please enter the coordinates of triangle, {0}: \nx2: ", listOfUsers[listOfUsers.Count - 1].Name);
                                double x2Triangle = double.Parse(Console.ReadLine());
                                Console.Write("y2: ");
                                double y2Triangle = double.Parse(Console.ReadLine());
                                Console.Write("Please enter the coordinates of triangle: \nx3, {0}: ", listOfUsers[listOfUsers.Count - 1].Name);
                                double x3Triangle = double.Parse(Console.ReadLine());
                                Console.Write("y3: ");
                                double y3Triangle = double.Parse(Console.ReadLine());
                                Triangle triangle = new Triangle(x1Triangle, y1Triangle, x2Triangle, y2Triangle, x3Triangle, y3Triangle);
                                user.AddFigure(triangle);
                                break;
                            case 4:
                                Console.Write("Please enter the coordinates of rectangle, {0}: \nx1: ", listOfUsers[listOfUsers.Count - 1].Name);
                                double x1Reactangle = double.Parse(Console.ReadLine());
                                Console.Write("y1: ");
                                double y1Rectangle = double.Parse(Console.ReadLine());
                                Console.Write("Please enter the coordinates of rectangle, {0}: \nx2: ", listOfUsers[listOfUsers.Count - 1].Name);
                                double x2Rectangle = double.Parse(Console.ReadLine());
                                Console.Write("y2: ");
                                double y2Rectangle = double.Parse(Console.ReadLine());
                                Console.Write("Please enter the coordinates of rectangle, {0}: \nx3: ", listOfUsers[listOfUsers.Count - 1].Name);
                                double x3Rectangle = double.Parse(Console.ReadLine());
                                Console.Write("y3: ");
                                double y3Rectangle = double.Parse(Console.ReadLine());
                                Console.Write("Please enter the coordinates of rectangle, {0}: \nx4: ", listOfUsers[listOfUsers.Count - 1].Name);
                                double x4Rectangle = double.Parse(Console.ReadLine());
                                Console.Write("y4: ");
                                double y4Rectangle = double.Parse(Console.ReadLine());
                                Rectangle rectangle = new Rectangle(x1Reactangle, y1Rectangle, x2Rectangle, y2Rectangle,
                                    x3Rectangle, y3Rectangle, x4Rectangle, y4Rectangle);
                                user.AddFigure(rectangle);
                                break;
                            case 5:
                                Console.Write("Please enter the coordinates of circle, {0}: \nx1: ", listOfUsers[listOfUsers.Count - 1].Name);
                                double x1Circle = double.Parse(Console.ReadLine());
                                Console.Write("y1: ");
                                double y1Circle = double.Parse(Console.ReadLine());
                                Console.Write("Please enter the radius, {0}: ", listOfUsers[listOfUsers.Count - 1].Name);
                                double radiusCircle = double.Parse(Console.ReadLine());
                                Circle circle = new Circle(x1Circle, y1Circle, radiusCircle);
                                user.AddFigure(circle);
                                break;
                            case 6:
                                Console.Write("Please enter the coordinates of ring, {0}: \nx1: ", listOfUsers[listOfUsers.Count - 1].Name);
                                double x1Ring = double.Parse(Console.ReadLine());
                                Console.Write("y1: ");
                                double y1Ring = double.Parse(Console.ReadLine());
                                Console.Write("Please enter the radius, {0}: ", listOfUsers[listOfUsers.Count - 1].Name);
                                double radiusRing = double.Parse(Console.ReadLine());
                                Ring ring = new Ring(x1Ring, y1Ring, radiusRing);
                                user.AddFigure(ring);
                                break;
                            case 7:
                                Console.Write("Please enter the coordinates of round, {0}: \nx1: ", listOfUsers[listOfUsers.Count - 1].Name);
                                double x1Round = double.Parse(Console.ReadLine());
                                Console.Write("y1: ");
                                double y1Round = double.Parse(Console.ReadLine());
                                Console.Write("Please enter the radius, {0}: ", listOfUsers[listOfUsers.Count - 1].Name);
                                double radiusRound = double.Parse(Console.ReadLine());
                                Round round = new Round(x1Round, y1Round, radiusRound);
                                user.AddFigure(round);
                                break;
                        }
                        break;
                    case 2:
                        foreach(string info in user.ListOfFigures)
                        {
                            Console.WriteLine(info);
                        } 
                        break;
                    case 3:
                        user.ClearCanvas();
                        Console.WriteLine("Canvas has been cleared!");
                        break;
                    case 4:
                        isWorking = false;
                        Console.WriteLine("Goodbye, {0}!", user.Name);
                        Console.WriteLine("Please press any key to exit");
                        break;
                    case 5:
                        Console.WriteLine("Please enter your name: ");
                        string anothername = Console.ReadLine();
                        User anotherUser = new User(anothername);
                        listOfUsers.Add(anotherUser);
                        break;
                }
            }
            Console.ReadKey();
        }
    }
}
