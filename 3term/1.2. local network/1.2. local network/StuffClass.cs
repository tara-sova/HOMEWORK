using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._2.local_network
{
    /// <summary>
    /// Class which provide interaction of system with input data.
    /// </summary>
    public class StuffClass
    {
        private StreamReader reader = new StreamReader("info.txt");
        private Computer[] computers;
        private int[,] stuffMatrix;
        private int size = 4;

        /// <summary>
        /// Start work.
        /// </summary>
        public StuffClass()
        {
            this.Start();
        }

        /// <summary>
        /// Start of infection process.
        /// </summary>
        public void Start()
        {
            string counter = reader.ReadLine();
            size = Convert.ToInt32(counter);

            computers = new Computer[size];

            bool isInfected = false;
            string name = "";
            string systemType = "";

            for (int i = 0; i < size; ++i)
            {
                computers[i] = new Computer();
                string sign = reader.ReadLine();
                if (sign == "+")
                {
                    isInfected = true;
                }
                else if (sign == "-") 
                {
                    isInfected = false;
                }
                name = reader.ReadLine();
                systemType = reader.ReadLine();

                computers[i].SetHealthCondition(isInfected); ;
                computers[i].SetOSType(computers[i].InfectionIndex(systemType));
                computers[i].SetName(name);
            }

            stuffMatrix = new int[size, size];
            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size; ++j)
                {
                    stuffMatrix[i, j] = 0;
                }
            }

            for (int i = 0; i < size; ++i)
            {
                string str = reader.ReadLine();
                for (int j = 0; j < size; ++j)
                {
                    stuffMatrix[i, j] = (int)Char.GetNumericValue(str[j]);
                }
            }

        }

        /// <summary>
        /// Get computers's array.
        /// </summary>
        /// <returns></returns>
        public Computer[] GetArrayOfComputers()
        {
            return computers;
        }

        /// <summary>
        /// Get matrix of system interaction.
        /// </summary>
        /// <returns></returns>
        public int[,] GetMatrix()
        {
            return stuffMatrix;
        }
    }
}
