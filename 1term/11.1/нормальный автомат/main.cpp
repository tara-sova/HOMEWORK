#include <iostream>

using namespace std;

bool isItNumber(char symbol)
{
	return ((symbol >= '0') && (symbol <= '9'));
}

int main()
{
	enum State { start, gettingFirstNumber, win, fail, seePoint, gettingSecondNumber, seeE, getSymbol, gettingThirdNumber};

	char symbol = ' ';
	State state = start;

	while (true)
	{
		if ((state != win) && (state != fail))
		{
			cin >> symbol;
		}
		switch (state)
		{
		case start:
			{
				if (isItNumber(symbol))
				{
					state = gettingFirstNumber;
				}
				else
				{
					state = fail;
				}
				break;
			}
		case gettingFirstNumber:
			{
				if (isItNumber(symbol))
				{
					state = gettingFirstNumber;
				}
				else if (symbol == '!')
				{
					state = win;
				}
				else if (symbol == '.')
				{
					state = seePoint;
				}
				else if (symbol == 'E')
				{
					state = seeE;
				}
				else
				{
					state = fail;
				}
				break;
			}
		case win:
			{
				cout << "Bingo" << endl;
				return 0;
			}
		case fail:
			{
				cout << "Life is a pain" << endl;
				return 0;
			}
		case seePoint:
			{
				if (isItNumber(symbol))
				{
					state = gettingSecondNumber;
				}
				else
				{
					state = fail;
				}
				break;
			}
		case gettingSecondNumber:
			{
				if (isItNumber(symbol))
				{
					state = gettingSecondNumber;
				}
				else if (symbol == '!')
				{
					state = win;
				}
				else if (symbol == 'E')
				{
					state = seeE;
				}
				else
				{
					state = fail;
				}
				break;
			}
		case seeE:
			{
				if ((symbol == '+') || (symbol == '-'))
				{
					state = getSymbol;
				}
				else if (isItNumber(symbol))
				{
					state = gettingThirdNumber;
				}
				else
				{
					state = fail;
				}
				break;
			}
		case getSymbol:
			{
				if (isItNumber(symbol))
				{
					state = gettingThirdNumber;
				}
				else
				{
					state = fail;
				}
				break;
			}
		case gettingThirdNumber:
			{
				if (isItNumber(symbol))
				{
					state = gettingThirdNumber;
				}
				else if (symbol == '!')
				{
					state = win;
				}
				else
				{
					state = fail;
				}
				break;
			}
		}
	}

	return 0;
}