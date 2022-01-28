using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPITest.Models.Search;

namespace WebAPITest.Models.Chuck
{
    public class RandomJoke:IResponse
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
