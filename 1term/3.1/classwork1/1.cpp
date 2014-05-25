#include <stdio.h>
#include "factorial.h"

int main()
{
	FILE * file = fopen
		("ololo.txt", "w");
	fwrite("ololo", 1, 6, file);
	fclose(file);

	return 0;
}



fscanf(inputFile, "%f %f %f %f %f %f", &a1, &a2, &a3, &a4, &a5, &a6);