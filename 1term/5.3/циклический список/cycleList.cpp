#include "cycleList.h"

struct CycleList
{
	CycleListElement *head;
};

struct CycleListElement
{
	ElementType value;
	Position next;
	Position previous;
};

Position positionOfHead(CycleList *cycleList)
{
	return cycleList->head;
}

CycleList *create()
{
	CycleList *cycleList = new CycleList;
	cycleList->head = nullptr;
	return cycleList;
}

void insertToTheEnd(CycleList *cycleList, ElementType element)
{
	CycleListElement *newElement = new CycleListElement;
	newElement->value = element;
	if (cycleList->head != nullptr)
	{
		CycleListElement *beforeHead = cycleList->head->previous;
		newElement->next = cycleList->head;
		newElement->previous = beforeHead;
		beforeHead->next = newElement;
		cycleList->head->previous = newElement;
	}
	else
	{
		cycleList->head = newElement;
		newElement->next = newElement;
		newElement->previous = newElement;
	}
}

void removeFromTheCycleList(CycleList *cycleList, Position position)
{
	if (cycleList->head == nullptr)
	{
		return;
	}
	if (position->next == position)
	{
		cycleList->head = nullptr;
		delete position;
		return;
	}

	if (position == cycleList->head)
	{
		cycleList->head = cycleList->head->next;
	}
	position->next->previous = position->previous;
	position->previous->next = position->next;
	delete position;
}

void removeTheCycleList(CycleList *cycleList)
{
	while (cycleList->head != nullptr)
	{
		removeFromTheCycleList(cycleList, cycleList->head);
	}
	delete cycleList;
}

Position next(Position position)
{
	return position->next;
}

Position previous(Position position)
{
	return position->previous;
}

ElementType meaningOfElement(Position position)
{
	return position->value;
}