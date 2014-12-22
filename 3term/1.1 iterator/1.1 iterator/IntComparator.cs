using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._1_iterator
{
    /// <summary>
    /// Comparator for int type.
    /// </summary>
    public class IntComparator : InterfaceOfComparator<int>
    {
        /// <summary>
        /// Method for int's comparison.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="temp"></param>
        /// <returns></returns>
        public int Compare(int value, int temp)
        {
            if (value < temp)
            {
                return (-1);
            }
            if (value > temp)
            {
                return 1;
            }
            return 0;
        }
    }
}
