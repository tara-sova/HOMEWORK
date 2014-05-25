#include <iostream>
#include "tree.h"

using namespace std;

int main()
{
	Tree *tree = create();

	const Element value1 = 0;
	const Element value2 = 1;
	const Element value3 = 2;
	const Element value4 = 3;
	const Element value5 = 4;
	const Element value6 = 5;
	const Element value7 = 6;
	const Element value8 = 7;
	const Element value9 = 8;

	insertElement(tree, value5);
	insertElement(tree, value3);
	insertElement(tree, value2);
	insertElement(tree, value4);
	insertElement(tree, value7);
	insertElement(tree, value6);
	insertElement(tree, value8);

	cout << "Destending sort:" << endl;
	outputDescending(tree);

	cout << "Ascending sort:" << endl;
	outputAscending(tree);

	cout << "Ascending sort2:" << endl;

	removeElement(tree, value2);
	removeElement(tree, value6);

	outputAscending(tree);
	remove(tree);

	return 0;
}