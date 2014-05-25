using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5._1.Map
{
    public class ClassForUsing
    {
        public List Map1(List list, Func<int, int> fucnctionThatChangeNumbers)
        {
            List newList = new List();

            var tempElement = list.GettingFirst();

            int counter = list.CounterOfElements();
            for (int i = 0; i < counter; ++i)
            {
                newList.IncertToTheEnd(tempElement.Value);
                var element = newList.GettingLast();
                element.Value = fucnctionThatChangeNumbers(element.Value);

                tempElement = tempElement.Next;
            }

            return newList;
        }

        public List Filter(List list, Func<int, bool> boolFuction)
        {
            List newList = new List();

            var tempElement = list.GettingFirst();

            int counter = list.CounterOfElements();
            for (int i = 0; i < counter; ++i)
            {
                if (boolFuction(tempElement.Value) == true)
                {
                    newList.IncertToTheEnd(tempElement.Value);
                }

                tempElement = tempElement.Next;
            }

            return newList;
        }


        public int Fold(List list, int startElement, Func<int, List, int> changeByList)
        {
            List newList = new List();
            newList = list;

            var tempElement = newList.GettingFirst();

            int acc = startElement;
            int counter = list.CounterOfElements();
            for (int i = 0; i < counter; ++i)
            {
                acc = changeByList(acc, newList);

                newList.HeadRemoving();
            }

            return acc;
        }
    }
}
