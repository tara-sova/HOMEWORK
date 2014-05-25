using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWork2
{
    class Program
    {
        static void Main()
        {
            var Queue = new PriorityQueue();
            Queue.Enqueue(10, 1);
            Queue.Enqueue(5, 2);
            Queue.Enqueue(23, 4);
            Queue.Enqueue(40, 3);

            int a = Queue.Dequeue();
            //int b = Queue.Dequeue();
            //int c = Queue.Dequeue();
            //int d = Queue.Dequeue();

            System.Console.WriteLine("{0}", a);

        }
    }
}
