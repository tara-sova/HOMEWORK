#pragma once

#include <QMainWindow>
#include <QtWidgets/QGraphicsScene>
#include <QtWidgets/QGraphicsItem>
#include <QtWidgets/QGraphicsView>
#include <QtCore/QTimer>
#include <QtWidgets/QWidget>

namespace Ui {
class MainWindow;
}

class Gun;

class Shell;

class Target;

class MainWindow : public QMainWindow
{
	Q_OBJECT

public:
	explicit MainWindow(QWidget *parent = 0);
	~MainWindow();

private:
	/// Check victory.
	void winCheck();

	Ui::MainWindow *mUi; // Has ownership.
	QGraphicsScene *mScene = nullptr; // Has ownership.
	Gun *mOurGun = nullptr; // Scene deletes this object.
	Shell *mOurShell = nullptr; // Scene deletes this object.
	Target *mOurTarget = nullptr; // Scene deletes this object.
	QTimer *mTimer = nullptr; // Has ownership.
	qreal mSpeed;

private slots:
	/// Move body down.
	void bodyDown();

	/// Move body up.
	void bodyUp();

	/// Describe processes that should happen in shot-time.
	void describeShot();

	/// Description of shot.
	void shot();

	/// Make shell moves slow.
	void goSlow();

	/// Make shell moves medium.
	void goMedium();

	/// Make shell moves quick.
	void goQuick();
};

