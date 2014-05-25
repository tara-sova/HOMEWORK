using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._6.matrix
{
    public class Program 
    {
        /// <summary>
        /// Move in a right-way.
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="step"></param>
        /// <param name="positionI"></param>
        /// <param name="positionJ"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        private static int MoveRight(int[,] matrix, int step, int positionI, int positionJ, ref string result)
        {
            int meaning = 0;
            ++positionJ;
            for (int j = positionJ; j < positionJ + step; ++j)
            {
                result += matrix[positionI, j].ToString() + " ";
                meaning = j;
            }
            return meaning;
        }

        /// <summary>
        /// Move in a down-way.
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="step"></param>
        /// <param name="positionI"></param>
        /// <param name="positionJ"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        private static int MoveDown(int[,] matrix, int step, int positionI, int positionJ, ref string result)
        {
            int meaning = 0;
            ++positionI;
            for (int i = positionI; i < positionI + step; ++i)
            {
                result += matrix[i, positionJ].ToString() + " ";
                meaning = i;
            }
            return meaning;
        }


        /// <summary>
        /// Move in a left-way.
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="step"></param>
        /// <param name="positionI"></param>
        /// <param name="positionJ"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        private static int MoveLeft(int[,] matrix, int step, int positionI, int positionJ, ref string result)
        {
            int meaning = 0;
            --positionJ;
            for (int j = positionJ; j > positionJ - step; --j)
            {
                result += matrix[positionI, j].ToString() + " ";
                meaning = j;
            }
            return meaning;
        }

        /// <summary>
        /// Move in a up-way.
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="step"></param>
        /// <param name="positionI"></param>
        /// <param name="positionJ"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        private static int MoveUp(int[,] matrix, int step, int positionI, int positionJ, ref string result)
        {
            int meaning = 0;
            --positionI;
            for (int i = positionI; i > positionI - step; --i)
            {
                result += matrix[i, positionJ].ToString() + " ";
                meaning = i;
            }
            return meaning;
        }

        /// <summary>
        /// Walk round of matrix, drink tea, talk about weather, do not check my job.
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static string GoRountOfMatrix(int[,] matrix)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                throw new Exception();
            }

            int size = matrix.GetLength(0);
            int centr = 5 / 2;
            int step = 1;
            int positionI = centr;
            int positionJ = centr;

            string result = "";

            result += matrix[positionI, positionJ].ToString() + " ";

            while (step <= size)
            {
                positionJ = MoveRight(matrix, step, positionI, positionJ, ref result);
                positionI = MoveDown(matrix, step, positionI, positionJ, ref result);
                ++step;

                positionJ = MoveLeft(matrix, step, positionI, positionJ, ref result);
                positionI = MoveUp(matrix, step, positionI, positionJ, ref result);

                if (step + 1 == size)
                {
                    positionJ = MoveRight(matrix, step, positionI, positionJ, ref result);
                    return result;
                }

                ++step;
            }
            return result;
        }

        /// <summary>
        /// Just print something that we have got from the previous method.
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="size"></param>
        private static void PrintOfTheMatrix(int[,] matrix, int size)
        {
            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size; ++j)
                {
                    Console.Write("{0} ", matrix[i,j]);
                }
                Console.Write("\n");
            }
        }

        /// <summary>
        /// Some kind of realization my previous suffering.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            int[,] matrix = new int[5, 5];
            int size = 5;
            int value = 0;
            for (int i = 0; i < 5; ++i)
            {
                for (int j = 0; j < 5; ++j)
                {
                    matrix[i, j] = value;
                    ++value;
                }
            }

            Console.WriteLine("Our array is: ");
            PrintOfTheMatrix(matrix, size);

            Console.WriteLine("\nPrint matrix in Helix-style: {0}", GoRountOfMatrix(matrix));
        }
    }
}
