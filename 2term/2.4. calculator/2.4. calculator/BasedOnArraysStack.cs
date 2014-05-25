using _2._4.calculator;

namespace BasedOnArraysStackNamespace
{
    public class BasedOnArraysStack: MainStack
    {
        private int[] array = new int[100];

        private int LastElement = -1;

        public void Push(int value)
        {
            ++this.LastElement;
            this.array[LastElement] = value;
        }

        public int Pop()
        {
            int value = this.array[LastElement];
            --this.LastElement;
            return value;
        }

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
