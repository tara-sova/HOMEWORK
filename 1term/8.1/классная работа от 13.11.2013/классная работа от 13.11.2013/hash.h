#pragma once
#include "list.h"

namespace hash
{
	struct HashTable;

	HashTable *createHashTable();

	void deleteHashTable(HashTable *hashTable);
	void insertToHashTable(HashTable *hashTable, list::ElementType newElement);
	bool exist(HashTable *hashTable, list::ElementType element);
	void remove(HashTable *hashTable, list::ElementType element);
	void printHashTable(HashTable *hashTable);
}