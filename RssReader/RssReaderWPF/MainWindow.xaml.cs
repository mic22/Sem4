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
using System.Windows.Navigation;
using System.Windows.Shapes;
using RssReader;

namespace RssReaderWPF
{
    public partial class MainWindow : Window
    {
        public Reader app = new Reader();
        public Window manage_feeds;
        public MainWindow()
        {
            InitializeComponent();

            this.manage_feeds = new ManageFeeds(this.app);

            app.feeds.Add(new FeedUrl(@"http://www.skysports.com/rss/0,20514,12183,00.xml"));
            app.feeds.Add(new FeedUrl(@"http://sport.wp.pl/kat,1035299,rss.xml"));
            app.feeds.Add(new FeedUrl(@"http://spfddort.wp.pl/kat,1035299,rss.xml"));

            foreach (var feed in app.feeds)
            {
                
            }

            /*var feed = new Feed();
            feed.url = app.feeds[1].url;
            if (feed.load())
            {
                List<Item> items = feed.fetch("item", "title", "description", "pubDate");
                foreach (var item in items)
                {
                    Console.WriteLine(item.title);
                    Console.WriteLine(item.img);
                    Console.WriteLine(item.pub_date);
                    Console.WriteLine(item.description);
                }
            }*/
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.manage_feeds.ShowDialog();
        }
    }
}
