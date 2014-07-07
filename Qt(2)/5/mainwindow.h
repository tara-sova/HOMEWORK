#pragma once

#include <QMainWindow>
#include <QGraphicsScene>
#include <QGraphicsItem>

namespace Ui {
class MainWindow;
}

/// Class that describe our gun.
class Gun;

/// Class that describe our shell.
class Shell;

/// Class that describe our target.
class Target;

class MainWindow : public QMainWindow
{
	Q_OBJECT

public:
	explicit MainWindow(QWidget *parent = 0);
	~MainWindow();

	/// Check victory.
	void winCheck();

private:
	Ui::MainWindow *mUi;
	QGraphicsScene *mScene;
	Gun *mOurGun;
	Shell *mOurShell;
	Target *mOurTarget;
	QTimer *mTimer;
	qreal mSpeed;

public slots:
	/// Move body down.
	void bodyDown();

	/// Move body up.
	void bodyUp();

	/// Describe processes that should happen in shot-time.
	void descriptionOfShot();

	/// Description of shot.
	void shot();

	/// Make shell moves slow.
	void goSlow();

	/// Make shell moves medium.
	void goMedium();

	/// Make shell moves quick.
	void goQuick();
};

