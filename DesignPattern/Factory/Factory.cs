using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Factory
{
    // motivation that I want to Inatliza Object with different cases but the same type of paramters and I want to remane the construtor 
    // 2nd motivation that seperartion of concern the intailization of the Point is seperate from the class itself 
    public class Point
    { 
        private double x, y;
        private Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public override string ToString()
        {
            return $"{nameof(x)}: {x.ToString()}, {nameof(y)}: {y.ToString()}";
        }
        public class FactoryPoint
        {
            public static Point CatersianPoint(double x, double y)
            {
                return new Point(x, y);
            }
            public static Point PolarPoint(double rho, double theta)
            {
                return new Point(rho, theta);
            }
        }
    }
}

