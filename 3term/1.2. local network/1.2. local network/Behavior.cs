using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._2.local_network
{
    /// <summary>
    /// Class that regiment behavior of system in infection process.
    /// </summary>
    public class Behavior
    {
        private Computer[] computers;

        /// <summary>
        /// Change a system condition because of thread of infection.
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="computersFromStuff"></param>
        /// <param name="extraIndex"></param>
        public Behavior(int[,] matrix, Computer[] computersFromStuff, int extraIndex)
        {
            computers = computersFromStuff;
            this.LetInfect(matrix, extraIndex);
        }

        /// <summary>
        /// Fill bool array that demonstrate computers which is infect.
        /// </summary>
        /// <param name="infectedComputers"></param>
        /// <returns></returns>
        public bool[] FillingOfArray(bool[] infectedComputers)
        {
            for (int i = 0; i < infectedComputers.GetLength(0); ++i)
            {
                if (computers[i].GetHealthCondition())
                    infectedComputers[i] = true;
                else
                    infectedComputers[i] = false;
            }
            return infectedComputers;
        }

        /// <summary>
        /// Auxiliary process of infection.
        /// </summary>
        /// <param name="infectedComputers"></param>
        /// <param name="matrix"></param>
        /// <param name="extraIndex"></param>
        void InternalInfection(bool[] infectedComputers, int[,] matrix, int extraIndex)
        {
            infectedComputers = this.FillingOfArray(infectedComputers);

            for (int i = 0; i < infectedComputers.GetLength(0); ++i)
            {
                if (infectedComputers[i])
                {
                    for (int j = 0; j < infectedComputers.GetLength(0); ++j)
                    {
                        if ((matrix[i, j] == 1) && ( !((computers[j].GetHealthCondition()) && (computers[i].GetHealthCondition())) ))
                        {
                            computers[j].TryToInfect(extraIndex);
                        }
                    }
                }
            }
            infectedComputers = this.FillingOfArray(infectedComputers);
         }

        /// <summary>
        /// Method for infection.
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="extraIndex"></param>
        public void LetInfect(int[,] matrix, int extraIndex)
        {
            bool[] infectedComputers = new bool[matrix.GetLength(0)];

            for (int i = 0; i < 5; ++i)
            {
                InternalInfection(infectedComputers, matrix, extraIndex);
            }
        }

        /// <summary>
        /// Get health condition of intrested computer.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool GetComputerHealthCondition(int name)
        {
            return computers[name].GetHealthCondition();
        }
    }
}
