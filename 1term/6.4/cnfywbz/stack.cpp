#include "stack.h"
#include <stdlib.h>
#include <iostream>

using namespace std;

struct ElementOfStack
{
	ElementType value;
	ElementOfStack *next;
};

struct Stack
{
	ElementOfStack *head;
	//ElementOfStack *last;
};

Stack* createStack()
{
	Stack *result = new Stack;
	result->head = NULL;
	//result->last = NULL;
	return result;
}


void removeStack(Stack* stack)
{
	while (!isEmptyStack(stack)) // (isEmpty(queue) != true)
	{
		removeFromHead(stack);
	}
	delete stack;
}

void insertToTheHead(Stack* stack, ElementType element)
{
	ElementOfStack *newElement = new ElementOfStack;
	newElement->value = element;
	newElement->next = stack->head;
	stack->head = newElement;
	//	queue->last = newElement;
}

ElementType removeFromHead(Stack* stack)
{
	ElementOfStack *newHead = stack->head;
	if (stack->head == NULL)
	{
		cout << "Stack is empty" << endl;
		return 0;
	}
	stack->head = stack->head->next;
	ElementType value = newHead->value;
	delete newHead;
	return value;
}

bool isEmptyStack(Stack* stack)
{
	if (stack->head == NULL)
	{
		return true;
	}
	else
	{
		return false;
	}

	//  return (queue->head == NULL) && (queue->last == NULL);
}

ElementType firstElementOfStack(Stack* stack)
{
	return stack->head->value;
}