#include "mainwindow.h"
#include "ui_mainwindow.h"
#include "gun.h"
#include "shell.h"
#include "target.h"
#include <QGraphicsScene>
#include <QGraphicsView>
#include <QGraphicsItem>
#include <QWidget>
#include <QTimer>


MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow)
{
    ui->setupUi(this);

    ourGun = new gun();
    scene = new QGraphicsScene();

    ui->graphicsView->setScene(scene);

    ui->graphicsView->setAlignment(Qt::AlignLeft | Qt::AlignTop);
    scene->addItem(ourGun);

    ourShell = new shell(ourGun->getCorner());
    scene->addItem(ourShell);

    connect(ui->pushButton, SIGNAL(clicked()),
            this, SLOT(MovementOfBody()));
    connect(ui->pushButton_2, SIGNAL(clicked()),
            this, SLOT(MovementOfShell()));

    timer = new QTimer(this);
    connect(timer, SIGNAL(timeout()), this, SLOT(MakesShellMove()));

    ourTarget = new target();
    scene->addItem(ourTarget);
}

MainWindow::~MainWindow()
{
    delete ui;
}

void MainWindow::MovementOfBody()
{
    ourGun->BodyMoveDown();
    ourShell->shellMovesDown();
    scene->invalidate();
}

void MainWindow::MovementOfShell()
{
    this->timer->start(100);
}

void MainWindow::MakesShellMove()
{
    ourShell->changeVy();
    ourShell->shellLetsOut();
    scene->invalidate();
    if (ourShell->returnCondition())
    {
        timer->stop();
        ourShell->changeCondition(flag);
    }
}
