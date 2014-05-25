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

List* mergeSort(List* list, bool choice)
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
		Record newRecord = getValue(firstListValue);
		insert(list1, newRecord);
		firstListValue = next(list, firstListValue);
	}

	Position secondListValue = firstListValue;
	for (int i = middle; secondListValue != end(list); ++i)
	{
		Record newRecord = getValue(secondListValue);
		insert(list2, newRecord);
		secondListValue = next(list, secondListValue);
	}

	List *variableOfRemoving1 = list1;
	List *variableOfRemoving2 = list2;
	
	list1 = mergeSort(list1, choice);
	list2 = mergeSort(list2, choice);

	List *listOfResult = create();
	Position t = first(list1);
	Position j = first(list2);

	while (t != end(list1) && j != end(list2))
	{
		if (choice == false)
		{
			if (strcmp(getValue(t).name, getValue(j).name) == -1)
			{
				insert(listOfResult, getValue(t));
				t = next(list1, t);
			}
			else if (strcmp(getValue(t).name, getValue(j).name) == 1)
			{
				insert(listOfResult, getValue(j));
				j = next(list2, j);
			}
			else
			{
				insert(listOfResult, getValue(t));
				t = next(list1, t);
			}
		}
		else
		{
			if (getValue(t).phoneNumber > getValue(j).phoneNumber)
			{
				insert(listOfResult, getValue(t));
				t = next(list1, t);
			}
			else if (getValue(t).phoneNumber < getValue(j).phoneNumber)
			{
				insert(listOfResult, getValue(j));
				j = next(list2, j);
			}
			else
			{
				insert(listOfResult, getValue(t));
				t = next(list1, t);
			}
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
	
	removingOfTheList(variableOfRemoving1);
	removingOfTheList(variableOfRemoving2);

	if (variableOfRemoving1 != list1)
	{
		removingOfTheList(list1);
	}
	
	if (variableOfRemoving2 != list2)
	{
		removingOfTheList(list2);
	}

	return listOfResult;
}

int main()
{
	fstream file;
	file.open("Phone book.txt", ios::in);

	bool choice = true;
	int numberOfChoice = 0;

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
	cout << "1 - sort by name\n2 - sort by number\nInput number of the option of sort: ";
	cin >> numberOfChoice;
	if (numberOfChoice == 1)
	{
		choice = false;
	}

	List *a = mergeSort(list, choice);
	print(a);
	removingOfTheList(a);
	removingOfTheList(list);
	counterOfMemoryPrint();
	file.close();
	return 0;
}