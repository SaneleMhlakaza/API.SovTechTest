using System.Collections.Generic;
using SovTechTest.Iterfaces.Search;
using SovTechTest.Models.Chuck;

namespace SovTechTest.Models.Search
{
    public class ChuckSearchRecord : ISearchRecord
    {
        public string ResultsApi { get; set; }
        public List<RandomJoke> Records { get; set; }
    }
}
