using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TermWork2
{
    public partial class ProgressBar : Form
    {
        int time = 0;

        public ProgressBar()
        {
            InitializeComponent();
        }

       /// <summary>
       /// Create a new timer.
       /// </summary>
        private Timer tmrShow = new Timer();

        /// <summary>
        /// Programm's behavior after click on button2.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnButton2Click(object sender, EventArgs e)
        {
            this.Close();
        }
         
        /// <summary>
        /// Programm's behavior after click on button1.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnButton1Click(object sender, EventArgs e)
        {
            this.timer1.Start();
            tmrShow.Tick += Timer1Tick;
        }

        /// <summary>
        /// Programm's behavior after every timer's tick.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer1Tick(object sender, EventArgs e)
        {
            time += 10;

            progressBar1.Value = time;

            if (progressBar1.Value == progressBar1.Maximum)
            {
                timer1.Stop();
                time = 0;  
                button2.Visible = true;
                return;
            }
        }
    }
}
