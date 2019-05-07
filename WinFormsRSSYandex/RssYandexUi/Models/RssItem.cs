using System;

namespace RssYandexUi.Models
{
    class RssItem
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public Uri Link { get; set; }

        public override string ToString()
        {
            return $"{Date.ToShortDateString()}: {Title}\n{Description}";
        }
    }
}
