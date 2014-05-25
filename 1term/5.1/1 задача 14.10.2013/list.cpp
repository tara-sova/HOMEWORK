#include "list.h"
#include <iostream>
#include <stdlib.h>
#include <string.h>
#include <stdio.h>
#include <fstream>

using namespace std;


struct List
{
	NumberType number[100];
	NameType names[100];
	Position last;
};

List *create()
{
	List *result = new List;
	result->last = -1;
	for (int i = 0; i < 100; ++i)
	{
		result->names[i] = new char[255];
	}
	return result;

}

void removeList(List *list)
{
	for (int i = 0; i < 100; ++i)
	{
		delete[] list->names[i];
	}
	delete list;
}

void insert(List *list, NameType who, NumberType phone)
{
	++list->last;
	list->number[list->last] = phone;
	strcpy(list->names[list->last], who);
}

NameType getName(List *list, Position i)
{
	NameType getNameStr = new char[255];
	strcpy(getNameStr, list->names[i]);
	return getNameStr;
}

NumberType getNumber(List *list, Position i)
{
	return list->number[i];
}

NumberType searchNumberByName(List *list, NameType name)
{
	for (Position i = 0; i < 100; ++i)
	{
		if (strcmp(name, getName(list, i)) == 0)
		{
			return getNumber(list, i);
		}
	}
	return NULL;
}

NameType searchNameByNumber(List *list, NumberType number)
{
	for (Position i = 0; i < 100; ++i)
	{
		if (number == getNumber(list, i))
		{
			return getName(list, i);
		}
	}
	return NULL;
}



