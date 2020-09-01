using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Youtube_Panel
{
    public partial class Loader : Form
    {
        public Loader()
        {
            InitializeComponent();
            bunifuProgressBar1.MaximumValue = 125; // sets the progress bar maximum value
            timer1.Interval = 120; // sets the timer1 interval
            timer1.Start(); // starts the timer1 instance
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (bunifuProgressBar1.Value == 125)
            {
                timer1.Stop(); // stops the timer loop if it reaches maximum value (125)
                timer1.Enabled = false;

                Form3 main = new Form3(); // goes to main form
                main.Show();
                this.Hide();
            }
            else
            {
                bunifuProgressBar1.Value++; // incrases the progress bar if it's not the maximum value 
            }
        }
    }
}
