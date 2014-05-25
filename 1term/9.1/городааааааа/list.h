#pragma once

typedef int ElementType;

struct List;
struct ListElement;

typedef ListElement *Position;

List *create();

void insert(List *list, ElementType value, Position positive);
void insertToHead(List *list, ElementType value);
void insertToTheEnd(List *list, ElementType value, Position position);
void remove(List *list, Position position);
void print(List *list);
Position first(List *list);
Position end(List *list);
Position next(List *list, Position position);
ElementType valueOnPosition(List *list, Position position);
void removeList(List *list);

void inputVertexNumber(List* list, int number);
bool isItCapital(List* list[], int vertex, int k);
void addVertexToList(List* list[], int counter, int k, int minvertex);