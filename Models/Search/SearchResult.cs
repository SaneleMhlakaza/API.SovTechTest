using SovTechTest.Iterfaces.Search;
using System.Collections.Generic;

namespace SovTechTest.Models.Search
{
    public class SearchResult
    {
        public List<ISearchRecord> Results { get; set; }
    }
}
