using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._1_iterator
{
    /// <summary>
    /// Interface for making comparison.
    /// </summary>
    /// <typeparam name="ElementType"></typeparam>
    public interface InterfaceOfComparator<ElementType>
    {
        /// <summary>
        /// Method for comparison.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="temp"></param>
        /// <returns></returns>
        int Compare(ElementType value, ElementType temp);
    }
}
