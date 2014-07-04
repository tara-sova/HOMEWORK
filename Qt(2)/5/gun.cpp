#include "gun.h"
#include "mainwindow.h"
#include <QGraphicsScene>
#include <QGraphicsView>
#include <QGraphicsItem>
#include <QWidget>


gun::gun()
{
}

QRectF gun::boundingRect() const
{
    return QRectF(11, 22, 82, 50);
}

void gun::BodyMoveDown()
{
    corner = corner + 5;
}

void gun::paint(QPainter *painter, const QStyleOptionGraphicsItem *option, QWidget *widget)
{
    painter->drawEllipse(11, 360, 100, 100);

    painter->setTransform(QTransform().translate(55, 390).rotate(corner).translate(-55, -390));

    painter->drawRect(55, 390, 10, 100);

}

int gun::getCorner()
{
    return this->corner;
}


