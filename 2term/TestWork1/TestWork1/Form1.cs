using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestWork1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool a = false;

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {

          

        }

        private void Check(Button button, bool click)
        {
            if (click == false)
            {
                if (a == false)
                {
                    button.Text = "X";
                    a = true;
                    click = true;
                }
                else
                {
                    button.Text = "O";
                    a = false;
                    click = true;
                }
            }
            else
            {
                return;
            }
        }


        private bool click1 = false;
        private void button1_Click(object sender, EventArgs e)
        {
            if (click1 == false)
            {
                if (a == false)
                {
                    button1.Text = "X";
                    a = true;
                    click1 = true;
                }
                else
                {
                    button1.Text = "O";
                    a = false;
                    click1 = true;
                }
            }
            else
            {
                return;
            }
        }

        private bool click2 = false;
        private void button2_Click(object sender, EventArgs e)
        {
            if (click2 == false)
            {
                if (a == false)
                {
                    button2.Text = "X";
                    a = true;
                    click2 = true;
                }
                else
                {
                    button2.Text = "O";
                    a = false;
                    click2 = true;
                }
            }
            else
            {
                return;
            }
        }

        private bool click3 = false;
        private void button3_Click(object sender, EventArgs e)
        {
            if (click3 == false)
            {
                if (a == false)
                {
                    button3.Text = "X";
                    a = true;
                    click3 = true;
                }
                else
                {
                    button3.Text = "O";
                    a = false;
                    click3 = true;
                }
            }
            else
            {
                return;
            }
        }

        private bool click4 = false;
        private void button4_Click(object sender, EventArgs e)
        {
            if (click4 == false)
            {
                if (a == false)
                {
                    button4.Text = "X";
                    a = true;
                    click4 = true;
                }
                else
                {
                    button4.Text = "O";
                    a = false;
                    click4 = true;
                }
            }
            else
            {
                return;
            }
        }

        private bool click5 = false;
        private void button5_Click(object sender, EventArgs e)
        {
            if (click5 == false)
            {
                if (a == false)
                {
                    button5.Text = "X";
                    a = true;
                    click5 = true;
                }
                else
                {
                    button5.Text = "O";
                    a = false;
                    click5 = true;
                }
            }
            else
            {
                return;
            }
        }


        private bool click6 = false;
        private void button6_Click(object sender, EventArgs e)
        {
            if (click6 == false)
            {
                if (a == false)
                {
                    button6.Text = "X";
                    a = true;
                    click6 = true;
                }
                else
                {
                    button6.Text = "O";
                    a = false;
                    click6 = true;
                }
            }
            else
            {
                return;
            }
        }

        private bool click7 = false;
        private void button7_Click(object sender, EventArgs e)
        {
            if (click7 == false)
            {
                if (a == false)
                {
                    button7.Text = "X";
                    a = true;
                    click7 = true;
                }
                else
                {
                    button7.Text = "O";
                    a = false;
                    click7 = true;
                }
            }
            else
            {
                return;
            }
        }


        private bool click8 = false;
        private void button8_Click(object sender, EventArgs e)
        {
            if (click8 == false)
            {
                if (a == false)
                {
                    button8.Text = "X";
                    a = true;
                    click8 = true;
                }
                else
                {
                    button8.Text = "O";
                    a = false;
                    click8 = true;
                }
            }
            else
            {
                return;
            }
        }

        private bool click9 = false;
        private void button9_Click(object sender, EventArgs e)
        {
            if (click9 == false)
            {
                if (a == false)
                {
                    button9.Text = "X";
                    a = true;
                    click9 = true;
                }
                else
                {
                    button9.Text = "O";
                    a = false;
                    click9 = true;
                }
            }
            else
            {
                return;
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_MarginChanged(object sender, EventArgs e)
        {

        }

    }
}
