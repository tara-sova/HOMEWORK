#ifndef TARGET_H
#define TARGET_H
#include "mainwindow.h"
#include <QGraphicsScene>
#include <QGraphicsItem>
#include <QWidget>
#include "gun.h"
#include "shell.h"

class Target : public QGraphicsItem
{
public:
    Target();
    void paint(QPainter *painter, const QStyleOptionGraphicsItem *option, QWidget *widget);
    QRectF boundingRect() const;
    void changeTakeCheck();
private:
    bool mTakeCheck = false;
};

#endif // TARGET_H
