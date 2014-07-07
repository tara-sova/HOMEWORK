#include "target.h"
#include "mainwindow.h"
#include <QGraphicsScene>
#include <QGraphicsItem>
#include <QWidget>
#include "gun.h"
#include "shell.h"
#include <QTimer>
#include <QrectF>
#include <QGraphicsView>

Target::Target(){}

QRectF Target::boundingRect() const
{
    return QRectF(11, 22, 82, 50);
}

void Target::paint(QPainter *painter, const QStyleOptionGraphicsItem *option, QWidget *widget)
{
     painter->drawEllipse(750, 50, 60, 60);
     if (mTakeCheck == true){
         painter->setBrush(Qt::red);
         painter->drawEllipse(750, 50, 60, 60);
         mTakeCheck = false;
     }
}

void Target::changeTakeCheck()
{
    mTakeCheck = true;
}

