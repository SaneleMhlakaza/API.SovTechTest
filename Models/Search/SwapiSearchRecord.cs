using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPITest.Models.Search
{
    public class SwapiSearchRecord : ISearchRecord
    {
        public string ResultsApi { get; set; }
        public List<Person> Records { get; set; }
    }
}
