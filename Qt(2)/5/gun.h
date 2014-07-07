#ifndef GUN_H
#define GUN_H
#include "mainwindow.h"
#include <QGraphicsScene>
#include <QGraphicsItem>
#include <QWidget>

class Gun : public QGraphicsItem
{
public:
    Gun();
    void paint(QPainter *painter, const QStyleOptionGraphicsItem *option, QWidget *widget);
    QRectF boundingRect() const;
    void bodyMoveDown();
    void bodyMoveUp();
    int getCorner();

private:
    int mCorner = 180;
};

#endif // GUN_H
