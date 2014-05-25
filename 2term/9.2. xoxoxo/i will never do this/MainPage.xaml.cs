using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace i_will_never_do_this
{
    public partial class MainPage : UserControl
    {
        Button[] array = new Button[9];
        public MainPage()
        {
            InitializeComponent();
            array[0] = button1;
            array[1] = button2;
            array[2] = button3;
            array[3] = button4;
            array[4] = button5;
            array[5] = button6;
            array[6] = button7;
            array[7] = button8;
            array[8] = button9;
            for(int i = 0; i < 9; ++i)
            {
                array[i].Content = "-";
            }

            label1.Content = "Place for result";
            label2.Content = "label2";
            label2.Content = numberOfFillingCells.ToString();
        }

        private int numberOfFillingCells = 0;

        private void Matching(string element)
        {
            if (element == "X")
            {
                label1.Content = "You win";
            }
            if (element == "O")
            {
                label1.Content = "You lose";
            }
        }

        private void WinCheck()
        {
            if ((array[0].Content.ToString() == array[1].Content.ToString()) && (array[1].Content.ToString() == array[2].Content.ToString()))
            {
                Matching(array[0].Content.ToString());
                return;
            }

            if ((array[3].Content.ToString() == array[4].Content.ToString()) && (array[4].Content.ToString() == array[5].Content.ToString()))
            {
                Matching(array[3].Content.ToString());
                return;
            }

            if ((array[6].Content.ToString() == array[7].Content.ToString()) && (array[7].Content.ToString() == array[8].Content.ToString()))
            {
                Matching(array[6].Content.ToString());
                return;
            }

            if ((array[0].Content.ToString() == array[3].Content.ToString()) && (array[3].Content.ToString() == array[6].Content.ToString()))
            {
                Matching(array[0].Content.ToString());
                return;
            }

            if ((array[1].Content.ToString() == array[4].Content.ToString()) && (array[4].Content.ToString() == array[7].Content.ToString()))
            {
                Matching(array[1].Content.ToString());
                return;
            }

            if ((array[2].Content.ToString() == array[5].Content.ToString()) && (array[5].Content.ToString() == array[8].Content.ToString()))
            {
                Matching(array[2].Content.ToString());
                return;
            }

            if ((array[0].Content.ToString() == array[4].Content.ToString()) && (array[4].Content.ToString() == array[8].Content.ToString()))
            {
                Matching(array[0].Content.ToString());
                return;
            }

            if ((array[2].Content.ToString() == array[4].Content.ToString()) && (array[4].Content.ToString() == array[6].Content.ToString()))
            {
                Matching(array[2].Content.ToString());
                return;
            }

            if (numberOfFillingCells == 9)
            {
                label1.Content = "Nobody is win";
                label2.Content = numberOfFillingCells.ToString();
            }

        }

        private void AddO()
        {
            for(int i = 0; i < 9; ++i)
            {
                if ((array[i].Content.ToString() != "X") && (array[i].Content.ToString() != "O"))
                {
                    array[i].Content = "O";
                    ++numberOfFillingCells;

                    label2.Content = numberOfFillingCells.ToString();

                    return;
                }
            }
        }


        private void UserMove(int number)
        {
            array[number].Content = "X";
            ++this.numberOfFillingCells;

            label2.Content = numberOfFillingCells.ToString();

            if (this.numberOfFillingCells == 9)
            {
                return;
            }

            string text = label1.Content.ToString();

            WinCheck();

            if (text != label1.Content.ToString())
            {
                return;
            }

            AddO();

            label2.Content = numberOfFillingCells.ToString();

            WinCheck();
        }


        private bool check1 = false;
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if ((this.numberOfFillingCells == 9) || (check1))
            {
                return;
            }

            check1 = true;

            UserMove(0);
        }

        bool check2 = false;
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if ((this.numberOfFillingCells == 9) || (check2))
            {
                return;
            }

            check2 = true;

            UserMove(1);
        }

        bool check3 = false;
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            if ((this.numberOfFillingCells == 9) || (check3))
            {
                return;
            }

            check3 = true;

            UserMove(2);
        }

        bool check4 = false;
        private void button4_Click(object sender, RoutedEventArgs e)
        {
            if ((this.numberOfFillingCells == 9) || (check4))
            {
                return;
            }

            check4 = true;

            UserMove(3);
        }

        bool check5 = false;
        private void button5_Click(object sender, RoutedEventArgs e)
        {
            if ((this.numberOfFillingCells == 9) || (check5))
            {
                return;
            }

            check5 = true;

            UserMove(4);
        }

        bool check6 = false;
        private void button6_Click(object sender, RoutedEventArgs e)
        {
            if ((this.numberOfFillingCells == 9) || (check6))
            {
                return;
            }

            check6 = true;

            UserMove(5);
        }

        bool check7 = false;
        private void button7_Click(object sender, RoutedEventArgs e)
        {
            if ((this.numberOfFillingCells == 9) || (check7))
            {
                return;
            }

            check7 = true;

            UserMove(6);
        }

        bool check8 = false;
        private void button8_Click(object sender, RoutedEventArgs e)
        {
            if ((this.numberOfFillingCells == 9) || (check8))
            {
                return;
            }

            check8 = true;

            UserMove(7);
        }

        bool check9 = false;
        private void button9_Click(object sender, RoutedEventArgs e)
        {
            if ((this.numberOfFillingCells == 9) || (check9))
            {
                return;
            }

            check9 = true;

            UserMove(8);
        }
    }
}
