#include "target.h"

#include <QGraphicsScene>
#include <QGraphicsItem>
#include <QWidget>
#include <QTimer>
#include <QrectF>
#include <QGraphicsView>

#include "gun.h"
#include "mainwindow.h"
#include "shell.h"

Target::Target(){}

QRectF Target::boundingRect() const
{
	return QRectF(11, 22, 82, 50);
}

void Target::paint(QPainter *painter, const QStyleOptionGraphicsItem *option, QWidget *widget)
{
	Q_UNUSED(option)
	Q_UNUSED(widget)
	 painter->drawEllipse(750, 50, 60, 60);
	 if (mTakeCheck) {
		 painter->setBrush(Qt::red);
		 painter->drawEllipse(750, 50, 60, 60);
		 mTakeCheck = false;
	 }
}

void Target::changeTakeCheck()
{
	mTakeCheck = true;
}

