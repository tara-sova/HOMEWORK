using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWork2
{
    public class PriorityQueue
    {
        private class ListElement
        {
            public int Value { get; set; }

            public int Priority { get; set; }

            public ListElement Next { get; set; }

        }

        private ListElement head = null;

        public void Enqueue(int value, int priority)
        {
            var newElement = new ListElement()
            {
                Value = value,
                Priority = priority,
                Next = head,
            };

            if (IsEmpty())
            {
                head = newElement;
                return;
            }

            ListElement tempElement = head;

            if(tempElement.Priority == newElement.Priority)
            {

                ListElement MovingElement = tempElement.Next;
                tempElement.Next = newElement;
                newElement.Next = MovingElement;
                return;
            }

            if (tempElement.Priority < newElement.Priority)
            {
                head = newElement;
                head.Next = tempElement;
                return;
            }

            if (tempElement.Next != null)
            {
                while (tempElement.Next.Priority > newElement.Priority)
                {
                    tempElement = tempElement.Next;
                }

                if(tempElement.Next.Priority < newElement.Priority)
                {
                    ListElement MovingElement = tempElement.Next;
                    tempElement.Next = newElement;
                    newElement.Next = MovingElement;
                }

                if (tempElement.Next.Priority == newElement.Priority)
                {
                    if (tempElement.Next != null)
                    {
                        ListElement MovingElement = tempElement.Next.Next;
                        tempElement.Next.Next = newElement;
                        newElement.Next = MovingElement;
                    }
                    else
                    {
                        tempElement.Next.Next = newElement;
                        newElement.Next = null;
                    }
                }
            }
            else
            {
                head.Next = newElement;
                newElement.Next = null;
            }

        }

        public int Dequeue()
        {
            int theBiggestPriority = 0;
            if(IsEmpty())
            {
                throw new Exception();
            }
            else
            {
                theBiggestPriority = head.Value;
                head = head.Next;
            }
            return theBiggestPriority;
        }

        public void Removing()
        {
            head = null;
        }

        public bool IsEmpty()
        {
            return head == null;
        }

    }
}
