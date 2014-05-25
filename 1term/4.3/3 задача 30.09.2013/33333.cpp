#include <stdio.h>
#include <iostream>
#include <fstream>
using namespace std;

int main()
{
	ifstream File;
	File.open("file.txt", ios::in);
	char *massive = new char[1000];
	int counter = 0;
	int i = 0;
	int j = 0;
	int counterInString = 0;
	while (!File.eof())
	{
		File.getline(massive, 255);
		while ((massive[j] != '\n') && (massive[j] != '\0'))
		{
			if ((massive[j] == ' ') || (massive[j] == '\t'))
			{
				counterInString = counterInString + 1;
			}
			++j;
		}
		if (counterInString == j)
		{
			++counter;
		}
		counterInString = 0;
		j = 0;
		++i;
	}
	i = i - counter;
	printf("The numbers of unempty strings is: %d\n", i);
	delete[] massive;
}