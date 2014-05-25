#include "list.h"
#include <iostream>
#include <stdlib.h>
#include <string.h>
#include <fstream>

using namespace std;

int main()
{
	List *list = create();
	
	cout << "0 - exit\n";
	cout << "1 - add new value in the sorted list\n";
	cout << "2 - delete value from the list\n";
	cout << "3 - print the list\n";
    
	int command = -1;
	while (command != 0)
	{
		
		cin >> command;
		int newValue = 0;
		int copyOfNewValue = 0;
		bool flag = false;
		
		if (command == 1)
		{
			cin >> newValue;
			copyOfNewValue = newValue;
			while (first(list) == end(list))
			{
				insertToHead(list, newValue);
				flag = true;
				break;
			}
		}
		if ((command == 1) && (flag == false))
		{
			if (copyOfNewValue < valueOnPosition(list, first(list)))
			{
				insertToHead(list, copyOfNewValue);
			}
			Position beforeEnd = first(list);
			for (Position i = first(list); i != end(list); i = next(list, i))
			{
				if (next(list, i) == NULL)
				{
					break;
				}
				else
				{
					beforeEnd = next(list, beforeEnd);
					if (copyOfNewValue > valueOnPosition(list, i) && (copyOfNewValue < valueOnPosition(list, next(list, i))))
					{
						insert(list, copyOfNewValue, i);
						break;
					}
				}
			}
			if (copyOfNewValue > valueOnPosition(list, beforeEnd))
			{
				insertToTheEnd(list, copyOfNewValue, beforeEnd);
			}
		}
		if (command == 2)
		{
			int valueOfDelete = 0;
			cin >> valueOfDelete;
			for (Position i = first(list); i != end(list); i = next(list, i))
			{
				if (valueOfDelete == valueOnPosition(list, i))
				{
					remove(list, i);
					break;
				}
			}
		}

		if (command == 3)
		{
			print(list);
		}
	}
	removeList(list);
	return 0;
}