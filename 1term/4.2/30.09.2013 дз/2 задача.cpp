#include <stdio.h>
#include <iostream>
#include <fstream>
#include "qsort.h"

using namespace std;

void printArray(int s[], int size)
{
	for (int i = 0; i < size; ++i)
		printf("%d ", s[i]);
}

int searchOfMostOftenElement(int massive[], int n)
{
	int maximum1 = 0;
	int maximum2 = 0;
	int countOfElements1 = 0;
	int countOfElements2 = 0;
	int i = 0; 
	while (i < n)
	{
		if (massive[i] != maximum1)
		{
			if (countOfElements2 < countOfElements1)
			{
				maximum2 = maximum1;
				countOfElements2 = countOfElements1;
			}
			maximum1 = massive[i];
			countOfElements1 = 1;
		}
		else
		{
			++countOfElements1;
		}
		++i;

	}
	if (countOfElements1 > countOfElements2)
	{
		return maximum1;
	}
	else
	{
		return maximum2;
	}
}

int main()
{
	int *massive = new int[5000];
	int n = 0;
	fstream fs("File.txt");
	fs >> n;
	printf("There are %d elements in our massive\n", n);
	printf("Our massive: ");
	for (int i = 0; i < n; i++)
	{
		fs >> massive[i];
		printf("%d ", massive[i]);
	}
	qsort(massive, 0, n - 1);
	printf("\n");
	printf("Qsorted massive: ");
	printArray(massive, n);
	printf("\n");
	printf("The most often seen element is: ");
	int value = searchOfMostOftenElement(massive, n);
	printf("%d", value);
	printf("\n");
	delete[] massive;
	return 0;
}