#pragma once

typedef int ElementType;

struct Stack;

Stack* create();
void remove(Stack* stack);
void insertToTheHead(Stack* stack, ElementType element);
ElementType removeFromHead(Stack* stack);
bool isEmpty(Stack* stack);