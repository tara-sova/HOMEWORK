#include "list.h"
#include <iostream>
#include <stdlib.h>

using namespace std;
  
struct ListElement
{
	ElementType value;
	ListElement *next;
};

struct List
{
	ListElement *head;
};

List *create()
{
	List *result = new List;
	result->head = NULL;
	return result;
}

void insert(List *list, ElementType value, Position position)
{
	ListElement *newElement = new ListElement;
	newElement->value = value;
	newElement->next = position->next;
	position->next = newElement;
}

void insertToHead(List *list, ElementType value)
{
	ListElement *newElement = new ListElement;
	newElement->value = value;
	newElement->next = list->head;
	list->head = newElement;
}

void removeList(List *list)
{
	Position i = list->head;
	while( i != NULL)
	{
		ListElement *newElement = i;
		i = i->next;
		delete newElement;
	}
}


void insertToTheEnd(List *list, ElementType value, Position position)
{
	ListElement *newElement = new ListElement;
	newElement->value = value;
	newElement->next = NULL;
	position->next = newElement;
}

void remove(List *list, Position position)
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

void print(List *list)
{
	Position positionTemp = list->head;
	while (positionTemp != NULL)
	{
		cout << positionTemp->value << " ";
		positionTemp = positionTemp->next;
	}
	cout << endl;
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

ElementType valueOnPosition(List *list, Position position)
{
	return position->value;
}