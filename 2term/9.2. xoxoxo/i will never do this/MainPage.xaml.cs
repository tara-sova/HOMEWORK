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
        bool[] checkArray = new bool[9];

        private bool opportunityToPlay = false;

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

            for (int j = 0; j < 9; ++j)
            {
                checkArray[j] = false;
            }

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
                opportunityToPlay = true;
            }
            if (element == "O")
            {
                label1.Content = "You lose";
                opportunityToPlay = true;
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
            if (opportunityToPlay)
            {
                return;
            }

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
            checkArray[number] = true;

            if (opportunityToPlay)
            {
                return;
            }

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

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if ((this.numberOfFillingCells == 9) || (checkArray[0]))
            {
                return;
            }

            UserMove(0);
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if ((this.numberOfFillingCells == 9) || (checkArray[1]))
            {
                return;
            }

            UserMove(1);
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            if ((this.numberOfFillingCells == 9) || (checkArray[2]))
            {
                return;
            }

            UserMove(2);
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            if ((this.numberOfFillingCells == 9) || (checkArray[3]))
            {
                return;
            }

            UserMove(3);
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            if ((this.numberOfFillingCells == 9) || (checkArray[4]))
            {
                return;
            }

            UserMove(4);
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            if ((this.numberOfFillingCells == 9) || (checkArray[5]))
            {
                return;
            }

            UserMove(5);
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            if ((this.numberOfFillingCells == 9) || (checkArray[6]))
            {
                return;
            }

            UserMove(6);
        }

        private void button8_Click(object sender, RoutedEventArgs e)
        {
            if ((this.numberOfFillingCells == 9) || (checkArray[7]))
            {
                return;
            }

            UserMove(7);
        }

        private void button9_Click(object sender, RoutedEventArgs e)
        {
            if ((this.numberOfFillingCells == 9) || (checkArray[8]))
            {
                return;
            }

            UserMove(8);
        }
    }
}
