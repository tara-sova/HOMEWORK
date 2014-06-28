#ifndef ARRAYSTACK_H
#define ARRAYSTACK_H
#include "interface.h"

class ArrayStack:public Interface
{
public:
    ArrayStack();
    ~ArrayStack();
    void push(int value) override;
    int pop() override;

private:
    int array[100];
    int LastElement = -1;

};

#endif // ARRAYSTACK_H
