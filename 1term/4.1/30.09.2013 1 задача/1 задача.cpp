#include <stdio.h>
#include <math.h>
#include <iostream>
#include <stdlib.h>
#include <locale.h>

using namespace std;

void decToBin(int number, int mas[])
{
	int mask = 1;
	for (int i = 0; i < sizeof(int) * 8; ++i)
	{
		mas[i] = number & mask;
		if (mas[i] != 0)
		{
			mas[i] = 1;
		}
		mask = mask << 1;
	}

}

void sum(int number1[], int number2[], int result[])
{
	for (int i = 0; i < sizeof(int) * 8; ++i)
	{
		if (number1[i] + number2[i] == 0)
		{
			result[i] = 0;
		}
		if (number1[i] + number2[i] == 1)
		{
			result[i] = 1;
		}
		if (number1[i] + number2[i] == 2)
		{
			result[i] = 0;
			if ((i + 1) != sizeof (int) * 8)
			{
				number1[i + 1] = number1[i + 1] + 1;
			}
		}
		if (number1[i] + number2[i] == 3)
		{
			result[i] = 1;
			if ((i + 1) != sizeof (int) * 8)
			{
				number1[i + 1] = number1[i + 1] + 1;
			}
		}
	}

}


int main()
{
  	setlocale(LC_ALL, "rus");
	int firstNumber = 0;
	int secondNumber = 0;
	printf("Введите первое число: ");
	scanf_s("%d", &firstNumber);
	printf("Введите второе число: ");
	scanf_s("%d", &secondNumber);
	int mask1 = 1;
	int mask2 = 1;
	int result1[sizeof (int) * 8];
	decToBin(firstNumber, result1);
	printf("Двоичное представление первого числа: \n");
    for (int i = sizeof(int) * 8 - 1; i >= 0; --i)
	{
		printf("%d ", result1[i]);
	}
	printf("\n");

	int result2[sizeof (int) * 8];
	decToBin(secondNumber, result2);
	printf("Двоичное представление второго числа: \n");
	for (int i = sizeof(int) * 8 - 1; i >= 0; --i)
	{
		printf("%d ", result2[i]);
	}

	printf("\n\n\n");


	int resultOfOurAmazingOpertion[sizeof (int) * 8];
	sum(result1, result2, resultOfOurAmazingOpertion);
	printf("Результат побитового сложения: \n");
	for (int i = sizeof(int) * 8 - 1; i >= 0; --i)
	{
		printf("%d ", resultOfOurAmazingOpertion[i]);
	}

	printf("\n");

	int resultOfOurSuperAmazingOpertion = 0;

	int power = 1;
	for (int i = 0; i < sizeof(int) * 8; ++i)
	{
		if (resultOfOurAmazingOpertion[i] == 1)
		{
			resultOfOurSuperAmazingOpertion = resultOfOurSuperAmazingOpertion + power;
		}
		power *= 2;
	}
	printf("Перевод в десятичную систему счисления: ");
	printf("%d ", resultOfOurSuperAmazingOpertion);
	printf("\n");

	return 0;

}
