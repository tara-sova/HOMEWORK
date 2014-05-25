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

int search(int mas[], int size, int number)
{
	    int left = 0;
		int right = size - 1;
		while ((right - left) > 1)
		{
			int avg = (right + left) / 2;
			if (number > mas[avg])
			{
				left = avg;
			}
			else
			{
				right = avg;
			}
		}
		if ((number == mas[right]) || (number == mas[left]))
		{
			return true;
		}
		else
		{
			return false;
		}
}


int main()
{
	srand(56);

	int *massive = new int[5000];
	int n = 0;
	printf("Input n: ");
	scanf_s("%d", &n);
	
	for (int i = 0; i < n; ++i)
	{
		massive[i] = 0;
	}
	
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
	int k = 0;
	printf("Input k: ");
	scanf_s("%d", &k);
	for (int i = 0; i < k; ++i)
	{
		int left = 0;
		int right = n - 1;
		int number = rand() % 10;
		printf("Our number is %d\n", number);
		int result = search(massive, n, number);
		if (result == true)
		{
			printf("%d is here\n", number);
		}
		else
		{
			printf("%d is NOT here\n", number);
		}
	}
	delete[] massive;
	return 0;
}