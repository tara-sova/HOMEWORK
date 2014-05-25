#include "stack.h"
#include <stdlib.h>
#include <iostream>

using namespace std;

int main()
{
	Stack* stack = create();
	cout << "Input a postfix record: ";
	char n = ' ';
	while (n != '=')
	{
		cin >> n;
		if (n == '=')
		{
			break;
		}
		if ((n != '+') && (n != '-') && (n != '*') && (n != '/'))
		{
			int number = n - '0';
			insertToTheHead(stack, number);
		}
		else
		{
			int a = removeFromHead(stack);
			int b = removeFromHead(stack);
			int c = 0;
			if (n == '+')
			{
				c = a + b;
			}
			if (n == '-')
			{
				c = b - a;
			}
			if (n == '*')
			{
				c = a * b;
			}
			if (n == '/')
			{
				c = b / a;
			}
			insertToTheHead(stack, c);
		}
	}
	cout << "Result is: ";
	while (!isEmpty(stack))
	{
		cout << removeFromHead(stack) << endl;
	}
	remove(stack);
	return 0;
}