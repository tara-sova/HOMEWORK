#include "queue.h"
#include <stdlib.h>
#include <iostream>

using namespace std;

struct ElementOfQueue
{
	ElementType value;
	ElementOfQueue *next;
};

struct Queue
{
	ElementOfQueue *head;
	ElementOfQueue *last;
};

Queue* create()
{
	Queue *result = new Queue;
	result->head = NULL;
	result->last = NULL;
	return result;
}


void removeQueue(Queue* queue)
{
	while (!isEmpty(queue)) // (isEmpty(queue) != true)
	{
		removeFromHead(queue);
	}
	delete queue;
}

void insertToTheEnd(Queue* queue, ElementType element)
{
	ElementOfQueue *newElement = new ElementOfQueue;
	newElement->value = element;
	newElement->next = NULL;
	if (queue->last == NULL)
	{
		queue->last = newElement;
		queue->head = newElement;
	}
	queue->last->next = newElement;
	queue->last = queue->last->next;
//	queue->last = newElement;
}

ElementType removeFromHead(Queue* queue)
{
	ElementOfQueue *newHead = queue->head;
	if (queue->head == NULL)
	{
		cout << "Queue is empty" << endl;
		return 0;
	}
	queue->head = queue->head->next;
	if (queue->head == NULL)
	{
		queue->last = NULL;
	}
	ElementType value = newHead->value;
	delete newHead;
	return value;
}

bool isEmpty(Queue* queue)
{
	if ((queue->head == NULL) && (queue->last == NULL))
	{
		return true;
	}
	else
	{
		return false;
	}

//  return (queue->head == NULL) && (queue->last == NULL);
}