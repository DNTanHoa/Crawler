using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crawler
{
    class Program
    {
        static void Main(string[] args)
        {
            DataCrawler.FromUrl("https://nongnghiep.vn/", out dynamic data);
        }
    }

    public class DataCrawler
    {
        public static HtmlWeb html { get; set; }

        /// <summary>
        /// Lấy danh sách bài viết từ 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        public static void FromUrl(string url, out dynamic data)
        {
            data = null;
            if(html == null)
            {
                html = new HtmlWeb()
                {
                    AutoDetectEncoding = false,
                    OverrideEncoding = Encoding.UTF8
                };
            }

            HtmlDocument document = html.Load(url);

            var posts = document.DocumentNode.SelectNodes("//div[@class='news-home-item']");

            if(posts != null)
            {
                data = new List<dynamic>();

                foreach (var post in posts)
                {
                    dynamic item = new
                    {
                        detail = post.ChildNodes.FirstOrDefault(item => item.Name == "a")?.Attributes["href"].Value,
                        image = post.SelectSingleNode("//a")?.SelectSingleNode("//img")?.Attributes["src"].Value,
                        summary = post.SelectSingleNode("//div[@class='news-info']")?
                        .SelectSingleNode("//p[@class='main-intro']")?.InnerText.Trim(),
                        title = post.SelectSingleNode("//div[@class='news-info']")?
                            .SelectSingleNode("//h3")?.InnerText,
                        source = url,
                    };
                    data.Add(item);
                }
            }
        }

        public static void DetailFromUrl(string url, out dynamic data)
        {
            data = null;

            if (html == null)
            {
                html = new HtmlWeb()
                {
                    AutoDetectEncoding = false,
                    OverrideEncoding = Encoding.UTF8
                };
            }
        }
    }
}

