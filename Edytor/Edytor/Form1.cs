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
        string fileName;
        bool isRtf = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            if (openFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                if (Path.GetExtension(openFileDialog1.FileName) == ".rtf")
                {
                    richTextBox1.Rtf = File.ReadAllText(openFileDialog1.FileName);
                    this.isRtf = true;
                }
                else
                    richTextBox1.Text = File.ReadAllText(openFileDialog1.FileName);

                this.fileName = openFileDialog1.FileName;
                toolStripStatusLabel1.Text = "File opened " + this.fileName;
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

        private void saveAsDialog()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.ShowDialog();
            if (sfd.FileName != "")
            {
                richTextBox1.SaveFile(sfd.FileName, RichTextBoxStreamType.PlainText);
                this.fileName = sfd.FileName;
                this.isRtf = (Path.GetExtension(this.fileName) == ".rtf") ? true : false;
                toolStripStatusLabel1.Text = "File saved as " + this.fileName;
            }        
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(this.fileName))
            {
                if(this.isRtf)
                    richTextBox1.SaveFile(this.fileName);
                else
                    richTextBox1.SaveFile(this.fileName, RichTextBoxStreamType.PlainText);
                toolStripStatusLabel1.Text = "File saved";
            }
            else
            {
                saveAsDialog();
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveAsDialog();
        }

        private void boldItalicUnderline(object sender)
        {
            if (richTextBox1.SelectedText != null && richTextBox1.SelectedText != "")
            {

                FontStyle req;
                if (sender == toolStripLabel1) { req = FontStyle.Bold; }
                else if (sender == toolStripLabel2) { req = FontStyle.Italic; }
                else if (sender == toolStripLabel3) { req = FontStyle.Strikeout; }
                else { req = FontStyle.Underline; }
                Font f = richTextBox1.SelectionFont;
                FontStyle s;
                if (f != null)
                {

                    s = richTextBox1.SelectionFont.Style;
                    if ((f.Style & req) != 0) { s = s & (~req); }
                    else { s = s | req; }
                    richTextBox1.SelectionFont = new Font(f.FontFamily, f.Size, s);

                }
                else
                {

                    int start = richTextBox1.SelectionStart; int l = richTextBox1.SelectionLength;
                    for (int i = start; i < start + l; i++)
                    {

                        richTextBox1.SelectionStart = i; richTextBox1.SelectionLength = 1;
                        f = richTextBox1.SelectionFont;
                        s = richTextBox1.SelectionFont.Style;
                        if ((f.Style & req) != 0) { s = s & (~req); }
                        else { s = s | req; }
                        richTextBox1.SelectionFont = new Font(f.FontFamily, f.Size, s);

                    }

                    richTextBox1.SelectionStart = start; richTextBox1.SelectionLength = l;

                }

            }        
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            boldItalicUnderline(sender);
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            boldItalicUnderline(sender);
        }

        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            boldItalicUnderline(sender);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.fileName = "";
            richTextBox1.Text = "";
            richTextBox1.Rtf = "";
            toolStripStatusLabel1.Text = "File created";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
