using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPITest.Models.Chuck;

namespace WebAPITest.Models.Search
{
    public class ChuckSearchRecord : ISearchRecord
    {
        public string ResultsApi { get; set; }
        public List<RandomJoke> Records { get; set; }
    }
}
