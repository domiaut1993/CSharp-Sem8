using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Rectangle : Shape, IEllipsable
    {
        private double A { get; set; }
        private double B { get; set; }

        public bool IsElipse()
        {
            System.Console.WriteLine("NO!");
            return false;
        }

        public override double Area()
        {
            return A*B;
        }

        public override double Circ()
        {
            return A + B + A + B;
        }
    }
}
