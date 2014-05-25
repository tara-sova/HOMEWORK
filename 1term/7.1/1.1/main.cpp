#include "list.h"
//#include "arrayList.h"
#include <stdio.h>
#include <iostream>
#include <fstream>

using namespace std;

void print(List* list)
{
	for (Position i = first(list); i != end(list); i = next(list, i))
	{
		cout << getValue(list, i) <<endl;
	}
}

List* mergeSort(List* list)
{
	Position i = first(list);

	if (next(list, i) == end(list))
	{
		return list;
	}

	List *list1 = create();
	List *list2 = create();

	int counter = 0;
	for (Position i = first(list); i != end(list); i = next(list, i))
	{
		++counter;
	}

	int middle = counter / 2;
	Position firstListValue = first(list);
	for (int i = 0; i < middle; ++i)
	{
		int newRecord = getValue(list, firstListValue);
		insert(list1, newRecord);
		firstListValue = next(list, firstListValue);
	}

	Position secondListValue = firstListValue;
	for (int i = middle; secondListValue != end(list); ++i)
	{
		int newRecord = getValue(list, secondListValue);
		insert(list2, newRecord);
		secondListValue = next(list, secondListValue);
	}

	List *variableOfRemoving1 = list1;
	List *variableOfRemoving2 = list2;
	
	list1 = mergeSort(list1);
	list2 = mergeSort(list2);

	List *listOfResult = create();
	Position t = first(list1);
	Position j = first(list2);

	while ((t != end(list1)) && (j != end(list2)))
	{

		if (getValue(list1, t) == getValue(list2, j))
		{
			insert(listOfResult, getValue(list1, t));
			t = next(list1, t);
		}
		else if (getValue(list1, t) < getValue(list2, j))
		{
			insert(listOfResult, getValue(list1, t));
			t = next(list1, t);
		}
		else
		{
			insert(listOfResult, getValue(list2, j));
			j = next(list2, j);
		}
	}
	
	while (t != end(list1))
	{
		insert(listOfResult, getValue(list1, t));
		t = next(list1, t);
	}
	while (j != end(list2))
	{
		insert(listOfResult, getValue(list2, j));
		j = next(list2, j);
	}
	
	removeList(variableOfRemoving1);
	removeList(variableOfRemoving2);

	if (variableOfRemoving1 != list1)
	{
		removeList(list1);
	}
	
	if (variableOfRemoving2 != list2)
	{
		removeList(list2);
	}
	return listOfResult;
}

int main()
{
	fstream file;
	file.open("Phone book.txt", ios::in);
	List *list = create();

	while (!file.eof())
	{
		int a = 0;
		file >> a;

		insert(list, a);
	}
	print(mergeSort(list));
	removeList(list);
	file.close();
	return 0;
}