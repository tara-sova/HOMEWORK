#include "stack.h"

Stack::Stack()
{
}

Stack::~Stack()
{
    while(!IsEmpty())
    {
        StackElement *tempElement = head;
        head = head->next;
        delete tempElement;
    }
}

void Stack::push(int value)
    {
        StackElement *newElement = new StackElement();
        newElement->value = value;
        newElement->next = head;

        head = newElement;
    }

int Stack::pop()
{
    if (head == nullptr)
    {
        return -1;
    }


    int temp = head->value;
    head = head->next;
    return temp;
}

bool Stack::isEmpty()
{
    return head == nullptr;
}
