#ifndef TARGET_H
#define TARGET_H
#include "mainwindow.h"
#include <QGraphicsScene>
#include <QGraphicsItem>
#include <QWidget>
#include "gun.h"
#include "shell.h"

class target : public QGraphicsItem
{
public:
    target();
    void paint(QPainter *painter, const QStyleOptionGraphicsItem *option, QWidget *widget);
    QRectF boundingRect() const;
};

#endif // TARGET_H
