#include "arraystack.h"

ArrayStack::ArrayStack()
{

}

ArrayStack::~ArrayStack()
{

}

void ArrayStack::push(int value)
            {
                ++LastElement;
                array[LastElement] = value;
            }

int ArrayStack::pop()
            {
                int value = array[LastElement];
                --LastElement;
                return value;
            }

bool ArrayStack::isEmpty()
            {
                if (LastElement == -1)
                {
                    return true;
                }
            }
