using DevExpress.Persistent.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crawler.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class CrawlDestination
    {
        public CrawlDestination()
        {

        }
        public string Url { get; set; }

        public string Source { get; set; }

        public string ContentElement { get; set; }

        public string ImageElement { get; set; }

        public string TitleElement { get; set; }

        public string SumaryElement { get; set; }

        public string DetailElement { get; set; }
    }
}
