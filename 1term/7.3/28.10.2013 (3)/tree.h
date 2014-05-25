#pragma once

typedef char Element;

struct ElementOfTree;
typedef ElementOfTree* Position;

struct Tree;

Tree *create();
void remove(Tree *tree);
void insertElement(Tree *tree, Position &position, Element value, bool typeOfElement);
void removeElement(Tree *tree, Element value);
bool exists(Tree *tree, Element value);
void outputDescending(Tree *tree);
void outputAscending(Tree *tree);
void goBack(Position &position);
ElementOfTree *outputOfTheHead(Tree *tree);
int calculateOfTheTree(Tree* tree);
