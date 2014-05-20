using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml.Linq;

namespace Planesia.Models
{
    public class RssReader
    {
        private static string _blogURL = "http://www.fauna-flora.org/news/feed/";
        public static IEnumerable<Rss> GetRssFeed()
        {
            try
            {
                XDocument feedXml = XDocument.Load(_blogURL);
                string pattern = @"<[^>]*?>";
                var feeds = from feed in feedXml.Descendants("item")
                            select new Rss
                            {
                                Title = feed.Element("title").Value,
                                Link = feed.Element("link").Value,
                                Description = Regex.Replace(Regex.Match(feed.Element("description").Value, @"^.{1,180}\b(?<!\s)").Value, pattern, "")
                            };
                return feeds;
            }
            catch (Exception e)
            {
                Rss error = new Rss();
                error.Link = e.Message.ToString();
                error.Title = "Your Connection Time Out";
                error.Description = "Please to check/reconnect your connection";
                throw;
            }
            
        }
    }
}