using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace borrame
{
    internal class Program
    {
        static int sum1(int a, int b) => a + b;
        static double sum1(int op1, double op2, int op3) => op1 + op2 + op3;

        static void Main(string[] args)
        {
            Console.WriteLine($"Las sumas son: {sum1(2,9)} - {sum1(12, -11,9)}");
            Console.ReadLine();
        }
    }
}
