#pragma once

typedef int ElementType;

struct CycleList;

struct CycleListElement;

typedef CycleListElement* Position;

//�������� ������������ ������
CycleList *create();

//�������� � ����� ������
void insertToTheEnd(CycleList *cycleList, ElementType element);

//�������� ��������
void removeFromTheCycleList(CycleList *cycleList, Position position);

//�������� ������
void removeTheCycleList(CycleList *cycleList);

//��������� ������� 
Position next(Position position);

//���������� �������
Position previous(Position position);

//������� ������ ������
Position positionOfHead(CycleList *cycleList);

//�������� ��������
ElementType meaningOfElement(Position position);