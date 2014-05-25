namespace _7._1.stack_list
{
    /// <summary>
    /// Stack based on references.
    /// </summary>
    /// 
    public class Stack
    {
        /// <summary>
        /// Discription of Stack's element.
        /// </summary>
        private class StackElement
        {
            /// <summary>
            /// Meaning of the Stack's element.
            /// </summary>
            public int Value { get; set; }

            /// <summary>
            /// Field that point on the next element.
            /// </summary>
            public StackElement Next { get; set; }
        }

        /// <summary>
        /// Pointer of the first Stack's element which could exist or not.
        /// </summary>
        private StackElement head = null;

        /// <summary>
        /// Push value to a Stack.
        /// </summary>
        /// <param name="value">Value to be pushed.</param>
        public void Push(int value)
        {
            var newElement = new StackElement()
            {
                Next = head,
                Value = value
            };

            head = newElement;
        }

        /// <summary>
        /// Take Stack's top element.
        /// </summary>
        /// <returns></returns>
        public int Pop()
        {
            if (head == null)
            {
                return -1;
            }

            var temp = head.Value;
            head = head.Next;
            return temp;
        }

        /// <summary>
        /// Chek of existence elements in Stack.
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return head == null;
        }
    }
}
