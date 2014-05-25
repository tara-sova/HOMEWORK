#pragma once

typedef char ElementType;

struct Queue;

Queue* create();
void removeQueue(Queue* queue);
void insertToTheEnd(Queue* queue, ElementType element);
ElementType removeFromHead(Queue* queue);
bool isEmpty(Queue* queue);