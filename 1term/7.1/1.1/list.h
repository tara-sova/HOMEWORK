#pragma once

struct List;

typedef int ElementType;

struct ListElement;
typedef ListElement* Position;

List *create();
void insert(List* list, ElementType value);
Position first(List *list);
Position end(List *list);
Position next(List *list, Position position);
ElementType getValue(List* list, Position position);
void removeList(List *list);