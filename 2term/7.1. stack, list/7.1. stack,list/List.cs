using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._1.stack_list
{
    /// <summary>
    /// List based on references.
    /// </summary>
    public class List<ElementType> : IEnumerable<ElementType>
    {
        /// <summary>
        /// Description of List's element.
        /// </summary>
        public class ListElement
        {
            /// <summary>
            /// Meaning of the List's element.
            /// </summary>
            public ElementType Value { get; set; }

            /// <summary>
            /// Field that point on the next element.
            /// </summary>
            public ListElement Next { get; set; }

            /// <summary>
            /// Field that point on the previous element.
            /// </summary>
            public ListElement Previous { get; set; }
        }

        /// <summary>
        /// Pointer of the first List's element which could exist or not.
        /// </summary>
        private ListElement head = null;

        /// <summary>
        /// Insert value to a List by using a position.
        /// </summary>
        /// <param name="value">Value to be pushed.</param>
        public void Insert(ElementType value, int position)
        {
            if (position == 0)
            {
                Push(value);
                return;
            }
            var newElement = new ListElement()
            {
                Value = value,
                Next = head,
                Previous = null
            };

            if (IsEmpty())
            {
                head = newElement;
                return;
            }

            ListElement tempElement = head;

            for (int i = 1; i < position; ++i)
            {

                if (tempElement.Next == null)
                {
                    return;
                }
                tempElement = tempElement.Next;
            }

            if (tempElement.Next == null)
            {
                tempElement.Next = newElement;
                newElement.Previous = tempElement;
                newElement.Next = null;
                return;
            }

            ListElement elementAfterTemp = tempElement.Next;
            tempElement.Next = newElement;
            newElement.Previous = tempElement;
            elementAfterTemp.Previous = newElement;
            newElement.Next = elementAfterTemp;
        }

        /// <summary>
        /// Push value to a List.
        /// </summary>
        /// <param name="value">Value to be pushed.</param>
        public void Push(ElementType value)
        {
            var newElement = new ListElement()
            {
                Next = head,
                Value = value,
                Previous = null
            };

            head = newElement;
        }

        /// <summary>
        /// Removing element by using a position.
        /// </summary>
        /// <param name="value">Value to be pushed.</param>
        public void RemovingByPosition(int position)
        {
            ListElement tempElement = head;

            if ((position == 0) && (head.Next == null))
            {
                this.head = null;
                return;
            }

            if (position == 0)
            {
                head.Value = head.Next.Value;
                head = head.Next;
                head.Previous = null;
                return;
            }

            for (int i = 0; i < position; ++i)
            {
                ListElement beforeTemp = tempElement;
                tempElement = tempElement.Next;
                tempElement.Previous = beforeTemp;
                if (tempElement == null)
                {
                    return;
                }
            }

            tempElement.Previous.Next = tempElement.Next;
            tempElement.Next.Previous = tempElement.Previous;
        }

        /// <summary>
        /// Get element's value by using a position.
        /// </summary>
        /// <param name="value">Value to be pushed.</param>
        public ElementType GettingOfValueByPosition(int position)
        {
            if (position < 0)
            {
                throw new Exception();
            }

            ListElement tempElement = head;

            for (int i = 0; i < position; ++i)
            {
                if (tempElement == null)
                {
                    throw new Exception();
                }
                tempElement = tempElement.Next;
            }
            return tempElement.Value;
        }

        /// <summary>
        /// Get element's position by using a value.
        /// </summary>
        /// <param name="value">Value to be pushed.</param>
        public int GettingOfPositionByValue(ElementType value)
        {
            int position = 0;
            ListElement tempElement = head;

            while (tempElement.Value.Equals(value))
            {
                tempElement = tempElement.Next;
                ++position;

                if (tempElement == null)
                {
                    return -1;
                }
            }
            return position;
        }

        /// <summary>
        /// Delete List.
        /// </summary>
        /// <param name="value">Value to be pushed.</param>
        public void Removing()
        {
            head = null;
        }

        /// <summary>
        /// Check of existence elements in List.
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return head == null;
        }

        /// <summary>
        /// Print of the list.
        /// </summary>
        /// <returns></returns>
        public string Print()
        {
            string result = "";
            if (IsEmpty())
            {
                result = "No elemenets in the list.";
                return result;
            }

            ListElement tempElement = head;
            while (tempElement != null)
            {
                result = result + tempElement.Value + "  ";
                tempElement = tempElement.Next;
            }
            return result;
        }

        /// <summary>
        /// Getting list's first element.
        /// </summary>
        /// <returns></returns>
        public ListElement GetFirst()
        {
            return head;
        }

        /// <summary>
        /// Getting of Enumerator for our list.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<ElementType> GetEnumerator()
        {
            var enumerator = new Enumerator<ElementType>(this);
            return enumerator;
        }

        /// <summary>
        /// Getting of Enumerator for our list but with some object type.
        /// </summary>
        /// <returns></returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            var enumerator = new Enumerator<ElementType>(this);
            return enumerator;
        }

    }
}
