using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FibbBgw
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void calcButton_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }
        public static int fib(int n, ProgressBar pb, TextBox res)
        {
            System.Threading.Thread.Sleep(50);
            pb.Value++;
            if (n == 0 || n == 1)
                return n;
            else
            {
                var f = fib(n - 1, pb, res) + fib(n - 2, pb, res);
                res.Text = n.ToString() + ", " + res.Text + " ";
                return f;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int n = Convert.ToInt32(nInput.Text);
            resOutput.Text = n.ToString();
            fibbLabel.Text = fib(n, progressBar1, resOutput).ToString();
        }
    }
}
