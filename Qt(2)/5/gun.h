#pragma once

#include "mainwindow.h"

#include <QGraphicsScene>
#include <QGraphicsItem>
#include <QWidget>

/// Class that describe our gun.
class Gun : public QGraphicsItem
{
public:
	Gun();

	/// Paint gun.
	void paint(QPainter *painter, const QStyleOptionGraphicsItem *option, QWidget *widget) override;

	/// Rectangle for gun's painting.
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
