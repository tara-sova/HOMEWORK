#include "stack.h"
#include <stdlib.h>
#include <iostream>

using namespace std;

int main()
{
	Stack* stack = create();
	bool temp = false;
	char n = ' ';
	char a = ' ';
	while (n != '!')
	{
		cin >> n;
		if (n == '(')
		{
			insertToTheHead(stack, '(');
		}

		if (n == '[')
		{
			insertToTheHead(stack, '[');
		}

		if (n == '{')
		{
			insertToTheHead(stack, '{');
		}

		if (!isEmpty(stack))
		{
			a = removeFromHead(stack);
		}
		else
		{
			temp = true;
			break;
		}
		if (((n == ')') && (a != '(')) || ((n == ']') && (a != '[')) || ((n == '}') && (a != '{')))
		{
			temp = true;
			break;
		}
	}

	if ((temp == true) || (!isEmpty(stack)))
	{
		cout << "Balance is destroyed\n";
	}
	else
	{
		cout << "Everything is ok\n";
	}
	remove(stack);
	return 0;
}