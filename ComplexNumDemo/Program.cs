using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ComplexNumber;

namespace ComplexNumDemo
{
    class Program
    {        
        static void Main(string[] args)
        {
            Complex c1 = new Complex(2, 3);
            Complex c2 = new Complex(3, 3);
            Complex c3 = new Complex(2, 3);

            Console.WriteLine("Complex 1 = {0}", c1);
            Console.WriteLine("Complex 2 = {0}", c2);
            Console.WriteLine("Complex 3 = {0}", c3);
            Console.WriteLine();

            Console.WriteLine("{0} == {1} ==> {2}", c1, c2, c1 == c2);
            Console.WriteLine("{0} == {1} ==> {2}", c1, c3, c1 == c3);
            Console.WriteLine();

            Console.WriteLine("{0} + {1} ==> {2}", c1, c2, c1 + c2);
            Console.WriteLine("{0} - {1} ==> {2}", c2, c3, c2 - c3);
            Console.WriteLine("{0} * {1} ==> {2}", c1, c2, c1 * c2);
            Console.WriteLine("{0} / {1} ==> {2}", c2, c1, c2 / c1);
            Console.WriteLine();
        }
    }
}
