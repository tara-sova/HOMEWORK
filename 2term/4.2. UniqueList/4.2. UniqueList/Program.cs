using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._2.UniqueList
{
    class Program
    {
        static void Main(string[] args)
        {
            UniqueList list1 = new UniqueList();

            list1.Insert1(1, 0);
            list1.Insert1(2, 1);
            list1.Insert1(3, 2);
            list1.Insert1(2, 3);

            list1.Push1(1);
            list1.Push1(2);
            list1.Push1(3);
            list1.Push1(2);

        }
    }
}
