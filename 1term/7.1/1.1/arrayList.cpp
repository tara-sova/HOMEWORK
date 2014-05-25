#include "arrayList.h"
#include <iostream>
#include <stdlib.h>
#include <string.h>
#include <stdio.h>
#include <fstream>

using namespace std;


struct List
{
	NumberType number[100];
	Position last;
};

Position first(List *list)
{
	return NULL;
}

Position end(List *list)
{
	return (list->last + 1);
}

Position next(List *list, Position position)
{
	return (position + 1);
}

List *create()
{
	List *result = new List;
	result->last = -1;
	return result;
}

void removeList(List *list)
{
	delete list;
}

void insert(List *list, NumberType phone)
{
	++list->last;
	list->number[list->last] = phone;
}


NumberType getValue(List *list, Position i)
{
	return list->number[i];
}

