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


class shell : public QGraphicsItem
{
public:
    shell(int corner);
    void paint(QPainter *painter, const QStyleOptionGraphicsItem *option, QWidget *widget);
    QRectF boundingRect() const;
    void shellMovesDown();
    void shellLetsOut();
    bool returnCondition();
    void changeCondition(bool change);
    void changeVy();

private:
    int position = 0;
    double angle = 90;
    int x = 55;
    int y = 390;
    int condition = false;
    QPoint V;
    QRectF *rect = new QRectF(10, 21, 840, 440);
};

#endif // SHELL_H
