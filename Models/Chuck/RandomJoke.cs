using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SovTechTest.Models.Search;

namespace SovTechTest.Models.Chuck
{
    public class RandomJoke
    {
        public List<string> categories { get; set; }
        public DateTime created_at { get; set; }
        public string icon_url { get; set; }
        public string id { get; set; }
        public DateTime updated_at { get; set; }
        public string url { get; set; }
        public string value { get; set; }
    }
}
