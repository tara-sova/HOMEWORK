#include "hash.h"
#include <iostream>
#include <fstream>

using namespace std;
using namespace hash;

int main()
{
	HashTable *hashTable = createHashTable();

	fstream text;
	text.open("Text.txt");

	char* word = new char[1000];
	
	while (!text.eof())
	{
		text >> word;
		insertToHashTable(hashTable, word);
	}
	printHashTable(hashTable);
	delete[] word;
	text.close();
	return 0;
}