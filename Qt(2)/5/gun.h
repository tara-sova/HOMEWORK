#ifndef GUN_H
#define GUN_H
#include "mainwindow.h"
#include <QGraphicsScene>
#include <QGraphicsItem>
#include <QWidget>

class gun : public QGraphicsItem
{
public:
    gun();
    void paint(QPainter *painter, const QStyleOptionGraphicsItem *option, QWidget *widget);
    QRectF boundingRect() const;
    void BodyMoveDown();
    int getCorner();

private:
    int corner = 180;
};

#endif // GUN_H
