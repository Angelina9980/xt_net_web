using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_1_2_CUSTOM_PAINT
{
    class PointPlane
    {
        protected double x1_coordinate, y1_coordinate; 

        public PointPlane(double x1, double y1)
        {
            x1_coordinate = x1;
            y1_coordinate = y1;
        }
        public virtual string GetInfo()
        {
            string info = "The figure: point\n" + "Point coordinates are:("+x1_coordinate+", "+y1_coordinate+")";
            Console.WriteLine("The point has been created!");
            Console.WriteLine("Point coordinates are: ({0}, {1})", x1_coordinate, y1_coordinate);
            return info;
        }
    }
}
