#ifndef STACK_H
#define STACK_H
#include"interface.h"

class Stack:public Interface
{
public:
    Stack();
    ~Stack();
    void push(int value) override;
    int pop() override;
    bool isEmpty() override;

private:
    class StackElement
            {
                public : int value;

                public : StackElement* next;
            };

    StackElement* head = nullptr;

};

#endif // STACK_H
