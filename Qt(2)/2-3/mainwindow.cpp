#include "mainwindow.h"
#include "ui_mainwindow.h"


MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow)
{
    ui->setupUi(this);

    connect(ui->pushButton, SIGNAL(clicked()),
            this, SLOT(Close()));

    connect(ui->pushButton_2, SIGNAL(clicked()),
            this, SLOT(go()));

    connect(ui->pushButton_3, SIGNAL(clicked()),
            this, SLOT(goBack()));

    connect(ui->pushButton_4, SIGNAL(clicked()),
            this, SLOT(goNext()));

    connect(ui->pushButton_4, SIGNAL(clicked()),
            this, SLOT(F5()));
}

MainWindow::~MainWindow()
{
    delete ui;
}

void MainWindow::Close()
{
    this->close();
}

void MainWindow::go()
{
     ui->webView->load(QUrl(ui->lineEdit->text()));
     ui->webView->show();
}

void MainWindow::goBack()
{
    ui->webView->back();
    ui->webView->show();
}

void MainWindow::goNext()
{
     ui->webView->forward();
     ui->webView->show();
}

void MainWindow::F5()
{
    ui->webView->reload();
    ui->webView->show();
}
