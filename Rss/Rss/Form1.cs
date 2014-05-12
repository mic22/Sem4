using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Rss
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var feed = XDocument.Load(@"http://www.computerweekly.com/rss/All-Computer-Weekly-content.xml");

            var items = feed.Descendants("item").Select(x => new
            {
                Title = x.Element("title").Value,
                Desc = x.Element("description").Value
            });

            foreach (var item in items)
            {
                textBox1.Text = textBox1.Text + "\n" + item.Title + "\n" + item.Desc + "\n\n";
            }
        }
    }
}
