#include <iostream>
#include <fstream>
#include "list.h"
#include <math.h>

using namespace std;

bool add(int **doubleMassive, int **country, int n, int capital, bool *usedTown)
{
	int min = 10000;
	int vertex = -1;
	for (int i = 0; i < n; ++i)
	{
		if (country[i][0] == capital)
		{
			for (int j = 0; j < n; ++j)
			{
				if ((doubleMassive[i][j] != 0) && (!usedTown[j]) && doubleMassive[i][j] < min)
				{
					min = doubleMassive[i][j];
					vertex = j;
				}
			}
		}
	}
	if (vertex != -1)
	{
		usedTown[vertex] = true;
		country[vertex][0] = capital;
		return true;
	}
	return false;
}

int main()
{
	fstream text("text.txt");

	int n = 0;
	text >> n;

	int **doubleMassive = new int*[n];
	for (int i = 0; i < n; ++i)
	{
		doubleMassive[i] = new int[n];
	}

	for (int i = 0; i < n; ++i)
	{
		for (int j = 0; j < n; ++j)
		{
			doubleMassive[i][j] = 0;
		}
	}

	int m = 0;
	text >> m;
	for (int t = 0; t < m; ++t)
	{
		int i = 0;
		int j = 0;
		int length = 0;
		text >> i;
		text >> j;
		text >> length;
		doubleMassive[i][j] = length;
		doubleMassive[j][i] = length;
	}

	int k = 0;
	text >> k;

	int **country = new int*[n];
	for (int i = 0; i < n; ++i)
	{
		country[i] = new int[n];
	}

	for (int i = 0; i < n; ++i)
	{
		for (int j = 0; j < n; ++j)
		{
			country[i][j] = -1;
		}
	}

	bool *usedTown = new bool[n];
	for (int i = 0; i < n; ++i)
	{
		usedTown[i] = false;
	}

	for (int i = 0; i < k; ++i)
	{
		int capital = 0;
		text >> capital;
		country[capital][0] = capital;
		usedTown[i] = true;
	}

	int numberOfFreeVertex = n - k;
	while (numberOfFreeVertex > 0)
	{
		for (int i = 0; i < k; ++i)
		{
			if (add(doubleMassive, country, n, country[i][0], usedTown))
			{
				numberOfFreeVertex = numberOfFreeVertex - 1;
			}
		}
	}

	for (int i = 0; i < k; ++i)
	{
		for (int j = 0; j < n; ++j)
		{
			if (country[j][0] == i)
			{
				cout << j << ' ';
			}
		}
		cout << endl;
	}

	for (int i = 0; i < n; ++i)
	{
		delete[] doubleMassive[i];
	}

	for (int i = 0; i < n; ++i)
	{
		delete[] country[i];
	}

	text.close();
	delete[] doubleMassive;
	delete[] country;
	return 0;
}