using _2._4.calculator;

namespace BasedOnArraysStackNamespace
{
    /// <summary>
    /// Stack that based on array.
    /// </summary>
    public class BasedOnArraysStack: MainStack
    {
        private int[] array = new int[100];

        private int LastElement = -1;

        /// <summary>
        /// Input element in stack.
        /// </summary>
        /// <param name="value"></param>
        public void Push(int value)
        {
            ++this.LastElement;
            this.array[LastElement] = value;
        }

        /// <summary>
        /// Output element from stack.
        /// </summary>
        /// <returns></returns>
        public int Pop()
        {
            int value = this.array[LastElement];
            --this.LastElement;
            return value;
        }

        /// <summary>
        /// Print our stack's elements.
        /// </summary>
        public void Print()
        {
            int i = 0;
            int temp = this.LastElement;
            while(array[i] != array[temp + 1])
            {
                System.Console.WriteLine("{0}  ", array[i]);
                ++i;
            }
        }
    }
}
