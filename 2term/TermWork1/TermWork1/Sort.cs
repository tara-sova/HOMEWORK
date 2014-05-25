using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermWork1
{
    public class Sort<ElementType>
    {
        public void BubbleSort(ElementType[] array, InterfaceOfComparator<ElementType> Comparator)
        {
            Comparator.Compair(array);
        }
    }
}
