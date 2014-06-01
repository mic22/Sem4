using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using RssReader;
using System.ComponentModel;

namespace RssReaderWPF
{
    /// <summary>
    /// Interaction logic for ManageFeeds.xaml
    /// </summary>
    public partial class ManageFeeds : Window
    {
        public ManageFeeds(Reader app)
        {
            InitializeComponent();

            DataContext = new {
                Feeds = app.feeds
            };
        }
    }
}
