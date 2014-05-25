#include "hash.h"
#include "list.h"
#include <string.h>

const int b = 10;
using namespace list;

struct hash::HashTable
{
	List *bucket[b];
};
hash::HashTable *hash::createHashTable()
{
	HashTable *hashTable = new HashTable;
	for (int i = 0; i < b; ++i)
	{
		hashTable->bucket[i] = create();
		/*return hashTable;*/
	}
	return hashTable;
}

void hash::deleteHashTable(HashTable *hashTable)
{
	for (int i = 0; i < b; ++i)
	{
		removeList(hashTable->bucket[i]);
	}
	delete hashTable;
}

int hashFunction(ElementType newElement)
{
	int sum = 0;
	for (int i = 0; i < strlen(newElement); ++i)
	{
		int temp = (int) newElement[i];
		sum = sum + temp * i * i * i;
	}
	sum = sum % b;
	return sum;
}

void hash::insertToHashTable(HashTable *hashTable, ElementType newElement)
{
	insertToHead(hashTable->bucket[hashFunction(newElement)], newElement);
}

bool hash::exist(HashTable *hashTable, ElementType element)
{
	return exist(hashTable->bucket[hashFunction(element)], element);
}
void hash::remove(HashTable *hashTable, ElementType element)
{
	remove(hashTable->bucket[hashFunction(element)], positionOfElement(hashTable->bucket[hashFunction(element)], element));
}

void hash::printHashTable(HashTable *hashTable)
{
	for (int i = 0; i < b; ++i)
	{
		printOfTheList(hashTable->bucket[i]);
	}
}