using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermWork1
{
    public class StringСomparator : InterfaceOfComparator<string>
    {
        public void Compair(string[] array)
        {
            int size = array.Length;

            string temp = "";
            for (int i = 0; i < size; ++i)
            {
                for (int j = size - 1; j > i; --j)
                {
                    if (array[j].Length < array[j - 1].Length)
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
