using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Square : Rectangle
    {
        public double A {  get; set; }
        public override double Area()
        {
            return A * A;
        }
        public override double Circ()
        {
            return A + A + A + A;
        }
        public static double GetAreaBySide(double side)
        {
            Square s = new()
            {
                A = side
            };
            s.A = side;
            return s.Area();
        }
    }
}
