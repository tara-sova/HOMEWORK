#pragma once

typedef int ElementType;

struct CycleList;

struct CycleListElement;

typedef CycleListElement* Position;

//создание циклического списка
CycleList *create();

//вставака в конец спичка
void insertToTheEnd(CycleList *cycleList, ElementType element);

//удаление элемента
void removeFromTheCycleList(CycleList *cycleList, Position position);

//удаление списка
void removeTheCycleList(CycleList *cycleList);

//следующая позиция 
Position next(Position position);

//предыдущая позиция
Position previous(Position position);

//позиция головы списка
Position positionOfHead(CycleList *cycleList);

//значение элемента
ElementType meaningOfElement(Position position);