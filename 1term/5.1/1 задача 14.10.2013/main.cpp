#include "list.h"
#include <iostream>
#include <stdlib.h>
#include <string.h>
#include <fstream>

using namespace std;

int main()
{
	const int stringLength = 255;

	List *list = create();

	fstream file;
	file.open("Phone book.txt", ios::app | ios::in);

	while (!file.eof())
	{
		char who[stringLength];
		NumberType phone = 0;
		file >> who;
		file >> phone;
		insert(list, who, phone);
	}
	file.close();
	file.open("Phone book.txt", ios::app);

	printf("Please, input number of the command:\n0 - exit\n1 - add a new contact(name and phone number)\n2 - find a name by phone number\n3 - find a phone number by name\n");
	
	int inputNumber = -1;
	while (inputNumber != 0)
	{
		scanf_s("%d", &inputNumber);

		if (inputNumber == 1)
		{
			char name[stringLength];
			NumberType phoneNumber;
			printf("Please, input contact information (name and number): ");
			cin >> name;
			cin >> phoneNumber;
			insert(list, name, phoneNumber);
			file << "\n" << name << " " << phoneNumber;
		}

		if (inputNumber == 2)
		{
			NumberType phoneNumber;
			printf("Please, input phone number: ");
			scanf_s("%d", &phoneNumber);
			searchNameByNumber(list, phoneNumber);
			if (searchNameByNumber(list, phoneNumber) == NULL)
			{
				printf("This contact doesn't exist\n");
			}
			else
			{
				printf("Owner of %d phone number is: %s\n", phoneNumber, searchNameByNumber(list, phoneNumber));
			}
		}

		if (inputNumber == 3)
		{
			char name[stringLength];
			printf("Please, input name: ");
			cin >> name;
			searchNumberByName(list, name);
			if (searchNumberByName(list, name) == NULL)
			{
				printf("This contact doesn't exist\n");
			}
			else
			{
				printf("%s's phone number is: %d\n", name, searchNumberByName(list, name));
			}
		}
	}
	removeList(list); 
	file.close();
	return 0;
}