#include <QCoreApplication>
#include "calculator.h"
#include "interface.h"
#include "stack.h"
#include "arraystack.h"
#include <QtCore>
#include "iostream"

using namespace std;

int main()
{
    ArrayStack *arrayStack = new ArrayStack();
    Stack *stack = new Stack();

    Calculator *calculator = new Calculator(*arrayStack);

    qDebug() << "Input a postfix record: \n";

    char n = ' ';
        while (n != '=')
        {
                cin >> n;
                if (n == '=')
                {
                    break;
                }
                if ((n != '+') && (n != '-') && (n != '*') && (n != '/'))
                {
                    int number = n - '0';
                    arrayStack->push(number);
                }
                else
                {
                    int temp = 0;
                    if (n == '+')
                    {
                        temp = calculator->sum();
                    }
                    if (n == '-')
                    {
                        temp = calculator->difference();
                    }
                    if (n == '*')
                    {
                        temp = calculator->product();
                    }
                    if (n == '/')
                    {
                        temp = calculator->quotient();
                    }
                    arrayStack->push(temp);
                }
            }

    int result = arrayStack->pop();
    qDebug() << result;

    delete arrayStack;
    delete stack;

    return 0;
}
