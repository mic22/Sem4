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

namespace Edytor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            if (openFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                richTextBox1.Text = File.ReadAllText(openFileDialog1.FileName);
                this.Text = Path.GetFileName(openFileDialog1.FileName) + " - Edytor";
            }

        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.BackColor = Color.White;
            richTextBox1.ForeColor = Color.Black;
        }

        private void darkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.BackColor = Color.Black;
            richTextBox1.ForeColor = Color.Silver;
        }

        private void pinkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.BackColor = Color.Pink;
            richTextBox1.ForeColor = Color.Red;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.ShowDialog();
            if (sfd.FileName != "")
            {
                richTextBox1.SaveFile(sfd.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.ShowDialog();
            if (sfd.FileName != "")
            {
                richTextBox1.SaveFile(sfd.FileName, RichTextBoxStreamType.PlainText);
            }
        }
    }
}
