using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Circle : Shape, IEllipsable
    {
        public double R {  get; set; }
        public const double PI = Math.PI;
        public bool IsElipse()
        { 
            return true; 
        }
        public override double Area()
        {
            return PI * R * R;
        }

        public override double Circ()
        {
            return PI*2*R; 
        }
    }
}
