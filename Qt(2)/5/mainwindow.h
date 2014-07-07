#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include <QGraphicsScene>
#include <QGraphicsItem>

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
    void winCheck();

private:
    Ui::MainWindow *mUi;
    QGraphicsScene *mScene;
    Gun *mOurGun;
    Shell *mOurShell;
    Target *mOurTarget;
    QTimer *mTimer;

public slots:
    void bodyDown();
    void bodyUp();
    void descriptionOfShot();
    void shot();
    void goSlow();
    void goMedium();
    void goQuick();

};

#endif // MAINWINDOW_H
