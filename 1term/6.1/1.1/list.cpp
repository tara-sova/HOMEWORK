#include "list.h"
#include <iostream>
#include <stdlib.h>

using namespace std;
int counterOfMemory = 0;

struct List
{
	ListElement *head;
};

struct ListElement
{
	ElementType value;
	ListElement *next;
	Position last;
};


List *create()
{
	++counterOfMemory;
	List *result = new List;
	result->head = nullptr;
	return result;
}

void insert(List* list, ElementType value)
{
	ListElement *newElement = new ListElement;
	ListElement *result = new ListElement;
	newElement->value = value;
	newElement->next = nullptr;
	if (list->head == nullptr)
	{
		list->head = newElement;
	}
	else
	{
		result = list->head;
		while (result->next != nullptr)
		{
			result = result->next;
		}
		result->next = newElement;
	}
}

Position first(List *list)
{
	return list->head;
}

Position end(List *list)
{
	return NULL;
}

Position next(List *list, Position position)
{
	return position->next;
}

ElementType getValue(Position position)
{
	return position->value;
}

void removingOfTheList(List *list)
{
	--counterOfMemory;
	while (list->head != NULL)
	{
		Position a = list->head;
		list->head = list->head->next;
		delete a;
	}
	delete list;
}

void counterOfMemoryPrint()
{
	cout << counterOfMemory << endl;
}