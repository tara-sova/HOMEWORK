#include "mainwindow.h"
#include "ui_mainwindow.h"

#include <QGraphicsScene>
#include <QGraphicsView>
#include <QGraphicsItem>
#include <QWidget>
#include <QTimer>

#include "gun.h"
#include "shell.h"
#include "target.h"

MainWindow::MainWindow(QWidget *parent) :
	QMainWindow(parent),
	mUi(new Ui::MainWindow)
{
	mUi->setupUi(this);

	mOurGun = new Gun();
	mScene = new QGraphicsScene();

	mUi->graphicsView->setScene(mScene);

	mUi->graphicsView->setAlignment(Qt::AlignLeft | Qt::AlignTop);
	mScene->addItem(mOurGun);

	mTimer = new QTimer(this);

	connect(mUi->pushButton, SIGNAL(clicked())
			,this, SLOT(bodyDown()));
	connect(mUi->pushButton_2, SIGNAL(clicked())
			,this, SLOT(descriptionOfShot()));
	connect(mUi->pushButton_3, SIGNAL(clicked())
			,this, SLOT(bodyUp()));

	connect(mUi->radioButton, SIGNAL(clicked()),
			this, SLOT(goSlow()));
	connect(mUi->radioButton_2, SIGNAL(clicked()),
			this, SLOT(goMedium()));
	connect(mUi->radioButton_3, SIGNAL(clicked()),
			this, SLOT(goQuick()));

	connect(mTimer, SIGNAL(timeout()), this, SLOT(shot()));

	mOurTarget = new Target();
	mScene->addItem(mOurTarget);

	mUi->label->setVisible(false);
}

void MainWindow::bodyDown()
{
	mOurGun->bodyMoveDown();
	mScene->invalidate();
}

void MainWindow::bodyUp()
{
	mOurGun->bodyMoveUp();
	mScene->invalidate();
}

void MainWindow::descriptionOfShot()
{
	mUi->label->setVisible(false);
	mOurShell = new Shell(mOurGun->getCorner(), mSpeed);
	mScene->addItem(mOurShell);
	this->mTimer->start(50);
	mScene->invalidate();
}

void MainWindow::shot()
{
	mUi->label->setVisible(false);
	mOurShell->shellLetsOut();
	winCheck();
	mScene->invalidate();
}

void MainWindow::winCheck()
{
	if (mOurShell->returnCheck()) {
		mUi->label->setVisible(true);
		mUi->label->setText("win");
		mOurTarget->changeTakeCheck();
		mScene->invalidate();
	}
}

void MainWindow::goSlow()
{
	mSpeed = 31;
}

void MainWindow::goMedium()
{
	mSpeed = 35;
}

void MainWindow::goQuick()
{
	mSpeed = 40;
}

MainWindow::~MainWindow()
{
	delete mTimer;
	delete mScene;
	delete mUi;
}

