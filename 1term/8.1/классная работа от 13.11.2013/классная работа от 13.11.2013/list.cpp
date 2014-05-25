#include "list.h"
#include <iostream>
#include <stdlib.h>
#include <string.h>

using namespace std;
using namespace list;

struct list::ListElement
{
	ElementType value;
	ListElement *next;
	int repeating = 1;
};

struct list::List
{
	ListElement *head;
};

list::List *list::create()
{
	List *result = new List;
	result->head = NULL;
	return result;
}

void list::insert(list::List *list, ElementType value, Position position)
{
	ListElement *newElement = new ListElement;
	newElement->value = value;
	newElement->next = position->next;
	position->next = newElement;
}

void list::insertToHead(list::List *list, ElementType value)
{
	ListElement *newElement = new ListElement;
	newElement->value = new char[1000];
	strcpy(newElement->value, value);
	newElement->next = list->head;
	list->head = newElement;
}

void list::removeList(list::List *list)
{
	Position i = list->head;
	while( i != NULL)
	{
		ListElement *newElement = i;
		i = i->next;
		delete[] newElement->value;
		delete newElement;
	}
}


void list::insertToTheEnd(list::List *list, ElementType value, Position position)
{
	ListElement *newElement = new ListElement;
	newElement->value = value;
	newElement->next = NULL;
	position->next = newElement;
}

void list::remove(list::List *list, list::Position position)
{
	if (position == list->head)
	{
		list->head = list->head->next;
		delete position;
		return ;
	}
	Position i = first(list);
	while (next(list, i) != position)
	{
		i = next(list, i);
	}
	i->next = position->next;
	delete position;
}

Position list::first(List *list)
{
	return list->head;
}

Position list::end(List *list)
{
	return NULL;
}

Position list::next(List *list, Position position)
{
	return position->next;
}

ElementType list::valueOnPosition(List *list, Position position)
{
	return position->value;
}

bool list::exist(List *list, ElementType value)
{
	ListElement *position = list->head;
	while (position != NULL)
	{
		if (strcmp(position->value, value) == 0)
		{
			return true;
		}
		else
		{
			position = position->next;
		}
	}
	return false;
}

list::Position list::positionOfElement(List *list, ElementType value)
{
	Position position = list->head;
	while (position != NULL)
	{
		if (strcmp(position->value, value) == 0)
			return position;
		else
		{
			position = position->next;
		}
	}
	return NULL;
}

void list::printOfTheList(List* list)
{
	if (list->head == nullptr)
	{
		return;
	}

	Position positionOfTheSearch = list->head;
	Position positionOfPointer = list->head;

	if (positionOfTheSearch->next == nullptr)
	{
		cout << positionOfTheSearch->value << ' ' << positionOfTheSearch->repeating << endl;
		return;
	}

	while (positionOfTheSearch != nullptr)
	{
		if (positionOfTheSearch == nullptr)
		{
			return;
		}

		if (positionOfTheSearch->next != nullptr)
		{
			positionOfPointer = positionOfTheSearch->next;
		}
		else
		{
			break;
		}
		
		while (positionOfPointer != nullptr)
		{
			if (strcmp(positionOfPointer->value, positionOfTheSearch->value) == 0)
			{
				Position removingElement = positionOfPointer;
				++positionOfTheSearch->repeating;
				if (positionOfPointer->next != nullptr)
				{
					positionOfPointer = positionOfPointer->next;
				}
				else
				{
					positionOfPointer = nullptr;
				}
				remove(list, removingElement);
			}
			else
			{
				if (positionOfPointer->next != nullptr)
				{
					positionOfPointer = positionOfPointer->next;
				}
				else
				{
					positionOfPointer = nullptr;
				}
			}
		}

		if (positionOfTheSearch->next != nullptr)
		{
			positionOfTheSearch = positionOfTheSearch->next;
		}
	}

	if (positionOfTheSearch->next == nullptr)
	{
		positionOfPointer = list->head;
		while (positionOfPointer->next != nullptr)
		{
			cout << positionOfPointer->value << ' ' << positionOfPointer->repeating << endl;
			positionOfPointer = positionOfPointer->next;
		}
		cout << positionOfPointer->value << ' ' << positionOfPointer->repeating << endl;
		return;
	}
}