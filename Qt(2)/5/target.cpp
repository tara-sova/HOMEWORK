#include "target.h"
#include "mainwindow.h"
#include <QGraphicsScene>
#include <QGraphicsItem>
#include <QWidget>
#include "gun.h"
#include <QTimer>
#include <QrectF>
#include <QGraphicsView>

target::target()
{
}

QRectF target::boundingRect() const
{
    return QRectF(11, 22, 82, 50);
}

void target::paint(QPainter *painter, const QStyleOptionGraphicsItem *option, QWidget *widget)
{
     painter->drawEllipse(750, 50, 60, 60);
}
