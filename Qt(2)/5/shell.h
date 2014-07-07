#pragma once

#include "mainwindow.h"
#include "gun.h"

#include <QGraphicsScene>
#include <QGraphicsItem>
#include <QWidget>
#include <QTimer>
#include <QrectF>
#include <qpoint.h>
#include <QPoint>

/// Class that describe our shell.
class Shell : public QGraphicsItem
{
public:
	Shell(int corner, qreal speed);

	/// Paint shell.
	void paint(QPainter *painter, const QStyleOptionGraphicsItem *option, QWidget *widget) override;

	/// Rectangle for shell's painting.
	QRectF boundingRect() const override;

	/// Make shell moves down with gun's body.
	void shellLetsOut();

	/// Check location of shell.
	bool returnCondition();

	/// Change location of shell.
	void changeCondition(bool change);

	/// Make shell moves down with gun's body.
	void decreaseCorner();

	/// Make shell moves up with gun's body.
	void increaseCorner();

	/// Return condition of a matching shell and ellipse's recktangle.
	bool returnCheck();

private:
	int mPosition = 0;
	int mCondition = false;
	QPointF mV = {31, 0};
	QPointF mG;
	QPointF mTransformVector = {0, -90};
	QRectF *mRect = new QRectF(10, 21, 840, 440);
	bool mCheck = false;
	QRectF *mEllipseRect = new QRectF(750, 50, 60, 60);
};
