using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_1_2_CUSTOM_PAINT
{
    class Triangle: Line
    {
        protected double x3_coordinate, y3_coordinate, perimeter, area,
            secondsidelength, thirdsidelength;
        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3): base(x1,y1,x2,y2)
        {
            x3_coordinate = x3;
            y3_coordinate = y3;
        }
        public double SecondLengthProperty
        {
            get
            {
                return secondsidelength;
            }
        }
        public double ThirdLengthProperty
        {
            get
            {
                return thirdsidelength;
            }
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
        public override double GetLength()
        {
            return firstsidelength = Math.Sqrt(Math.Pow(x2_coordinate - x1_coordinate, 2) + Math.Pow(y2_coordinate - y1_coordinate, 2));
        }

        public virtual double GetSecondLength()
        {
            return secondsidelength = Math.Sqrt(Math.Pow(x3_coordinate - x2_coordinate, 2) + Math.Pow(y3_coordinate - y2_coordinate, 2));
        }

        public virtual double GetThirdLength()
        {
            return thirdsidelength = Math.Sqrt(Math.Pow(x3_coordinate - x1_coordinate, 2) + Math.Pow(y3_coordinate - y1_coordinate, 2));
        }

        public virtual double GetPerimeter ()
        {
            perimeter = GetLength() + GetSecondLength() + GetThirdLength();
            return perimeter;
        }

        public virtual double GetArea ()
        {
            double halfperimeter = GetPerimeter() / 2;
            area = Math.Sqrt(halfperimeter * (halfperimeter - GetLength()) * (halfperimeter - GetSecondLength()) * (halfperimeter - GetThirdLength()));
            return area;
        }
        public override string GetInfo()
        {
            Console.WriteLine("The triangle has been created!");
            Console.WriteLine("Triangle coordinates are : ({0},{1}), ({2},{3}), ({4},{5})", x1_coordinate, y1_coordinate, x2_coordinate, y2_coordinate, x3_coordinate, y3_coordinate);
            Console.WriteLine("The perimeter = {0}", GetPerimeter());
            Console.WriteLine("The area = {0}", GetArea());
            string triangleInfo = "The figure: triangle\n" + "Triangle coordinates are:(" + x1_coordinate + ", " + y1_coordinate + ")" +
                    "(" + x2_coordinate + "," + y2_coordinate + ")" +
                    "(" + x3_coordinate + "," + y3_coordinate + ")" + "\nThe perimeter = " + GetPerimeter() + "\nThe area = " + GetArea();
            return triangleInfo;
        }
    }
}
