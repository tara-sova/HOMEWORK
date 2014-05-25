using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _6._2.clock
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
        }

        private DateTime time = new DateTime();

        /// <summary>
        /// Our watch starts tick-tock.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer1Tick(object sender, EventArgs e)
        {
            time = DateTime.Now;
            label1.Text = time.ToString();
        }
    }
}
