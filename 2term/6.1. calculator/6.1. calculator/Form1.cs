using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _6._1.calculator
{
    public partial class Form1 : Form
    {

        private double firstNumber = 0;
        private bool firstRecorded = false;

        enum Operation { plus, minus, multiply, divide };
        private Operation operation = Operation.plus;

        private double executeOperation(Operation operation, double firstNumber, double inputNumber)
        {
            switch (operation) {
                case Operation.plus: return firstNumber + inputNumber;
                case Operation.minus: return firstNumber - inputNumber;
                case Operation.multiply: return firstNumber * inputNumber;
                case Operation.divide: return firstNumber / inputNumber;
            }
            return 0;
        }

        private void OnButtonClick()
        {
            if (!firstRecorded)
            {
                firstNumber = Convert.ToDouble(textBox1.Text);
                firstRecorded = true;
            }
            else
            {
                firstNumber = executeOperation(operation, firstNumber, Convert.ToDouble(textBox1.Text));
            }

            if (minus == true)
                operation = Operation.minus;
            if (plus == true)
                operation = Operation.plus;
            if (multiply == true)
                operation = Operation.multiply;
            if (divide == true)
                operation = Operation.divide;

            textBox1.Text = "";
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void recordNumber(int number)
        {
            textBox1.Text += number;
        }

        private void OnButtonNumber4Click(object sender, EventArgs e)
        {
            recordNumber(4);
        }

        private void OnButtonNumber5Click(object sender, EventArgs e)
        {
            recordNumber(5);
        }

        private void OnButtonNumber2Click(object sender, EventArgs e)
        {
            recordNumber(2);
        }

        private void OnButtonNumber0Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && (!firstRecorded))
            {
                return;
            }
            textBox1.Text += "0";
        }

        private void OnButtonNumber1Click(object sender, EventArgs e)
        {
            recordNumber(1);
        }

        private void OnButtonNumber3Click(object sender, EventArgs e)
        {
            recordNumber(3);
        }

        private void OnButtonNumber6Click(object sender, EventArgs e)
        {
            recordNumber(6);
        }

        private void OnButtonNumber7Click(object sender, EventArgs e)
        {
            recordNumber(7);
        }

        private void OnButtonNumber8Click(object sender, EventArgs e)
        {
            recordNumber(8);
        }

        private void OnButtonNumber9Click(object sender, EventArgs e)
        {
            recordNumber(9);
        }

        private void OnButtonPointClick(object sender, EventArgs e)
        {
            textBox1.Text += ",";
        }

        private bool plus = false;
        private void OnButtonPlusClick(object sender, EventArgs e)
        {
            plus = true;
            OnButtonClick();
            plus = false;
        }

        private void OnButtonEqualsClick(object sender, EventArgs e)
        {
            firstNumber = executeOperation(operation, firstNumber, Convert.ToDouble(textBox1.Text));
            textBox1.Text = firstNumber.ToString();
            firstRecorded = false;
        }

        bool minus = false;
        private void OnButtonMinusClick(object sender, EventArgs e)
        {
            minus = true;
            OnButtonClick();
            minus = false;
        }

        bool multiply = false;
        private void OnButtonMultiplyClick(object sender, EventArgs e)
        {
            multiply = true;
            OnButtonClick();
            multiply = false;
        }

        bool divide = false;
        private void OnButtonDivideClick(object sender, EventArgs e)
        {
            divide = true;
            OnButtonClick();
            divide = false;
        }

        private void OnButtonCClick(object sender, EventArgs e)
        {
            firstNumber = 0;
            firstRecorded = false;
            textBox1.Text = "";
        }

        private void OnButtonCEClick(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
    }
}
