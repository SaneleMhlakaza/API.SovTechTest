using SovTechTest.Iterfaces.Search;
using System.Collections.Generic;

namespace SovTechTest.Models.Search
{
    public class SwapiSearchRecord : ISearchRecord
    {
        public string ResultsApi { get; set; }
        public List<Person> Records { get; set; }
    }
}
