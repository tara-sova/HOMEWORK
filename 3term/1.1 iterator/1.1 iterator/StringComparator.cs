using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._1_iterator
{
    /// <summary>
    /// Comparator for string type.
    /// </summary>
    public class StringComparator : InterfaceOfComparator<string>
    {
        /// <summary>
        /// Method for string's comparison.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="temp"></param>
        /// <returns></returns>
        public int Compare(string value, string temp)
        {
            int i = 0;
            while (i != value.Length && i != temp.Length)
            {
                if (value[i] > temp[i])
                {
                    return 1;
                }
                if (value[i] < temp[i])
                {
                    return -1;
                }
                if (value[i] == temp[i])
                {
                    ++i;
                }
            }
            return 0;
        }
    }
}
