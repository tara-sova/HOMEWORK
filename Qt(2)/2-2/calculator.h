#ifndef CALCULATOR_H
#define CALCULATOR_H
#include "interface.h"

class Calculator
{
public:
    Calculator(Interface &MainStack);
    int sum();
    int difference();
    int product();
    int quotient();

private:
    Interface &JustStack;
};

#endif // CALCULATOR_H
