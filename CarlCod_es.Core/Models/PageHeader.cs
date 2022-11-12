using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace CarlCod_es.Core.Models
{
    public class PageHeader
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public bool HasSubtitle => !string.IsNullOrWhiteSpace(Subtitle);
        public IPublishedContent BackgroundImage { get; set; }
        public bool HasBackgroundImage => BackgroundImage != null;
        public string AuthorName { get; set; }
        public bool HasAuthor => !string.IsNullOrWhiteSpace(AuthorName);
        public DateTime? ArticleDate { get; set; }
        public bool IsArticle => ArticleDate.HasValue;

        public PageHeader(string name, string title,
            string subtitle, IPublishedContent backgroundImage,
            string authorName = null, DateTime? articleDate = null)
        {
            Name = name;
            Title = title;
            Subtitle = subtitle;
            BackgroundImage = backgroundImage;
            AuthorName = authorName;
            ArticleDate = articleDate;
        }
    }
}
