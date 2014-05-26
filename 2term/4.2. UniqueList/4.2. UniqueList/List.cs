namespace _4._2.UniqueList
{
    /// <summary>
    /// List based on references.
    /// </summary>
    public class List
    {
        /// <summary>
        /// Description of List's element.
        /// </summary>
        protected class ListElement
        {
            /// <summary>
            /// Meaning of the List's element.
            /// </summary>
            public int Value { get; set; }

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
        protected ListElement head = null;

        /// <summary>
        /// Insert value to a List by using a position.
        /// </summary>
        /// <param name="value">Value to be pushed.</param>
        public virtual void Insert(int value, int position)
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

            ListElement elementAfterTemp = tempElement.Next;
            tempElement.Next = newElement;
            newElement.Previous = tempElement;
            elementAfterTemp.Previous = newElement;
            newElement.Next = elementAfterTemp;
        }

        public virtual void Insert1(int value, int position)
        {
            this.Insert(value, position);
        }

        /// <summary>
        /// Push value to a List.
        /// </summary>
        /// <param name="value">Value to be pushed.</param>
        public void Push(int value)
        {
            var newElement = new ListElement()
            {
                Next = head,
                Value = value,
                Previous = null
            };

            head = newElement;
        }

        public virtual void Push1(int value)
        {
            this.Push(value);
        }

        public int GettingFirst()
        {
            if (!IsEmpty())
            {
                return head.Value;
            }
            return 0;
        }

        /// <summary>
        /// Removing element by using a position.
        /// </summary>
        /// <param name="value">Value to be pushed.</param>
        public void RemovingByPosition(int position)
        {
            ListElement tempElement = head;

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


        public virtual void Removing1(int position)
        {
            this.RemovingByPosition(position);
        }

        /// <summary>
        /// Get element's value by using a position.
        /// </summary>
        /// <param name="value">Value to be pushed.</param>
        public int GettingOfValueByPosition(int position)
        {
            if (position < 0)
            {
                return -1;
            }

            ListElement tempElement = head;

            for (int i = 0; i < position; ++i)
            {
                if (tempElement == null)
                {
                    return -1;
                }
                tempElement = tempElement.Next;
            }
            return tempElement.Value;
        }

        /// <summary>
        /// Get element's position by using a value.
        /// </summary>
        /// <param name="value">Value to be pushed.</param>
        public int GettingOfPositionByValue(int value)
        {
            int position = 0;
            ListElement tempElement = head;

            while (tempElement.Value != value)
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

            ListElement tempElement = head;
            while (tempElement != null)
            {
                result = result + tempElement.Value + "  ";
                tempElement = tempElement.Next;
            }
            return result;
        }

        public bool TheExistChecking(int element)
        {
            ListElement tempElement = head;
            
            if (head == null)
            {
                return false;
            }

            while (tempElement != null)
            {
                if (tempElement.Value == element)
                {
                    return true;
                }

                tempElement = tempElement.Next;
            }

            return false;
        }

        /// <summary>
        /// Calculate of list's size.
        /// </summary>
        public int Size()
        {
            ListElement tempElement = head;
            int numberOfElements = 0;

            while (tempElement != null)
            {
                tempElement = tempElement.Next;
                ++numberOfElements;
            }
            return numberOfElements;
        }

    }
}
