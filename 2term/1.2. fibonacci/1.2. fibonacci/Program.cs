using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._2.fibonacci
{
    public class Program
    {
        /// <summary>
        /// Calculate a value of member of Fibonacci sequence with number = n.
        /// </summary>
        public static long Fibonacci(int n)
        {
            if (n < 3)
            {
                return 1;
            }
            else
            {
                return Fibonacci(n - 1) + Fibonacci(n - 2);
            }
        }

        /// <summary>
        /// Realization of using previous method.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            int numberOfTheFibonaccisequence = 5;
            long result = Fibonacci(numberOfTheFibonaccisequence); 
            Console.Write("Result: {0} ", Fibonacci(numberOfTheFibonaccisequence));
        }
    }
}
