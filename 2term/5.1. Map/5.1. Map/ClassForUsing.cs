using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5._1.Map
{
    public class ClassForUsing
    {
        /// <summary>
        /// Change list's element in our own way.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="fucnctionThatChangeNumbers"></param>
        /// <returns></returns>
        public List Map1(List list, Func<int, int> fucnctionThatChangeNumbers)
        {
            List newList = new List();

            var tempElement = list.GettingFirst();

            int counter = list.CounterOfElements();
            for (int i = 0; i < counter; ++i)
            {
                newList.InsertToTheEnd(tempElement.Value);
                var element = newList.GettingLast();
                element.Value = fucnctionThatChangeNumbers(element.Value);

                tempElement = tempElement.Next;
            }

            return newList;
        }

        /// <summary>
        /// Filter list's elements.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="boolFuction"></param>
        /// <returns></returns>
        public List Filter(List list, Func<int, bool> boolFuction)
        {
            List newList = new List();

            var tempElement = list.GettingFirst();

            int counter = list.CounterOfElements();
            for (int i = 0; i < counter; ++i)
            {
                if (boolFuction(tempElement.Value) == true)
                {
                    newList.InsertToTheEnd(tempElement.Value);
                }

                tempElement = tempElement.Next;
            }

            return newList;
        }

        /// <summary>
        /// Get accumulated value by using a function.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="startElement"></param>
        /// <param name="changeByList"></param>
        /// <returns></returns>
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
