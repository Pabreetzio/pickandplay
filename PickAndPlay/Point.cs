using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PickAndPlay
{
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public Point()
        {
        }
        public Point(double z)
        {
            Z = z;
        }
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
        public Point(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}
