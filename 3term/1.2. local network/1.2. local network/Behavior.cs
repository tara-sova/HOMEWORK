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
        bool[] infectedComputers;

        /// <summary>
        /// Change a system condition because of thread of infection.
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="computersFromStuff"></param>
        /// <param name="extraIndex"></param>
        public Behavior(int[,] matrix, Computer[] computersFromStuff)
        {
            computers = computersFromStuff;
            infectedComputers = new bool[matrix.GetLength(0)];
            FillingOfArray(infectedComputers);
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
                infectedComputers[i] = computers[i].GetHealthCondition();
            }
            return infectedComputers;
        }

        /// <summary>
        /// Auxiliary process of infection.
        /// </summary>
        /// <param name="infectedComputers"></param>
        /// <param name="matrix"></param>
        /// <param name="extraIndex"></param>
        public void InternalInfection(bool[] infectedComputers, int[,] matrix, int extraIndex)
        {
            infectedComputers = this.FillingOfArray(infectedComputers);

            for (int i = 0; i < infectedComputers.Length; ++i)
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
        /// Get array of coputers that are infected.
        /// </summary>
        /// <returns></returns>
        public bool[] GetArray()
        {
            return infectedComputers;
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
