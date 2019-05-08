using RssYandexUi.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Threading.Tasks;
using System.Xml;

namespace RssYandexUi.Services
{
    class RssService
    {
        private readonly string _address;

        //ctor
        public RssService(string address)
        {
            if (string.IsNullOrEmpty(address))
                throw new ArgumentException(nameof(address));

            _address = address;
        }

        private SyndicationFeed GetFeed()
        {
            SyndicationFeed feed = null;
            try
            {
                XmlReader reader = XmlReader.Create(_address);
                feed = SyndicationFeed.Load(reader);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Ошибка получения RSS: {ex.Message}");
                feed = new SyndicationFeed();
            }

            return feed;
        }

        internal async Task<List<RssItem>> GetRssItems()
        {
            //получаем из Yandex данные
            var feed = await Task.Run(GetFeed);

            //формируем список тем
            List<RssItem> result = new List<RssItem>();
            foreach (SyndicationItem item in feed.Items)
            {
                var rssItem = new RssItem
                {
                    Id = item.Id,
                    Title = item.Title.Text,
                    Description = item.Summary.Text,
                    Date = item.PublishDate.Date,
                    Link = item.Links.First().Uri
                };

                result.Add(rssItem);
            }

            return result;
        }
        
    }
}
