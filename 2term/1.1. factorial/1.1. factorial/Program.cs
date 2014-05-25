using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._1.factorial
{
    public class Program
    {
        /// <summary>
        /// Calculate factorial of introduced number.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static int Factorial(int number)
        {
            if (number < 0)
            {
                throw new Exception();
            }

            int factorial = 1;
            for (int i = 1; i <= number; ++i)
            {
                factorial *= i;
            }
            return factorial;  
        }
       
       /// <summary>
       /// So, that's it.
       /// </summary>
       /// <param name="args"></param>
        public static void Main(string[] args)
        {
            Console.WriteLine("Please, input a number:");
            int number = System.Int32.Parse(System.Console.ReadLine());
            number = Factorial(number);
            Console.WriteLine("Result: {0}", number);
        }
    }
}