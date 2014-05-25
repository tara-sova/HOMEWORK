#pragma once

typedef int NumberType;
typedef char *NameType;
typedef int Position;
typedef int ElementType;

struct List;

// creates new empty list
List *create();
// we make an insert (name, phone number)
void insert(List *list, NameType who, NumberType phone); 
// we get name by position
NameType getName(List *list, Position i);
// we get number by position
NumberType getNumber(List *list, Position i);
// we search name by phone number
NameType searchNameByNumber(List *list, NumberType number);
// we search phone number by name
NumberType searchNumberByName(List *list, NameType name);
// function for deleting of list
void removeList(List *list);
