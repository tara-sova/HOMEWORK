#include <iostream>
#include <fstream>

using namespace std;

int symbolClass(char element)
{
	if (element == '/')
	{
		return 1;
	}
	if (element == '*')
	{
		return 2;
	}
	return 0;
}

int main()
{
	fstream matrix("matrix.txt");

	int matrixOfMoves[4][3];
	char element = ' ';

	for (int j = 0; j < 4; ++j)
	{
		for (int i = 0; i < 3; ++i)
		{
			matrix >> element;
			matrixOfMoves[j][i] = element - '0';
		}
	}

	matrix.close();

	fstream text("text.txt");
	int state = 0;
	bool signOfTheFirstSlashSymbol = false;
	bool beginCommentFlag = false;
	while (!text.eof())
	{
		element = text.get();
		int y = symbolClass(element);
		state = matrixOfMoves[state][symbolClass(element)];
		if (state == 2)
		{
			beginCommentFlag = false;
			if (signOfTheFirstSlashSymbol == false)
			{
				cout << "/";
			}
			signOfTheFirstSlashSymbol = true;
			cout << element;
		}
		if (state == 3)
		{
			beginCommentFlag = true;
			cout << element;
		}
		if ((state == 0) && (beginCommentFlag))
		{
			cout << '/';
			beginCommentFlag = false;
			signOfTheFirstSlashSymbol = false;
		}
	}
	cout << endl;
	text.close();
	return 0;
}