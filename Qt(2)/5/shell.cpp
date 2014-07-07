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

Shell::Shell(int corner)
{
    mPosition = corner - 180;
    mV;
    mG.setY(mG.y() + 1);

    QTransform transformMTransformVector;
    transformMTransformVector.translate(55, 390);
    transformMTransformVector.rotate(mPosition + 2);
    mTransformVector = transformMTransformVector.map(mTransformVector);

    QTransform transformMV;
    transformMV.rotate(mPosition - 90);
    mV = transformMV.map(mV);

    qDebug() << mV;
}

QRectF Shell::boundingRect() const
{
    return QRectF(11, 22, 82, 50);
}

void Shell::shellMovesDown()
{
    mPosition = mPosition + 5;
}

void Shell::decreaseCorner(int corner)
{
    mPosition = mPosition - 180;
}

void Shell::increaseCorner(int corner)
{
    mPosition = 180 - mPosition;
}

void Shell::paint(QPainter *painter, const QStyleOptionGraphicsItem *option, QWidget *widget)
{
    painter->drawRect(10, 21, 840, 439);
    painter->drawEllipse(mTransformVector.x(), mTransformVector.y(), 10, 10);
}

void Shell::shellLetsOut()
{
    mV += mG;

    if((mRect->contains(mTransformVector.x(), mTransformVector.y())) && (!mCondition)){
        mTransformVector.setX(mTransformVector.x() + mV.x());
        mTransformVector.setY(mTransformVector.y() + mV.y());

        if (mEllipseRect->contains(mTransformVector.x(), mTransformVector.y())){
            mCheck = true;
        }
    }
    else
    {
        mTransformVector = {0, -90};
        mCondition = true;
    }
}

void Shell::changeCondition(bool change)
{
    mCondition = change;
}

bool Shell::returnCondition()
{
    return mCondition;
}

bool Shell::returnCheck()
{
    return mCheck;
}

QPointF Shell::mVInitialize(int speed)
{
    mV = {speed, mV.y()};
    //mV.setX(speed);
}

