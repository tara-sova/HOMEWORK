using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._2.multiplicity
{
    /// <summary>
    /// Class that describes multiplicity.
    /// </summary>
    /// <typeparam name="ElementType"></typeparam>
    public class Multiplicity<ElementType>
    {
        /// <summary>
        /// Description of List's element.
        /// </summary>
        private class MultiplicityElement
        {
            /// <summary>
            /// Meaning of the List's element.
            /// </summary>
            public ElementType Value { get; set; }

            /// <summary>
            /// Field that point on the next element.
            /// </summary>
            public MultiplicityElement Next { get; set; }
        }

        /// <summary>
        /// Pointer of the first List's element which could exist or not.
        /// </summary>
        private MultiplicityElement head = null;

        /// <summary>
        /// Add element to multiplicity.
        /// </summary>
        /// <param name="value"></param>
        public void Insert(ElementType value)
        {
            var newElement = new MultiplicityElement()
            {
                Value = value,
                Next = null,
            };

            if (IsEmpty())
            {
                head = newElement;
                return;
            }

            MultiplicityElement tempElement = head;

            while (tempElement.Next != null)
            {
                if(tempElement.Next == null)
                {
                    return;
                }
                if (tempElement.Value.Equals(value))
                {
                    return;
                }
                tempElement = tempElement.Next;
            }
            tempElement.Next = newElement;
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
        /// Chek of existence elements in List.
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

            MultiplicityElement tempElement = head;
            while (tempElement != null)
            {
                result = result + tempElement.Value + "  ";
                tempElement = tempElement.Next;
            }
            return result;
        }

        /// <summary>
        /// Delete one of the multiplicity's element.
        /// </summary>
        /// <param name="value"></param>
        public void RemovingOfElement(ElementType value)
        {
            MultiplicityElement tempElement = head;
            MultiplicityElement elementBeforeTemp = head;

            while (tempElement != null)
            {
                if (head.Value.Equals(value))
                {
                    head = head.Next;
                    tempElement = null;
                    return;
                }
                if (!tempElement.Value.Equals(value))
                {
                    elementBeforeTemp = tempElement;
                    tempElement = tempElement.Next;
                }
                else
                {
                    elementBeforeTemp.Next = tempElement.Next;
                    tempElement = null;
                    return;
                }
            }
        }

        /// <summary>
        /// Check element's of interesting existence.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool ExistenceChecking(ElementType value)
        {
            if (IsEmpty())
            {
                return false;
            }

            MultiplicityElement tempElement = head;

            while (tempElement != null)
            {
                if (!tempElement.Value.Equals(value))
                {
                    tempElement = tempElement.Next;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Getting result of intersection of two multiplicity.
        /// </summary>
        /// <param name="First"></param>
        /// <param name="Second"></param>
        public void Intersection(Multiplicity<ElementType> First, Multiplicity<ElementType> Second)
        {
            if ((First.IsEmpty()) || (Second.IsEmpty()))
            {
                this.head = null;
                return;
            }

            MultiplicityElement tempFirst = First.head;
            MultiplicityElement tempSecond = Second.head;

            while (tempFirst != null)
            {
                while (tempSecond != null)
                {
                    if (tempFirst.Value.Equals(tempSecond.Value))
                    {
                        this.Insert(tempFirst.Value);
                    }
                    tempSecond = tempSecond.Next;
                }
                tempFirst = tempFirst.Next;
                tempSecond = Second.head;
            }
        }

        /// <summary>
        /// Getting result of union of two multiplicity.
        /// </summary>
        /// <param name="First"></param>
        /// <param name="Second"></param>
        public void Union(Multiplicity<ElementType> First, Multiplicity<ElementType> Second)
        {
            MultiplicityElement tempFirst = First.head;
            MultiplicityElement tempSecond = Second.head;

            while (tempFirst != null)
            {
                this.Insert(tempFirst.Value);
                tempFirst = tempFirst.Next;
            }

            while (tempSecond != null)
            {
                this.Insert(tempSecond.Value);
                tempSecond = tempSecond.Next;
            }
        }
    }
}
