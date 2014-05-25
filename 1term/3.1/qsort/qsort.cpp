#include<stdio.h>
#include<iostream>

void printArray(int s[], int size)
{
	for (int i = 0; i < size; ++i)
		printf("%d ", s[i]);
}

void insertionSort(int massive[], int l, int r)
{
	for (int i = l + 1; i <= r; ++i)
	{
		for (int k = i; k > l; --k)
		{
			if (massive[k] < massive[k - 1])
			{
				int t = massive[k];
				massive[k] = massive[k - 1];
				massive[k - 1] = t;
			}
		}
	}
}

void qsort(int a[], int l, int r)
{
	if ((r - l + 1) >= 10)
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
		qsort(a, l, r1);
		qsort(a, l1, r);
	}
	else
	{
		insertionSort(a, l, r);
	}
}

int main()
{
	int *massive = new int[100];
	int countOfElements = 100;
	int n = 100;
	printf("Random massive: ");
	for (int i = 0; i < n; ++i)
	{
		massive[i] = rand() % 10;
		printf("%d ", massive[i]);
	}
	if (n >= 10)
	{
		qsort(massive, 0, n - 1);
	}
	else
	{
		insertionSort(massive, 0, n - 1);
	}
	printf("\n");
	printf("Qsorted massive: ");
	printArray(massive, n);

}