using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestWork3
{
    // This is a Form with a Button that run from cursor.
    public partial class Form1 : Form
    {
        // Initialize our Form.
        public Form1()
        {
            InitializeComponent();
        }

        // Description of Button's behavior.
        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            if (button1.Location == button2.Location)
            {
                button1.Location = button3.Location;
                return;
            }

            if (button1.Location == button3.Location)
            {
                button1.Location = button4.Location;
                return;
            }

                button1.Location = button2.Location;
        }

        // Action that happen when we press enter or space.
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
