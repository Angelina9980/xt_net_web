using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_1_2_CUSTOM_PAINT
{
    class Round:Circle
    {
        protected double area;
        public Round(double x1, double y1, double radius): base(x1,y1,radius)
        {

        }
        public double Area
        {
            get
            {
                return area;
            }
        }
        public virtual double GetArea()
        {
            return area = Math.PI * radius * radius;
        }
        public override string GetInfo()
        {
            if (radius == 0)
            {
                Console.WriteLine("The point has been created!");
                return "The figure: point\n" + "Point coordinates are:(" + x1_coordinate + ", " + y1_coordinate + ")";
            }
            else
            {
                Console.WriteLine("The round has been created!");
                Console.WriteLine("Round coordinates are: ({0},{1})", x1_coordinate, y1_coordinate);
                Console.WriteLine("Round radius is: {0}", radius);
                Console.WriteLine("Round length is {0}", GetLength());
                Console.WriteLine("Round area is {0}", GetArea());
                string roundInfo = "The figure: round\n" + "Round coordinates are: (" + x1_coordinate + ", " + y1_coordinate + ")\n" + 
                    "Round radius is " + radius + "\nRound length is" + GetLength() + "\nRound area is: " + GetArea();
                return roundInfo;
            }
        }

    }
}
