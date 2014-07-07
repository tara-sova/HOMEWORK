#-------------------------------------------------
#
# Project created by QtCreator 2014-07-02T14:04:21
#
#-------------------------------------------------

QT       += core gui

greaterThan(QT_MAJOR_VERSION, 4): QT += widgets

TARGET = 5
TEMPLATE = app

CONFIG += C++11

SOURCES += main.cpp\
        mainwindow.cpp \
    gun.cpp \
    shell.cpp \
    target.cpp

HEADERS  += mainwindow.h \
    gun.h \
    shell.h \
    target.h

FORMS    += mainwindow.ui
