#include<stdio.h>
#include<iostream>

void printArray(int s[], int size)
{
	for (int i = 0; i < size; ++i)
		printf("%d ", s[i]);
}

void qsort(int a[], int l, int r)
{
	if (l < r)
	{
		int l1 = l;
		int r1 = r;
		int d = a[l];

		while (l1 < r1)
		{

			while (a[l1] <= d && l1 < r)
			{
				++l1;
			}
			while (a[r1] >= d && r1 > l)
			{
				--r1;
			}
			if (r1 > l1)
			{
				int t = a[l1];
				a[l1] = a[r1];
				a[r1] = t;
			}
		}
		int t = a[l];
		a[l] = a[r1];
		a[r1] = t;
		qsort(a, l, r1 - 1);
		qsort(a, r1 + 1, r);
	}
}

int main()
{
	srand(96);

	int *massive = new int[5000];
	int n = 0;
	printf("Input count of massives's elements: ");
	scanf_s("%d", &n);
	massive[n] = { 0 };
	printf("Random massive: ");
	for (int i = 0; i < n; ++i)
	{
		massive[i] = rand() % 10;
		printf("%d ", massive[i]);
	}
	qsort(massive, 0, n - 1);
	printf("\n");
	printf("Qsorted massive: ");
	printArray(massive, n);
	printf("\n");
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
		printf("The most often seen element is: %d\n", maximum1);
	}
	else
	{
		printf("The most often seen element is: %d\n", maximum2);
	}
	return 0;
}