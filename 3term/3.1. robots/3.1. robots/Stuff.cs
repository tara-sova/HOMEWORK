using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._1.robots
{
    /// <summary>
    /// Class which provide interaction of system with input data.
    /// </summary>
    public class StuffClass
    {
        private StreamReader reader;
        private int[,] stuffMatrix;
        int[] robots;
        private int size = 4;

        public StuffClass(string nameOfFile)
        {
            reader = new StreamReader(nameOfFile);
            this.Start();
        }

        public void Start()
        {
            string strSize = reader.ReadLine();
            size = Convert.ToInt32(strSize);

            stuffMatrix = new int[size, size];
            for (int i = 0; i < size; ++i)
            {
                string str = reader.ReadLine();
                for (int j = 0; j < size; ++j)
                {
                    stuffMatrix[i, j] = (int)Char.GetNumericValue(str[j]);
                }
            }
            
            robots = new int[size];
            for (int i = 0; i < size; ++i)
            {
                robots[i] = 0;
            }

            string comp = reader.ReadLine();
            while (comp != "" && comp != null)
            {
                int position = Convert.ToInt32(comp);
                robots[position] = 1;
                comp = reader.ReadLine();
            }

        }

        /// <summary>
        /// Get matrix of robots's connections.
        /// </summary>
        /// <returns></returns>
        public int[,] GetMatrix()
        {
            return stuffMatrix;
        }

        /// <summary>
        /// Get array with robots's positions.
        /// </summary>
        /// <returns></returns>
        public int[] GetArrayWhithRobots()
        {
            return robots;
        }

    }
}
