#include "queue.h"
#include "stack.h"
#include <stdlib.h>
#include <iostream>

using namespace std;

int main()
{
	Stack* stack = createStack();
	Queue* queue = create();
	char element = ' ';

	cout << "Input the expression: ";

	while (element != '=')
	{
		cin >> element;
		if (element == '=')
		{
			break;
		}
		if ((element >= '0') && (element <= '9'))
		{
			insertToTheEnd(queue, element);
		}

		if (element == '(')
		{
			insertToTheHead(stack, element);
		}

		if (element == ')')
		{
			while (firstElementOfStack(stack) != '(')
			{
				char a = removeFromHead(stack);
				insertToTheEnd(queue, a);
			}
			removeFromHead(stack);
		}

		if ((element == '*') || (element == '/'))
		{
			if (isEmptyStack(stack) == true)
			{
				insertToTheHead(stack, element);
			}
			else
			{
				if ((firstElementOfStack(stack) == '*') || (firstElementOfStack(stack) == '/'))
				{
					char a = removeFromHead(stack);
					insertToTheEnd(queue, a);
					insertToTheHead(stack, element);
				}
				else
				{
					insertToTheHead(stack, element);
				}
			}
		}

		if ((element == '+') || (element == '-'))
		{
			if (isEmptyStack(stack) == true)
			{
				insertToTheHead(stack, element);
			}
			else
			{
				if ((firstElementOfStack(stack) == '+') || (firstElementOfStack(stack) == '-'))
				{
					char a = removeFromHead(stack);
					insertToTheEnd(queue, a);
					insertToTheHead(stack, element);
				}
				else
				{
					insertToTheHead(stack, element);
				}
			}
		}
	}

	cout << "New expression is: ";

	while (!isEmpty(queue)) 
	{
		char a = removeFromHead(queue);
		cout << a;
	}

	while (!isEmptyStack(stack)) 
	{
		char a = removeFromHead(stack);
		cout << a;
	}

	cout << "\n";

	removeStack(stack);
	removeQueue(queue);
	return 0;
}