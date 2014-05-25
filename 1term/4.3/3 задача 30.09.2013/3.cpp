/*
#include <stdio.h>
#include <iostream>
#include <fstream>
using namespace std;

int main()
{
	ifstream F;
	F.open("file.txt", ios::in);
	char *massive = new char[1000];
	int i = 0;
	if (F)
	{
		while (i < F.eof())
		{
			F >> massive[i];
			++i;
		}
	}
	int k = i;
	int t = 0;
	printf("k = %d\n", k);
	//int *massiveForCount = new int[1000];
	for (int j = 0; j <= i; ++j)
	{
		if ((massive[j] == ' ') || (massive[j] == '\n') || (massive[j] == '\t'))
		{
			t = t + 1;
		}
	}
	printf("t = %d\n", t);
	k = k - t;
	printf("%d\n", k);
}
*/