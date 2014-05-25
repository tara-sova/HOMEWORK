#include "cycleList.h"
#include <stdio.h>
#include <iostream>

using namespace std;

int main()
{
	CycleList *cycleList = create();

	int n = 0;
	int m = 0;
	cout << "Input n: ";
	cin >> n;
	cout << "Input m: ";
	cin >> m;
	for (int i = 1; i <= n; ++i)
	{
		insertToTheEnd(cycleList, i);
	}
	
	Position element = positionOfHead(cycleList);
	while (next(element) != element)
	{
		for (int i = 1; i < m; ++i)
		{
			element = next(element);
		}
		Position removingElement = element;
		element = next(element);
		removeFromTheCycleList(cycleList, removingElement);
	}
	cout << "Our k is: ";
	cout << meaningOfElement(element) << endl;
	removeTheCycleList(cycleList);
	return 0;
}