using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._1.robots
{
    /// <summary>
    /// Class which demostrate connections between robots.
    /// </summary>
    public class Graph
    {
        private int[] arrayOfVertices;
        private int counter = 0;
        private bool checkOfKilling = false;
        /// <summary>
        /// Action of teleportation.
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="robots"></param>
        public Graph(int[,] matrix, int[] robots)
        {
            Division(matrix);
            CheckOfKilling(robots);
        }

        /// <summary>
        /// Divide matrix on two components.
        /// </summary>
        /// <param name="matrix"></param>
        public void Division(int[,] matrix)
        {
            arrayOfVertices = new int[matrix.GetLength(0)];
            FillArrayOfVertices(matrix);

            int i = 0;
            while (matrix[i, 0] != 1)
            {
                ++i;
            }
            arrayOfVertices[i] = 1;

            Recursion(matrix, i);
        }

        /// <summary>
        /// Fill array of vertices for future using.
        /// </summary>
        /// <param name="matrix"></param>
        public void FillArrayOfVertices(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); ++i)
                arrayOfVertices[i] = -1;
        }

        /// <summary>
        /// Fill array of vertices correctly.
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="i"></param>
        public void Recursion(int[,] matrix, int i)
        {
            for (int j = 0; j < matrix.GetLength(0); ++j)
            {
                if (matrix[i, j] == 1)
                {
                    for (int t = 0; t < matrix.GetLength(0); ++t)
                    {
                        if ((matrix[j, t] == 1) && (arrayOfVertices[t] == -1))
                        {
                            arrayOfVertices[t] = 1;
                            Recursion(matrix, t);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Check of robot's killing.
        /// </summary>
        /// <param name="robots"></param>
        public void CheckOfKilling(int[] robots)
        {
            int[] arrayWithRobots = new int[arrayOfVertices.GetLength(0)];
            for (int i = 0; i < arrayWithRobots.GetLength(0); ++i)
            {
                arrayWithRobots[i] = arrayOfVertices[i];
            }

            for (int i = 0; i < robots.GetLength(0); ++i)
            {
                if (robots[i] == 1)
                    arrayWithRobots[i] = 0;
            }

            int minusOneInVertices = CountElement(-1, arrayOfVertices);
            int oneInVertices = CountElement(1, arrayOfVertices);

            int minusOneInArray = CountElement(-1, arrayWithRobots);
            int oneInArray = CountElement(1, arrayWithRobots);

            if (((minusOneInVertices - minusOneInArray) == 1) || ((oneInVertices - oneInArray) == 1))
            {
                checkOfKilling = false;
                return;
            }

            if ((minusOneInVertices == 1) || (oneInVertices == 1))
            {
                checkOfKilling = false;
                return;
            }

            checkOfKilling = true;
        }

        /// <summary>
        /// Count of array's elements.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="array"></param>
        /// <returns></returns>
        public int CountElement(int element, int[] array)
        {
            int number = 0;
            for (int i = 0; i < array.GetLength(0); ++i)
            {
                if (array[i] == element)
                    ++number;
            }
            return number;
        }
        /// <summary>
        /// Get result of robots's movements.
        /// </summary>
        /// <returns></returns>
        public bool GetCheckOfKilling()
        {
            return checkOfKilling;
        }

    }
}
