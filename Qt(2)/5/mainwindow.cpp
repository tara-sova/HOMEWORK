#include "mainwindow.h"
#include "ui_mainwindow.h"

#include "gun.h"
#include "shell.h"
#include "target.h"

MainWindow::MainWindow(QWidget *parent)
	: QMainWindow(parent)
	, mUi(new Ui::MainWindow)
{
	mUi->setupUi(this);

	mOurGun = new Gun();
	mScene = new QGraphicsScene();

	mUi->graphicsView->setScene(mScene);

	mUi->graphicsView->setAlignment(Qt::AlignLeft | Qt::AlignTop);
	mScene->addItem(mOurGun);

	mTimer = new QTimer(this);

	connect(mUi->pushButton, &QPushButton::clicked, this, &MainWindow::bodyDown);
	connect(mUi->pushButton_2, &QPushButton::clicked, this, &MainWindow::describeShot);
	connect(mUi->pushButton_3, &QPushButton::clicked, this, &MainWindow::bodyUp);

	connect(mUi->radioButton, &QRadioButton::clicked, this, &MainWindow::goSlow);
	connect(mUi->radioButton_2, &QRadioButton::clicked, this, &MainWindow::goMedium);
	connect(mUi->radioButton_3, &QRadioButton::clicked, this, &MainWindow::goQuick);

	connect(mTimer, SIGNAL(timeout()), this, SLOT(shot()));

	mOurTarget = new Target();
	mScene->addItem(mOurTarget);

	mUi->label->setVisible(false);
}

MainWindow::~MainWindow()
{
	delete mTimer;
	delete mScene;
	delete mUi;
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

void MainWindow::describeShot()
{
	mUi->label->setVisible(false);
	delete mOurShell;
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

