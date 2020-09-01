using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Youtube_Panel
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            string timeS = time.Text; // reads the Time inputted text
            int timeI; // saves the Int variable to get the converted value of the string
            Int32.TryParse(timeS, out timeI); // converts the string to the int

            // same stuff ^
            string portS = port.Text;
            int portI;
            Int32.TryParse(portS, out portI);
            if (timeI > 150) // 150 = max boot time, u can change it to whatever
            {
                MessageBox.Show("Exceeded max boot time", "Error");

            }
            else if (portI > 65535) // known ports limit
            {
                MessageBox.Show("Exceeded known ports range", "Error");

            }
            else
            {
                createLogs();
                readLogs();
                MessageBox.Show("Attack successfully launched!", "Success");
            }
        }
        private void createLogs()
        {
            string patht = Environment.CurrentDirectory + "\\" + "Logs"; // gets the .exe file directory and creates "Logs" file ( suggested to change the dir )
            if (File.Exists(patht)) // checks if the "Logs" file is existing
                using (StreamWriter Add = File.AppendText(patht))
                {
                    Add.WriteLine("A: " + address.Text + " " + "P: " + port.Text + " " + "T: " + time.Text + " " + "\n"); // if it exists, it only adds the text by using AppendText
                    Add.Close();
                }
            else
                using (StreamWriter Logs = File.CreateText(patht))
                {
                    Logs.WriteLine("A: " + address.Text + " " + "P: " + port.Text + " " + "T: " + time.Text + " " + "\n"); // if it doesnt exist it creates a new one using CreateText
                    Logs.Close();
                }
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            deleteLogs();
            textBox1.Text = "";
        }

        private void deleteLogs()
        {
            string patht = Environment.CurrentDirectory + "\\Logs";
            if (File.Exists(patht))
            {
                File.Delete(patht);
            }
            else
            {
                MessageBox.Show("No Logs file detected", "Error");
            }
        }

        private void readLogs()
        {
            string patht = Environment.CurrentDirectory + "\\Logs"; // btw you use "\\" cause the compiler detects "\" as text, and not a directory slash
            if (File.Exists(patht))
            {
                string logs = File.ReadAllText(patht);
                textBox1.Text = logs;
            }
        }
    }
}
