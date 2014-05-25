using BasedOnArraysStackNamespace;
using StackNamespace;

namespace _2._4.calculator
{
    public class Calculator
    {
        private MainStack Stack;

        public Calculator(MainStack stack)
        {
            this.Stack = stack;
        }

        public int Sum()
        {
            int firstNumber = Stack.Pop();
            int secondNumber = Stack.Pop();
            int sum = firstNumber + secondNumber;
            return sum;
        }

        public int Difference()
        {
            int firstNumber = Stack.Pop();
            int secondNumber = Stack.Pop();
            int difference = firstNumber - secondNumber;
            return difference;
        }

        public int Quotient()
        {
            int firstNumber = Stack.Pop();
            int secondNumber = Stack.Pop();
            int quotient = firstNumber / secondNumber;
            return quotient;
        }

        public int Product()
        {
            int firstNumber = Stack.Pop();
            int secondNumber = Stack.Pop();
            int product = firstNumber * secondNumber;
            return product;
        }
    }
}
