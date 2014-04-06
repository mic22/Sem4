using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Radio
{
    public partial class Form1 : Form
    {
        Random rand = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                label1.Text = (string)radioButton1.Tag;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                label1.Text = (string)radioButton2.Tag;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                label1.Text = (string)radioButton3.Tag;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                label1.Text = (string)radioButton4.Tag;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                label1.BackColor = Color.LawnGreen;
                label1.ForeColor = Color.Black;
                if(label1.Text == "")
                    label1.Text = (string)radioButton1.Tag;
                timer1.Start();
            }
            else
            {
                label1.BackColor = Color.Gray;
                label1.ForeColor = Color.Gray;
                timer1.Stop();
                progressBar1.Value = 0;
                progressBar2.Value = 0;
                progressBar3.Value = 0;
                progressBar4.Value = 0;
                progressBar5.Value = 0;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value = rand.Next(100);
            progressBar2.Value = rand.Next(100);
            progressBar3.Value = rand.Next(100);
            progressBar4.Value = rand.Next(100);
            progressBar5.Value = rand.Next(100);
        }
    }
}
