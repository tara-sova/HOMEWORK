#include "shell.h"

#include "math.h"
#include "gun.h"
#include "mainwindow.h"

Shell::Shell(int corner, qreal speed)
{
	mPosition = corner - 180;

	QTransform transformMTransformVector;
	transformMTransformVector.translate(55, 390);
	transformMTransformVector.rotate(mPosition + 2);
	mTransformVector = transformMTransformVector.map(mTransformVector);

	mV.setX(mV.x() + speed);
	mV.y();

	QTransform transformMV;
	transformMV.rotate(mPosition - 90);
	mV = transformMV.map(mV);
}

QRectF Shell::boundingRect() const
{
	return QRectF(11, 22, 82, 50);
}

void Shell::decreaseCorner()
{
	mPosition = mPosition - 180;
}

void Shell::increaseCorner()
{
	mPosition = 180 - mPosition;
}

void Shell::paint(QPainter *painter, const QStyleOptionGraphicsItem *option, QWidget *widget)
{
	Q_UNUSED(option)
	Q_UNUSED(widget)
	painter->drawRect(10, 21, 840, 439);
	painter->drawEllipse(mTransformVector.x(), mTransformVector.y(), 10, 10);
}

void Shell::shellLetsOut()
{
	mV += mG;
	if ((mRect->contains(mTransformVector.x(), mTransformVector.y())) && (!mCondition)) {
		mTransformVector.setX(mTransformVector.x() + mV.x());
		mTransformVector.setY(mTransformVector.y() + mV.y());

		if (mEllipseRect->contains(mTransformVector.x(), mTransformVector.y())) {
			mCheck = true;
		}
	}
	else {
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

