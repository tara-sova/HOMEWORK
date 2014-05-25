using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermWork1
{
    public class IntComparator : InterfaceOfComparator<int>
    {
        public void Compair(int[] array)
        {
            int size = array.Length;

            int temp = 0;
            for (int i = 0; i < size; ++i)
            {
                for (int j = size - 1; j > i; --j)
                {
                    if (array[j] < array[j - 1])
                    {
                        temp = array[j];
                        array[j] = array[j - 1];
                        array[j - 1] = temp;
                    }
                }
            }
        }
    }
}
