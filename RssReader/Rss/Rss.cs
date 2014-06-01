using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RssReader
{
    public class Item
    {
        public string title { get; set; }
        public string description { get; set; }
        public DateTime pub_date { get; set; }
        public string img { get; set; }
    }

    public class FeedUrl
    {
        public string url { get; set; }

        public FeedUrl(string url)
        {
            this.url = url;
        }
    }

    public class Reader
    {
        public List<FeedUrl> feeds { get; set; }

        public Reader()
        {
            this.feeds = new List<FeedUrl>();
        }
    }
    public class Feed
    {
        public string url { get; set; }
        private XDocument feed = null;

        public bool load(string url = null)
        {
            try
            {
                this.feed = XDocument.Load(url == null ? this.url : url);
            }
            catch (Exception e)
            {
                this.feed = null;
            }

            return this.feed != null ? true : false;
        }

        public List<Item> fetch(string item = "item", string title = "title", string desc = "description", string pub_date = "pubDate")
        {
            List<Item> list = new List<Item>();
            var items = this.feed.Descendants(item)
            .Select(x => new
            {
                Title = x.Element(title).Value,
                Description = x.Element(desc).Value,
                PublicationDate = x.Element(pub_date).Value
            });

            foreach (var elem in items)
            {
                string thumb = Regex.Match(elem.Description, "<img.+?src=[\"'](.+?)[\"'].*?>", RegexOptions.IgnoreCase).Groups[1].Value;

                var rss_item = new Item()
                {
                    title = elem.Title,
                    description = Regex.Replace(elem.Description, @"<(.|\n)*?>", String.Empty),
                    pub_date = Convert.ToDateTime(elem.PublicationDate),
                    img = thumb
                };

                list.Add(rss_item);
            }

            return list;
        }
    }
}
