#include "list.h"
#include <stdio.h>
#include <iostream>
#include <fstream>

using namespace std;

void print(List* list)
{
	for (Position i = first(list); i != end(list); i = next(list, i))
	{
		cout << getValue(i).name << " " << getValue(i).phoneNumber << endl;
	}
}

List* mergeSort(List* list)
{
	Position i = first(list);

	if (i == end(list))
	{
		return list;
	}

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
		Record newRecord = getValue(firstListValue);
		insert(list1, newRecord);
		firstListValue = next(list, firstListValue);
	}
	
	Position secondListValue = next(list, firstListValue);
	for (int i = middle; i < counter - 1; ++i)
	{
		Record newRecord = getValue(secondListValue);
		insert(list2, newRecord);
		secondListValue = next(list, secondListValue);
	}

	list1 = mergeSort(list1);
	list2 = mergeSort(list2);

	List *listOfResult = create();
	Position t = first(list1);
	Position j = first(list2);
	while (t != end(list1) && j != end(list2))
	{
		if (strcmp(getValue(t).name, getValue(t).name) == -1)
		{
			insert(listOfResult, getValue(t));
			t = next(list1, t);
		}
		if (strcmp(getValue(t).name, getValue(t).name) == 1)
		{
			insert(listOfResult, getValue(j));
			j = next(list2, j);
		}
		if (strcmp(getValue(t).name, getValue(t).name) == 0)
		{
			insert(listOfResult, getValue(t));
			t = next(list1, t);
		}
	}
	while (t != end(list1))
	{
		insert(listOfResult, getValue(t));
		t = next(list1, t);
	}
	while (j != end(list2))
	{
		insert(listOfResult, getValue(j));
		j = next(list2, j);
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
		char name[50] = { '\0' };
		int phoneNumber = 0;
		file >> name;
		file >> phoneNumber;

		Record newRecord;
		newRecord.phoneNumber = phoneNumber;
		strcpy(newRecord.name, name);
		
		insert(list, newRecord);
	}
	mergeSort(list);
	print(list);
	file.close();
	return 0;
}