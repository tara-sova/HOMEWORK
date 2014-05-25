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
            //List list1 = new List();
            //list1.IncertToTheEnd(1);
            //list1.IncertToTheEnd(2);
            //list1.IncertToTheEnd(3);

            //List list2 = new List();

            //ClassForUsing M = new ClassForUsing();
            //list2 = M.Map1(list1, x => x + 5);
            //System.Console.WriteLine(list2.Print());


            //List list3 = new List();
            //list3.IncertToTheEnd(5);
            //list3.IncertToTheEnd(10);
            //list3.IncertToTheEnd(15);
            //list3.IncertToTheEnd(1);
            //list3.IncertToTheEnd(8);

            //List list4 = new List();

            //ClassForUsing F = new ClassForUsing();
            //list4 = F.Filter(list3, x => x > 5);
            //System.Console.WriteLine(list4.Print());

            List list5 = new List();
            list5.IncertToTheEnd(1);
            list5.IncertToTheEnd(2);
            list5.IncertToTheEnd(3);
            

            ClassForUsing Fo = new ClassForUsing();

            int temp = Fo.Fold(list5, 1, (acc, elem) => acc = acc * elem.GettingFirstValue());
            System.Console.WriteLine(temp);


        }
    }
}
