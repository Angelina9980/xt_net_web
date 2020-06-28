using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_1_2_CUSTOM_PAINT
{
    class Ring:Circle
    {
        protected double outerradius, outerlength, area, sumofcircles;
        public Ring(double x1, double y1, double radius) :base(x1,y1,radius)
        {

        }
        public double OuterRadius
        {
            get
            {
                return outerradius;
            }
            set
            {
                if (value >= 0)
                    radius = value;
                else
                {
                    Console.WriteLine("Incorrect value of outer radius");
                    Console.WriteLine("Default value: outer radius = 1");
                    outerradius = 1;
                }
            }
        }
        public double OutLength
        {
            get
            {
                return outerlength;
            }
        }
        public double Area
        {
            get
            {
                return area;
            }
        }

        public double Sum
        {
            get
            {
                return sumofcircles;
            }
        }

        public double GetRoundArea()
        {
            return area = Math.PI * (outerradius * outerradius - radius * radius);
        }

        public double GetOutLength()
        {
            return outerlength = 2 * Math.PI * outerradius;
        }

        public double GetSumOfLengths()
        {
            return sumofcircles = GetLength() + GetOutLength();
        }

        public override string GetInfo()
        {
            Console.WriteLine("The ring has been created!");
            Console.WriteLine("Ring coordinates are: ({0},{1})", x1_coordinate,y1_coordinate);
            Console.WriteLine("Ring inner radius is: {0}", radius);
            Console.WriteLine("Ring outer radius is: {0}", outerradius);
            Console.WriteLine("Ring inner length is {0}", GetLength());
            Console.WriteLine("Ring outer length is {0}", GetOutLength());
            Console.WriteLine("The sum of the lengths of the outer and inner circles is {0}", GetSumOfLengths());
            string ringInfo = "The figure: ring\n" + "Ring coordinates are:(" + x1_coordinate + ", " + y1_coordinate + ")\n"
                + "\nRing inner radius is:" + radius + "\nRing outer radius is:" + outerradius + "\nRing inner length is " + GetLength() 
                + "\nRing outer length is" + GetOutLength() + "\nThe sum of the lengths of the outer and inner circles is" + GetSumOfLengths();
            return ringInfo;
        }
    }
}
