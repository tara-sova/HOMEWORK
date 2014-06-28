#include "calculator.h"
#include "interface.h"

Calculator::Calculator(Interface &MainStack)
    : JustStack(MainStack)
{
}

int Calculator::sum()
        {
            int firstNumber = JustStack.pop();
            int secondNumber = JustStack.pop();
            int sum = firstNumber + secondNumber;
            return sum;
        }

int Calculator::difference()
        {
            int firstNumber = JustStack.pop();
            int secondNumber = JustStack.pop();
            int difference = firstNumber - secondNumber;
            return difference;
        }

int Calculator::quotient()
        {
            int firstNumber = JustStack.pop();
            int secondNumber = JustStack.pop();
            int quotient = firstNumber / secondNumber;
            return quotient;
        }

int Calculator::product()
        {
            int firstNumber = JustStack.pop();
            int secondNumber = JustStack.pop();
            int product = firstNumber * secondNumber;
            return product;
        }
