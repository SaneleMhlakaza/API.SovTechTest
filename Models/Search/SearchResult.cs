using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPITest.Models.Search
{
    public class SearchResult
    {
        public List<ISearchRecord> Results { get; set; }
    }
}
