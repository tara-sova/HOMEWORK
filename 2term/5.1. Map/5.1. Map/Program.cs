using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5._1.Map
{
    class Program
    {
        Func<int, int> fucnctionThatChangeNumbers = x => x + 5;
        Func<int, bool> boolFuction = x => x > 5;

        Func<int, List, int> changeByList = (acc, elem) => acc = acc * elem.GettingFirstValue();

        static void Main(string[] args)
        {
            List list5 = new List();
            list5.InsertToTheEnd(1);
            list5.InsertToTheEnd(2);
            list5.InsertToTheEnd(3);
            
            ClassForUsing Fo = new ClassForUsing();

            int temp = Fo.Fold(list5, 1, (acc, elem) => acc = acc * elem.GettingFirstValue());
            System.Console.WriteLine(temp);
        }
    }
}
