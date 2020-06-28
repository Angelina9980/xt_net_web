using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Task2_1_2_CUSTOM_PAINT
{
    class Rectangle:Line
    {
        protected double perimeter, area, secondlength,
            x3_coordinate, y3_coordinate, x4_coordinate, y4_coordinate;
        public Rectangle(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4):base(x1,y1,x2,y2)
        {
            x3_coordinate = x3;
            y3_coordinate = y3;
            x4_coordinate = x4;
            y4_coordinate = y4;

        }
        public double Perimeter
        {
            get
            {
                return perimeter;
            }
        }
        public double Area
        {
            get
            {
                return area;
            }
        }

        private double SecondLength
        {
            get
            {
                return secondlength;
            }
        }
        private double GetSecondLength()
        {
            return secondlength = Math.Sqrt(Math.Pow(x3_coordinate - x1_coordinate, 2) + Math.Pow(y3_coordinate - y1_coordinate, 2));
        }

        public virtual double GetArea()
        {
            return area = GetLength() * GetSecondLength();
        }
        public virtual double GetPerimeter()
        {
            return perimeter = (GetLength() + GetSecondLength()) * 2;
        }

        public override string GetInfo()
        {
            if (firstsidelength == secondlength)
            {
                Console.WriteLine("The square has been created!");
                Console.WriteLine("Square coordinates are: ({0},{1}), ({2},{3}), ({4},{5}), ({6},{7})", x1_coordinate, y1_coordinate, x2_coordinate, y2_coordinate, x3_coordinate, y3_coordinate, x4_coordinate, y4_coordinate);
                Console.WriteLine("The perimeter = {0}", GetPerimeter());
                Console.WriteLine("The area = {0}", GetArea());
                string squareInfo = "The square has been created!\n" + "Square coordinates are: (" + x1_coordinate + ", " + y1_coordinate + ")" +
                    "(" + x2_coordinate + "," + y2_coordinate + ")" +
                    "(" + x3_coordinate + "," + y3_coordinate + ")" +
                    "(" + x4_coordinate + "," + y4_coordinate + ")\n" + "The perimeter = " + GetPerimeter() + "\nThe area = " + GetArea();
                return squareInfo;
            }
            else
            {
                Console.WriteLine("The rectangle has been created!");
                Console.WriteLine("Rectangle coordinates are : ({0},{1}), ({2},{3}), ({4},{5}), ({6},{7})", x1_coordinate, y1_coordinate, x2_coordinate, y2_coordinate, x3_coordinate, y3_coordinate, x4_coordinate, y4_coordinate);
                Console.WriteLine("The perimeter = {0}", GetPerimeter());
                Console.WriteLine("The area = {0}", GetArea());
                string rectangleInfo = "The rectangle has been created!\n" + "Rectangle coordinates are: (" + x1_coordinate + ", " + y1_coordinate + ")" +
                    "(" + x2_coordinate + "," + y2_coordinate + ")" +
                    "(" + x3_coordinate + "," + y3_coordinate + ")" +
                    "(" + x4_coordinate + "," + y4_coordinate + ")\n" + "The perimeter = " + GetPerimeter() + "\nThe area = " + GetArea(); ;
                return rectangleInfo;
            }
        }

    }
}
