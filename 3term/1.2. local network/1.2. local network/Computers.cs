using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._2.local_network
{
    /// <summary>
    /// Class for Computer.
    /// </summary>
    public class Computer
    {
        private bool IsInfected;
        private int OSType;
        private string Name;

        /// <summary>
        /// Computer's options.
        /// </summary>
        public Computer()
        {
            this.IsInfected = false;
            this.Name = "";
            this.OSType = 0;
        }

        /// <summary>
        /// Get index of infection.
        /// </summary>
        /// <param name="system"></param>
        /// <returns></returns>
        public int InfectionIndex(string system)
        {
            if (system == "Windows")
                return 50;
            if (system == "Linux")
                return 70;
            return 0;
        }

        /// <summary>
        /// Infect or not by special index.
        /// </summary>
        /// <param name="extraIndex"></param>
        public void TryToInfect(int extraIndex)
        {
            if (this.OSType < extraIndex)
            {
                this.IsInfected = true;
            }
        }

        /// <summary>
        /// Get computer's health condition.
        /// </summary>
        /// <returns></returns>
        public bool GetHealthCondition()
        {
            return this.IsInfected;
        }

        /// <summary>
        /// Get computer's operation system type.
        /// </summary>
        /// <returns></returns>
        public int GetOSType()
        {
            return this.OSType;
        }

        /// <summary>
        /// Get computer's name.
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            return this.Name;
        }

        /// <summary>
        /// Change computer's health option.
        /// </summary>
        /// <param name="condition"></param>
        public void SetHealthCondition(bool condition)
        {
            this.IsInfected = condition;
        }

        /// <summary>
        /// Change computer's operation system option.
        /// </summary>
        /// <param name="systemType"></param>
        public void SetOSType(int systemType)
        {
            this.OSType = systemType;
        }

        /// <summary>
        /// Change computer's name option.
        /// </summary>
        /// <param name="name"></param>
        public void SetName(string name)
        {
            this.Name = name;
        }

    }
}
