#include "shell.h"
#include "gun.h"
#include "mainwindow.h"
#include <QGraphicsScene>
#include <QGraphicsView>
#include <QGraphicsItem>
#include <QWidget>
#include "math.h"
#include <qmath.h>
#include <QDebug>

shell::shell(int corner)
{
    position = corner;
    V.setX(V.x() + 1);
    //p += QPoint(1, 0);
    //p.rx()++;
}

QRectF shell::boundingRect() const
{
    return QRectF(11, 22, 82, 50);
}

void shell::shellMovesDown()
{
    position = position + 5;
    angle = angle - 5;
}

void shell::paint(QPainter *painter, const QStyleOptionGraphicsItem *option, QWidget *widget)
{
    painter->drawRect(10, 21, 840, 439);

    QTransform transform;
    transform.rotate(position);
    V = transform.map(V);

    painter->setTransform(QTransform().translate(x, y).rotate(position).translate(-x, -y));
    painter->drawEllipse(55, 480, 10, 10);
    /*
    painter->setTransform(QTransform().translate(0, 0).rotate(position).translate(0, 0));
    V;
    */
}

void shell::shellLetsOut()
{
    qreal x1 = x;
    qreal y1 = y;

    if((rect->contains(x1, y1)) && (!condition))
    {
        /*
        int u = 2;
        int t = 4;
        int g = 10;
        double newAngle = angle * 3.14 / 180;

        qDebug() << qSin(newAngle) << newAngle;
        t = 2 * u * sin(newAngle) / g;

        x = u * t * cos( - newAngle);
        y = u * t * sin( - newAngle) - 0,5 * g * t * t;
        */
        x = x + x * V.rx();
        y = y + y * V.ry();
        V.ry() += 10;
    }
    else
    {
        x = 55;
        y = 390;
        condition = true;
    }
}

void shell::changeCondition(bool change)
{
    condition = change;
}

bool shell::returnCondition()
{
    return condition;
}

void shell::changeVy()
{
    V.ry()= 0;
}
