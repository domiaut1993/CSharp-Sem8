using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Triangle<T> where T : INumber<T>
    {

        public T A {  get; set; }
        public T B { get; set; }
        public T C { get; set; }

        public Triangle (T A, T B, T C)
        {
            this.A = A;
            this.B = B;
            this.C = C;
        }

        public static bool GetInstance(T a, T b, T c, out Triangle <T> triangle)
        {
            triangle = null;
            // add is a valid triangle
            // add if input is number
            if (!IsValid(a, b, c))
            {
                
                return false;
            }
            triangle = new Triangle<T>(a, b, c);
            return triangle != null;
        }

        private static bool IsValid(T a, T b, T c)
        {
            return ((a + b) > c) && ((b + c)>a) && ((a + c)>b);
        }
    }
}
