using BasedOnArraysStackNamespace;
using StackNamespace;

namespace _2._4.calculator
{
    /// <summary>
    /// Stuff that calculate numbers.
    /// </summary>
    public class Calculator
    {
        private MainStack Stack;

        public Calculator(MainStack stack)
        {
            this.Stack = stack;
        }

        /// <summary>
        /// Calculate sum.
        /// </summary>
        /// <returns></returns>
        public int Sum()
        {
            int firstNumber = Stack.Pop();
            int secondNumber = Stack.Pop();
            int sum = firstNumber + secondNumber;
            return sum;
        }

        /// <summary>
        /// Calculate difference.
        /// </summary>
        /// <returns></returns>
        public int Difference()
        {
            int firstNumber = Stack.Pop();
            int secondNumber = Stack.Pop();
            int difference = firstNumber - secondNumber;
            return difference;
        }

        /// <summary>
        /// Difference quotient.
        /// </summary>
        /// <returns></returns>
        public int Quotient()
        {
            int firstNumber = Stack.Pop();
            int secondNumber = Stack.Pop();
            int quotient = firstNumber / secondNumber;
            return quotient;
        }

        /// <summary>
        /// Quotient product.
        /// </summary>
        /// <returns></returns>
        public int Product()
        {
            int firstNumber = Stack.Pop();
            int secondNumber = Stack.Pop();
            int product = firstNumber * secondNumber;
            return product;
        }
    }
}
