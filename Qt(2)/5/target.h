#pragma once

#include "mainwindow.h"
#include "gun.h"
#include "shell.h"

#include <QGraphicsScene>
#include <QGraphicsItem>
#include <QWidget>

/// Class that describe our target.
class Target : public QGraphicsItem
{
public:
	Target();

	/// Paint target.
	void paint(QPainter *painter, const QStyleOptionGraphicsItem *option, QWidget *widget) override;

	/// Rectangle for shell's painting.
	QRectF boundingRect() const override;

	/// Change meaning of a matching.
	void changeTakeCheck();

private:
	bool mTakeCheck = false;
};
