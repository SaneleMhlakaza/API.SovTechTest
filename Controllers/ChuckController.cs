using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using SovTechTest.Models.Chuck;
using SovTechTest.Models.Link;

namespace SovTechTest.Controllers
{
    [Route("/[controller]/categories")]
    [ApiController]
    public class ChuckController : ControllerBase
    {
        private UrlSettings _urlsettings;

        public ChuckController(IOptions<UrlSettings> settings)
        {
            _urlsettings = settings.Value;
        }

        [HttpGet]
        
        public IEnumerable<string> GetCategories()
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    var categories = client.DownloadString(_urlsettings.ChuckCategoriesUrl);
                    return JsonConvert.DeserializeObject<List<string>>(categories);
                }
            }
            catch (Exception ex)
            {
                return new List<string> { ex.Message };
            }

        }

        [HttpGet("{category}")]
        
        public RandomJoke GetRandomJoke(string category)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    var joke = client.DownloadString(_urlsettings.ChuckRandomJokeUrl+ category);
                    return JsonConvert.DeserializeObject<RandomJoke>(joke);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
