using Panel;
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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }
        Point lastPoint;
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // go to login form
            Form1 login = new Form1();
            this.Hide();
            login.Show();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (API.Register(username.Text, password.Text, email.Text, license.Text))
            {
                // go to login once you register
                MessageBox.Show("Successfully registered", "Success!");
                Form1 login = new Form1();
                this.Hide();
                login.Show();
            }
        }
    }
}
