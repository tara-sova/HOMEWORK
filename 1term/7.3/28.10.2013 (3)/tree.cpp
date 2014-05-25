#include "tree.h"
#include <iostream>

using namespace std;

struct ElementOfTree
{
	ElementOfTree *parent;
	Element value;
	ElementOfTree *left;
	ElementOfTree *right;
	Element markOfThePrint = false;
};

struct Tree
{
	ElementOfTree *head;
};

Tree *create()
{
	Tree *tree = new Tree;
	tree->head = nullptr;
	return tree;
}

void removeRecursive(ElementOfTree *element)
{
	if (element->right != nullptr)
	{
		removeRecursive(element->right);
	}
	if (element->left != nullptr)
	{
		removeRecursive(element->left);
	}
	delete element;
}

void remove(Tree *tree)
{
	if (tree->head != nullptr)
	{
		removeRecursive(tree->head);
	}
	delete tree;
}

void removeElement(Tree *tree, Element value)
{
	ElementOfTree *pointerOfValue;
	pointerOfValue = tree->head;

	ElementOfTree *pointerOfParent;
	pointerOfParent = tree->head;

	ElementOfTree *previousPointer;
	previousPointer = tree->head;

	while (pointerOfValue->value != value)
	{
		if (pointerOfValue->value < value)
		{
			if (pointerOfValue->right != nullptr)
			{
				pointerOfParent = pointerOfValue;
				pointerOfValue = pointerOfValue->right;
			}
			else
			{
				return;
			}
		}
		else
		{
			if (pointerOfValue->left != nullptr)
			{
				pointerOfParent = pointerOfValue;
				pointerOfValue = pointerOfValue->left;
			}
			else
			{
				return;
			}
		}
	}

	if (pointerOfParent == pointerOfValue)
	{
		pointerOfValue = pointerOfValue->right;
		if (pointerOfValue == nullptr)
		{
			tree->head = pointerOfParent->left;
			delete pointerOfParent;
			return;
		}
		while (pointerOfValue->left != nullptr)
		{
			previousPointer = pointerOfValue;
			pointerOfValue = pointerOfValue->left;
		}
		if (pointerOfValue->right != nullptr)
		{
			previousPointer->left = pointerOfValue->right;
			pointerOfParent->value = pointerOfValue->value;
			delete pointerOfValue;

		}
		else
		{
			pointerOfParent->value = pointerOfValue->value;
			delete pointerOfValue;
			previousPointer->left = nullptr;
		}
		return;
	}

	ElementOfTree *pointerOfRemovingElement;
	pointerOfRemovingElement = pointerOfValue;

	if (pointerOfParent->right == pointerOfValue)
	{
		if ((pointerOfValue->right != nullptr) && (pointerOfValue->left == nullptr))
		{
			pointerOfParent->right = pointerOfValue->right;
			delete pointerOfValue;
		}
		else if ((pointerOfValue->right == nullptr) && (pointerOfValue->left != nullptr))
		{
			pointerOfParent->right = pointerOfValue->left;
			delete pointerOfValue;
		}
		else if ((pointerOfValue->right == nullptr) && (pointerOfValue->left == nullptr))
		{
			delete pointerOfValue;
			pointerOfParent->right = nullptr;
		}
		else if ((pointerOfValue->right != nullptr) && (pointerOfValue->left != nullptr))
		{
			while (pointerOfValue->left != nullptr)
			{
				pointerOfValue = pointerOfValue->left;
			}
			int a = pointerOfValue->value;
			removeElement(tree, pointerOfValue->value);
			pointerOfRemovingElement->value = a;
		}
	}

	if (pointerOfParent->left == pointerOfValue)
	{
		if ((pointerOfValue->right != nullptr) && (pointerOfValue->left == nullptr))
		{
			pointerOfParent->right = pointerOfValue->right;
			delete pointerOfValue;
		}
		else if ((pointerOfValue->right == nullptr) && (pointerOfValue->left != nullptr))
		{
			pointerOfParent->right = pointerOfValue->left;
			delete pointerOfValue;
		}
		if ((pointerOfValue->right == nullptr) && (pointerOfValue->left == nullptr))
		{
			delete pointerOfValue;
			pointerOfParent->right = nullptr;
		}
		else if ((pointerOfValue->right != nullptr) && (pointerOfValue->left != nullptr))
		{
			while (pointerOfValue->left != nullptr)
			{
				pointerOfValue = pointerOfValue->left;
			}
			int a = pointerOfValue->value;
			removeElement(tree, pointerOfValue->value);
			pointerOfRemovingElement->value = a;
		}
	}

}

bool exists(Tree *tree, Element value)
{
	ElementOfTree *pointerOfValue;
	pointerOfValue = tree->head;

	while (true)
	{
		if (pointerOfValue->value == value)
		{
			return true;
		}
		if (pointerOfValue->value < value)
		{
			pointerOfValue = pointerOfValue->right;

		}
		else
		{
			pointerOfValue = pointerOfValue->left;
		}
		if (pointerOfValue == nullptr)
		{
			return false;
		}
	}
}

void recursiveAscendingOutput(ElementOfTree *element)
{
	if (element->left != nullptr)
	{
		cout << '(' << ' ';
		recursiveAscendingOutput(element->left);
	}
	if ((element->value == '+') || (element->value == '-') || (element->value == '*') || (element->value == '/'))
	{
		cout << ' ' << element->value << ' ';
	}
	else
	{
		cout << element->value;
	}
	if (element->left != nullptr)
	{
		recursiveAscendingOutput(element->right);
		cout << ' ' << ')';
	}
}

void outputAscending(Tree *tree)
{
	if (tree->head != nullptr)
	{
		recursiveAscendingOutput(tree->head);
	}
}

void recursiveDescendingOutput(ElementOfTree *element)
{
	if (element->right != nullptr)
	{
		cout << '(' << ' ';
		recursiveDescendingOutput(element->right);
	}
	if ((element->value == '+') || (element->value == '-') || (element->value == '*') || (element->value == '/'))
	{
		cout << ' ' << element->value << ' ';
	}
	else
	{
		cout << element->value;
	}
	if (element->left != nullptr)
	{
		recursiveDescendingOutput(element->left);
		cout << ' ' << ')';
	}
}

void outputDescending(Tree *tree)
{
	if (tree->head != nullptr)
	{
		recursiveDescendingOutput(tree->head);
	}
}

void goBack(Position &position)
{
	position = position->parent;
}

void insertElement(Tree *tree, Position &position, Element value, bool typeOfElement)
{
	
	ElementOfTree *newElement = new ElementOfTree;
	newElement->value = value;
	newElement->left = nullptr;
	newElement->right = nullptr;
	newElement->parent = position;
	
	if (tree->head == nullptr)
	{
		tree->head = newElement;
		newElement->parent = nullptr;
		position = tree->head;
		return;
	}
	
	if (typeOfElement == true)
	{
		if (position->left == nullptr)
		{
			position->left = newElement;
			position = position->left;
		}
		else if (position->right == nullptr)
		{
			position->right = newElement;
			position = position->right;
		}
	}
	else
	{
		if (position->left == nullptr)
		{
			position->left = newElement;
		}
		else if (position->right == nullptr)
		{
			position->right = newElement;
		}
	}
}

int calculateRecursive(ElementOfTree *element)
{
	int a = 0;
	int b = 0;
	int c = 0;
	char p = (char) element->value;
	if (element->right != nullptr)
	{
		a = calculateRecursive(element->right);
	}
	if (element->left != nullptr)
	{
		b = calculateRecursive(element->left);
	}
	if ((p == '+') || (p == '-') || (p == '*') || (p == '/'))
	{
		if (p == '+')
		{
			c = a + b;
		}
		if (p == '-')
		{
			c = b - a;
		}
		if (p == '*')
		{
			c = a * b;
		}
		if (p == '/')
		{
			c = b / a;
		}
		return c;
	}
	else
	{
		return element->value - '0';
	}
}

int calculateOfTheTree(Tree* tree)
{
	int a = 0;
	if (tree->head != nullptr)
	{
		a = calculateRecursive(tree->head);
	}
	return a;
}
