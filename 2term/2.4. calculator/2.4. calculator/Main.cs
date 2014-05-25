using BasedOnArraysStackNamespace;
using StackNamespace;

namespace _2._4.calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            MainStack arrayStack = new BasedOnArraysStack();
            MainStack stack = new Stack();

            Calculator calculator = new Calculator(arrayStack);

            arrayStack.Push(1);
            arrayStack.Push(2);
            arrayStack.Push(3);

            int result = calculator.Difference();
            System.Console.WriteLine("{0}  ", result);

            stack.Push(4);
            stack.Push(5);
            stack.Push(6);

            //System.Console.WriteLine("{0}  ", arrayStack.Pop());
            //System.Console.WriteLine("{0}  ", arrayStack.Pop());
            //System.Console.WriteLine("{0}  ", arrayStack.Pop());

            //System.Console.WriteLine("{0}  ", stack.Pop());
            //System.Console.WriteLine("{0}  ", stack.Pop());
            //System.Console.WriteLine("{0}  ", stack.Pop());

        }

    }
}