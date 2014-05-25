#include <stdio.h>
#include <iostream>
#include <string>
#include <cmath>

using namespace std;

int min(int n1, int n2)
{
	if (n1 > n2)
		return n2;
	else
	return n1;
}

int *suffics(string a)
{
	int lng = a.length();
	int *jump = new int[lng];
	for (int i = 1; i <= lng; i++)
	{
		jump[i - 1] = 2 * lng - i;
	}
	int test = lng;
	int target = lng + 1;
	int *link = new int[lng];
	while (test > 0)
	{
		link[test - 1] = target;
		while ((target <= lng) && (a[test - 1] != a[target - 1])) {
			jump[target - 1] = min(jump[target - 1], lng - test);
			target = link[target - 1];
		}
		test--;
		target--;
	}
	for (int i = 1; i <= target; i++)
	{
		jump[i - 1] = min(jump[i - 1], lng + target - i);
	}
	int temp = link[target - 1];
	while (target <= lng)
	{
		while (target <= temp)
		{
			jump[target - 1] = min(jump[target - 1], temp - target + lng);
			target = target + 1;
		}
		temp = link[temp - 1];
	}
	return jump;
}

int main()
{
	string a = "тарасоваполина";
	int *k = suffics(a);
	for (int i = 0; i != a.length(); i++)
	{
		cout << k[i] << " ";
	}
	delete[] k;
	return 0;
}