using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._7.array_s_sort
{
    public class Program
    {
        /// <summary>
        /// Every child loves bubbles, I love Bubble Sort. So that's it.
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="size"></param>
        public static void BubbleSort(int[,] matrix) 
        {
            int size = matrix.GetLength(0);
            for (int i = 0; i < size; ++i)
            {
                for (int j = size - 1; j > i; --j)
                {
                    if (matrix[0, j] < matrix[0, j - 1])
                    {
                        for (int t = 0; t < size; ++t)
                        {
                            int temp = matrix[t, j];
                            matrix[t, j] = matrix[t, j - 1];
                            matrix[t, j - 1] = temp;
                        }
                    }
                }
            }  
        }

        /// <summary>
        /// One more trying to get a write result by printing of matrix.
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static string PrintOfTheMatrixInResult(int[,] matrix)
        {
            int size = matrix.GetLength(0);
            BubbleSort(matrix);
            string result = "";
            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size; ++j)
                {
                    result += matrix[i, j] + " ";
                }
            }
            return result;
        }

        /// <summary>
        /// Realization of previous pain.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            int size = 3;
            int[,] matrix = new int[size, size];
             
            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size; ++j)
                {
                    if (j == 0)
                    {
                        matrix[i, j] = 1;
                    }
                    if (j == 1)
                    {
                        matrix[i, j] = 5;
                    }
                    if (j == 2)
                    {
                        matrix[i, j] = 3;
                    }
                }
            }

            Console.Write("{0}", PrintOfTheMatrixInResult(matrix));
        }
    }
}

