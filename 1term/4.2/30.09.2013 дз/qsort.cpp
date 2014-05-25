#include "qsort.h"

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
