#ifndef INTERFACE_H
#define INTERFACE_H

class Interface
{
public:
    virtual void push(int value) = 0;
    virtual int pop() = 0;
};

#endif // INTERFACE_H
