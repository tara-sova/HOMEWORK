#pragma once

#include <QtWidgets/QGraphicsScene>
#include <QtWidgets/QGraphicsItem>
#include <QtWidgets/QWidget>
#include <QtWidgets/QGraphicsView>

#include "mainwindow.h"

/// Class that describe our gun.
class Gun : public QGraphicsItem
{
public:
	Gun();

	void paint(QPainter *painter, const QStyleOptionGraphicsItem *option, QWidget *widget) override;

	QRectF boundingRect() const override;

	/// Move gun's body down.
	void bodyMoveDown();

	/// Move gun's body up.
	void bodyMoveUp();

	/// Get corner of movements.
	int getCorner();

private:
	int mCorner = 180;
};
