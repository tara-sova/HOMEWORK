using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._3.bubble
{
    public class Program
    {
        /// <summary>
        /// So, suddeenly, but it is sorting of array in bubble-style. 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="numberOfArrayElements"></param>
        public static void BubbleSort(int[] array)
        {
            int numberOfArrayElements = array.Length;
            for (int i = 0; i < numberOfArrayElements; ++i)
            {
                for (int j = 0; j < numberOfArrayElements - 1; ++j)
                {
                    if (array[j + 1] < array[j])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }

        /// <summary>
        /// Method that give result of array's sorting back to us.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="numberOfArrayElements"></param>
        /// <returns></returns>
        public static string PrintArrayInResult(int[] array)
        {
            int numberOfArrayElements = array.Length;
            BubbleSort(array);
            string result = "";
            for (int i = 0; i < numberOfArrayElements; ++i)
            {
                result += array[i] + " ";
            }
            return result;
        }

        /// <summary>
        /// Some realization of something.(I don't really understand why it's still here.)
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {

            int numberOfArrayElements = 5;
            int[] array = new int[numberOfArrayElements];
            array[0] = 7;
            array[1] = 8;
            array[2] = 3; 
            array[3] = 9;
            array[4] = 1;
            Console.Write("{0}", PrintArrayInResult(array));
        }
    }
}
