#ifndef SHELL_H
#define SHELL_H
#include "mainwindow.h"
#include <QGraphicsScene>
#include <QGraphicsItem>
#include <QWidget>
#include "gun.h"
#include <QTimer>
#include <QrectF>
#include <qpoint.h>
#include <QPoint>


class Shell : public QGraphicsItem
{
public:
    Shell(int corner);
    void paint(QPainter *painter, const QStyleOptionGraphicsItem *option, QWidget *widget);
    QRectF boundingRect() const;
    void shellMovesDown();
    void shellLetsOut();
    bool returnCondition();
    void changeCondition(bool change);

    void decreaseCorner(int corner);
    void increaseCorner(int corner);

    bool returnCheck();

    QPointF mVInitialize(int speed);


private:
    int mPosition = 0;
    int mCondition = false;
    QPointF mV;
    QPointF mG;
    QPointF mTransformVector = {0, -90};
    QRectF *mRect = new QRectF(10, 21, 840, 440);
    bool mCheck = false;
    QRectF *mEllipseRect = new QRectF(750, 50, 60, 60);
};

#endif // SHELL_H
