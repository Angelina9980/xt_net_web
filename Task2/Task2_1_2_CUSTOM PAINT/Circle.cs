using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_1_2_CUSTOM_PAINT
{
    class Circle:PointPlane
    {
        protected double radius, length;
        public Circle(double x1, double y1, double radius): base(x1, y1)
        {
            this.radius = radius;
        }

        public double Length
        {
            get
            {
                return length;
            }
        }
        public double Radius
        {
            get
            {
                return radius;
            }
            set
            {
                if (value >= 0)
                    radius = value;
                else
                {
                    Console.WriteLine("Incorrect value of radius");
                    Console.WriteLine("Default value: radius = 1");
                    radius = 1;
                }
            }
        }

        public virtual double GetLength()
        {
            return length = 2 * Math.PI * radius;
        }

        public override string GetInfo()
        {
            if (radius == 0)
            {
                Console.WriteLine("The point has been created!");
                string pointInfo = "The figure: point\n" + "Point coordinates are:(" + x1_coordinate + ", " + y1_coordinate + ")";
                return pointInfo;
            }
            else
            {
                Console.WriteLine("The circle has been created!");
                Console.WriteLine("Сicle coordinates are: ({0},{1})", x1_coordinate, y1_coordinate);
                Console.WriteLine("Circle radius is: {0}", radius);
                Console.WriteLine("Circle length is {0}", GetLength());
                string circleInfo = "The figure: circle\n" + "Сircle coordinates are: (" + x1_coordinate + ", " + y1_coordinate + ")" 
                    + "\nCircle radius is: " + radius + "\nCircle length is " + GetLength();
                return circleInfo;
            }
        }

    }
}
