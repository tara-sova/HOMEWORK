#include <iostream>
#include <fstream>
#include "tree.h"

using namespace std;

int main()
{
	Tree *tree = create();
	char value = ' ';
	bool typeOfElement = false;
	Position position = nullptr;

	ifstream text;
	text.open("text.txt", ios::in);

	while (!text.eof())
	{
		text >> value;
		if (text.eof())
		{
			break;
		}
		if (value == ')')
		{
			goBack(position);
			continue;
		}
		if (value == '(')
		{
			continue;
		}
		if ((value == '+') || (value == '-') || (value == '*') || (value == '/'))
		{
			typeOfElement = true;
		}
		insertElement(tree, position, value, typeOfElement);
		typeOfElement = false;
	}
	outputAscending(tree);
	cout << " = " << calculateOfTheTree(tree) << endl;

	text.close();
	remove(tree);
	return 0;
}