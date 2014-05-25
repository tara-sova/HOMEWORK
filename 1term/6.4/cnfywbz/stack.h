#pragma once

typedef char ElementType;

struct Stack;

Stack* createStack();
void removeStack(Stack* stack);
void insertToTheHead(Stack* stack, ElementType element);
ElementType removeFromHead(Stack* stack);
bool isEmptyStack(Stack* stack);
ElementType firstElementOfStack(Stack* stack);