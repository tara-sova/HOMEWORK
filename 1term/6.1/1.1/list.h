#pragma once

struct List;

struct Record
{
	char name[50];
	int phoneNumber;
};

typedef Record ElementType;

struct ListElement;
typedef ListElement* Position;

List *create();
void insert(List* list, ElementType value);
Position first(List *list);
Position end(List *list);
Position next(List *list, Position position);
ElementType getValue(Position position);
void removingOfTheList(List *list);
void counterOfMemoryPrint();