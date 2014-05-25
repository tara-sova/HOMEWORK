#include "tree.h"
#include <iostream>

using namespace std;

struct ElementOfTree
{
	Element value;
	ElementOfTree *left;
	ElementOfTree *right;
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

void insertElement(Tree* tree, Element value)
{
	ElementOfTree *pointerOfValue;
	ElementOfTree *newElement = new ElementOfTree;
	pointerOfValue = tree->head;

	newElement->value = value;
	newElement->right = nullptr;
	newElement->left = nullptr;

	if (pointerOfValue == nullptr)
	{
		tree->head = newElement;
		return;
	}
	
	while (true)
	{
		if (pointerOfValue->value == value)
		{
			delete newElement;
			return;
		}
		if (pointerOfValue->value < value)
		{
			if (pointerOfValue->right == nullptr)
			{
				pointerOfValue->right = newElement;
				return;
			}

			pointerOfValue = pointerOfValue->right;
		}
		else
		{
			if (pointerOfValue->left == nullptr)
			{
				pointerOfValue->left = newElement;
				return;
			}
			pointerOfValue = pointerOfValue->left;
		}
	}
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

	/*ElementOfTree *pointerOfRemovingElement;
	pointerOfRemovingElement = pointerOfValue;*/

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
			ElementOfTree *pointerOfRemoving;
			pointerOfRemoving = pointerOfValue;
			pointerOfValue = pointerOfValue->right;
			while (pointerOfValue->left != nullptr)
			{
				pointerOfValue = pointerOfValue->left;
			}

			int a = pointerOfValue->value;
			removeElement(tree, pointerOfValue->value);
			pointerOfRemoving->value = a;
		}
	}

	if (pointerOfParent->left == pointerOfValue)
	{
		if ((pointerOfValue->right != nullptr) && (pointerOfValue->left == nullptr))
		{
			pointerOfParent->left = pointerOfValue->right;
			delete pointerOfValue;
		}
		else if ((pointerOfValue->right == nullptr) && (pointerOfValue->left != nullptr))
		{
			pointerOfParent->left = pointerOfValue->left;
			delete pointerOfValue;
		}
		else if ((pointerOfValue->right == nullptr) && (pointerOfValue->left == nullptr))
		{
			pointerOfParent->left = nullptr;
			delete pointerOfValue;
		}
		else if ((pointerOfValue->right != nullptr) && (pointerOfValue->left != nullptr))
		{
			ElementOfTree *pointerOfRemoving;
			pointerOfRemoving = pointerOfValue;
			pointerOfValue = pointerOfValue->right;
			while (pointerOfValue->left != nullptr)
			{
				pointerOfValue = pointerOfValue->left;
			}

			int a = pointerOfValue->value;
			removeElement(tree, pointerOfValue->value);
			pointerOfRemoving->value = a;
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
		recursiveAscendingOutput(element->left);
	}
	cout << element->value << endl;
    if (element->right != nullptr)
	{
		recursiveAscendingOutput(element->right);
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
		recursiveDescendingOutput(element->right);
	}
	cout << element->value << endl;
	if (element->left != nullptr)
	{
		recursiveDescendingOutput(element->left);
	}
}

void outputDescending(Tree *tree)
{
	if (tree->head != nullptr)
	{
		recursiveDescendingOutput(tree->head);
	}
}
