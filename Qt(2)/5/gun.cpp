#include "gun.h"
#include "mainwindow.h"
#include <QGraphicsScene>
#include <QGraphicsView>
#include <QGraphicsItem>
#include <QWidget>


Gun::Gun(){}

QRectF Gun::boundingRect() const
{
    return QRectF(11, 22, 82, 50);
}

void Gun::bodyMoveDown()
{
    mCorner = mCorner + 5;
}

void Gun::bodyMoveUp()
{
    mCorner = mCorner - 5;
}

void Gun::paint(QPainter *painter, const QStyleOptionGraphicsItem *option, QWidget *widget)
{
    painter->drawEllipse(11, 360, 100, 100);
    painter->setTransform(QTransform().translate(55, 390).rotate(mCorner).translate(-55, -390));
    painter->drawRect(55, 390, 10, 100);

}

int Gun::getCorner()
{
    return mCorner;
}


