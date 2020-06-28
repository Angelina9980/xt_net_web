using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Task2_1_2_CUSTOM_PAINT
{
    class Line:PointPlane
    {
        protected double x2_coordinate, y2_coordinate,
            firstsidelength;
        public Line(double x1, double y1, double x2, double y2) :base(x1,y1)
        {
            x2_coordinate = x2;
            y2_coordinate = y2;
        }
        public double FirstLengthProperty { 
            get
            {
                return firstsidelength;  
            }
        }
        public virtual double GetLength()
        {
            return firstsidelength = Math.Sqrt(Math.Pow(x2_coordinate - x1_coordinate, 2) + Math.Pow(y2_coordinate - y1_coordinate, 2));
        }
        public override string GetInfo()
        {
            if (GetLength() == 0)
            {
                Console.WriteLine("The point has been created!");
                string paintInfo = "The figure: point!\n" + "Point coordinates are:(" + x1_coordinate + ", " + y1_coordinate + ")";
                return paintInfo;
            }
            else
            {
                Console.WriteLine("The line has been created!");
                Console.WriteLine("Line coordinates are : ({0},{1}), ({2},{3})", x1_coordinate,y1_coordinate, x2_coordinate, y2_coordinate);
                Console.WriteLine("The length = {0}", GetLength());
                string lineInfo = "The figure: line\n" + "Line coordinates are:(" + x1_coordinate + ", " + y1_coordinate + ")"+
                    "(" + x2_coordinate + "," + y2_coordinate+")" + "\nThe length = "+ GetLength();
                return lineInfo;
            }
        }
    }
}
