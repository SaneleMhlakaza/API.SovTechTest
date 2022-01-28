using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SovTechTest.Models.Chuck;

namespace SovTechTest.Models.Search
{
    public class ChuckSearchRecord : ISearchRecord
    {
        public string ResultsApi { get; set; }
        public List<RandomJoke> Records { get; set; }
    }
}
