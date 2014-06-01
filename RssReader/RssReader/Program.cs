using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RssReader;

namespace MyFancyRssReader
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new Reader();
            app.feeds.Add(@"http://www.skysports.com/rss/0,20514,12183,00.xml");
            app.feeds.Add(@"http://sport.wp.pl/kat,1035299,rss.xml");
            app.feeds.Add(@"http://spfddort.wp.pl/kat,1035299,rss.xml");

            var feed = new Feed();
            feed.url = app.feeds[1];
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
            }
            
        }
    }
}
