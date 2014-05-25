#pragma once

typedef int NumberType;
typedef char *NameType;
typedef int Position;
typedef int ElementType;

struct List;

List *create();
void insert(List *list, NumberType phone);
Position first(List *list);
Position end(List *list);
Position next(List *list, Position position);
NumberType getValue(List *list, Position i);
void removeList(List *list);
