using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using SovTechTest.Models;
using SovTechTest.Models.Chuck;
using SovTechTest.Models.Link;
using SovTechTest.Models.Search;

namespace SovTechTest.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private UrlSettings _urlsettings;

        public SearchController(IOptions<UrlSettings> settings)
        {
            _urlsettings = settings.Value;
        }

        [HttpGet("{searchword}")]
        public async Task<SearchResult> Get(string searchword)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var search_urls = new string[] { _urlsettings.ChuckSearchUrl + searchword, _urlsettings.SwapiSearchUrl + searchword };
                    var search_results = await Task.WhenAll(search_urls.Select(url => client.GetAsync(url)));

                    SearchResult searchResults = new SearchResult
                    {
                        Results = new List<ISearchRecord>()
                    };

                    foreach(var search_result in search_results)
                    {
                        if (search_result.Content != null) {

                            
                            if (search_result.RequestMessage.RequestUri.Host.Contains("chucknorris"))
                            {
                                var jokesstring = await client.GetStringAsync(search_result.RequestMessage.RequestUri.ToString());
                                searchResults.Results.Add(new ChuckSearchRecord
                                {
                                    ResultsApi = search_result.RequestMessage.RequestUri.Host,
                                    Records = JsonConvert.DeserializeObject<List<RandomJoke>>(JsonConvert.DeserializeObject<JObject>(jokesstring)["result"].ToString())
                                });
                            }else
                            {
                                var peoplestring = await client.GetStringAsync(search_result.RequestMessage.RequestUri.ToString());
                                searchResults.Results.Add(new SwapiSearchRecord
                                {
                                    ResultsApi = search_result.RequestMessage.RequestUri.Host,
                                    Records = JsonConvert.DeserializeObject<List<Person>>(JsonConvert.DeserializeObject<JObject>(peoplestring)["results"].ToString())
                                });
                            }
                        }

                    }

                    return searchResults;
 
                }
            }
            catch (Exception ex)
             {
                throw new Exception(ex.Message);
            }
        }


    }
}
