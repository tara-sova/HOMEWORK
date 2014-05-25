#include <iostream>
#include <math.h>

using namespace std;

int factorial(int number)
{
	if (number == 0)
	{
		return 1;
	}
	else
	{ 
		number = number * factorial(number - 1);
		return number;
	}
}

int injection(int m, int n)
{
	if (n >= m)
	{
		return factorial(n) / factorial(n - m);
	}
	else
	{
		return 0;
	}
}

int bijection(int m, int n)
{
	if (n == m)
	{
		return factorial(n);
	}
	else
	{
		return 0;
	}
}

int surjection(int m, int n)
{
	int sum = 0;
	for (int i = 0; i < n; ++i)
	{
		sum = sum + (pow(-1, i) * factorial(n) * pow(n - i, m) / (factorial(i) * factorial(n - i)));
	}
	return sum;
}

int mapping(int m, int n)
{
	return pow(n, m);
}

int main()
{
	cout << "Please, input meaning of m and n: ";
	int m = 0;
	int n = 0;
	cin >> m;
	cin >> n;
	cout << "The number of injection: " << injection(m, n) << endl;
	cout << "The number of bijection: " << bijection(m, n) << endl;
	cout << "The number of surjection: " << surjection(m, n) << endl;
	cout << "The number of mapping: " << mapping(m, n) << endl;
    return 0;
}