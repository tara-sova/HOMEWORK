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
    /// <summary>
    /// Class for calculating numbers.
    /// </summary>
    public partial class Calculator : Form
    {
        private double firstNumber = 0;
        private bool firstRecorded = false;

        enum Operation { plus, minus, multiply, divide };
        private Operation operation = Operation.plus;

        /// <summary>
        /// Discription of operation's switching.
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="firstNumber"></param>
        /// <param name="inputNumber"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Behaivor of calculator after click on the button.
        /// </summary>
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

        public Calculator()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Record Number.
        /// </summary>
        /// <param name="number"></param>
        private void recordNumber(int number)
        {
            textBox1.Text += number;
        }

        /// <summary>
        /// Handler of this button click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnButtonNumber4Click(object sender, EventArgs e)
        {
            recordNumber(4);
        }

        /// <summary>
        /// Handler of this button click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnButtonNumber5Click(object sender, EventArgs e)
        {
            recordNumber(5);
        }

        /// <summary>
        /// Handler of this button click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnButtonNumber2Click(object sender, EventArgs e)
        {
            recordNumber(2);
        }

        /// <summary>
        /// Handler of this button click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnButtonNumber0Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && (!firstRecorded))
            {
                return;
            }
            textBox1.Text += "0";
        }

        /// <summary>
        /// Handler of this button click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnButtonNumber1Click(object sender, EventArgs e)
        {
            recordNumber(1);
        }

        /// <summary>
        /// Handler of this button click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnButtonNumber3Click(object sender, EventArgs e)
        {
            recordNumber(3);
        }

        /// <summary>
        /// Handler of this button click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnButtonNumber6Click(object sender, EventArgs e)
        {
            recordNumber(6);
        }

        /// <summary>
        /// Handler of this button click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnButtonNumber7Click(object sender, EventArgs e)
        {
            recordNumber(7);
        }

        /// <summary>
        /// Handler of this button click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnButtonNumber8Click(object sender, EventArgs e)
        {
            recordNumber(8);
        }

        /// <summary>
        /// Handler of this button click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnButtonNumber9Click(object sender, EventArgs e)
        {
            recordNumber(9);
        }

        /// <summary>
        /// Handler of this button click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnButtonPointClick(object sender, EventArgs e)
        {
            textBox1.Text += ",";
        }

        
        private bool plus = false;

        /// <summary>
        /// Let's sum something!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnButtonPlusClick(object sender, EventArgs e)
        {
            plus = true;
            OnButtonClick();
            plus = false;
        }

        /// <summary>
        /// Output result.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnButtonEqualsClick(object sender, EventArgs e)
        {
            firstNumber = executeOperation(operation, firstNumber, Convert.ToDouble(textBox1.Text));
            textBox1.Text = firstNumber.ToString();
            firstRecorded = false;
        }

        bool minus = false;
        /// <summary>
        /// Let's subtract something!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnButtonMinusClick(object sender, EventArgs e)
        {
            minus = true;
            OnButtonClick();
            minus = false;
        }

        bool multiply = false;
        /// <summary>
        /// Let's multiply something!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnButtonMultiplyClick(object sender, EventArgs e)
        {
            multiply = true;
            OnButtonClick();
            multiply = false;
        }

        bool divide = false;
        /// <summary>
        /// Let's divide something!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnButtonDivideClick(object sender, EventArgs e)
        {
            divide = true;
            OnButtonClick();
            divide = false;
        }

        /// <summary>
        /// Clear all, but not your soul.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnButtonCClick(object sender, EventArgs e)
        {
            firstNumber = 0;
            firstRecorded = false;
            textBox1.Text = "";
        }

        /// <summary>
        /// Just foget number.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnButtonCEClick(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
    }
}
