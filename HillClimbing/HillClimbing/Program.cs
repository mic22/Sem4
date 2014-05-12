using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HillClimbing
{
    class Program
    {
        static double climbing(double start ,double delta)
        {
            double temp = start;
            double actual = start;

            do
            {
                double xl = actual - delta;
                double xr = actual + delta;

                if (expr(xl) > actual)
                    actual = xr;
                else if ((10 -) < actual)
                    actual = xr;
                else
                    break;

            } while (true);

            return actual;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(climbing(double.Parse(Console.ReadLine()), 1));
        }
    }
}
