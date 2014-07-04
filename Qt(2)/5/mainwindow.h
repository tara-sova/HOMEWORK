#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include <QGraphicsScene>
#include <QGraphicsItem>

namespace Ui {
class MainWindow;
}

class gun;
class shell;
class target;

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    explicit MainWindow(QWidget *parent = 0);
    ~MainWindow();

private:
    Ui::MainWindow *ui;
    QGraphicsScene *scene;
    gun *ourGun;
    shell *ourShell;
    target *ourTarget;
    QTimer *timer;
    bool flag = false;

public slots:
    void MovementOfBody();
    void MovementOfShell();
    void MakesShellMove();

};

#endif // MAINWINDOW_H
