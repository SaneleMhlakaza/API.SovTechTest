using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebAPITest.Models;
using WebAPITest.Models.Link;

namespace WebAPITest.Controllers
{
    [Route("/[controller]/people")]
    [ApiController]
    public class SwapiController : ControllerBase
    {
        private UrlSettings _urlsettings;

        public SwapiController(IOptions<UrlSettings> settings)
        {
            _urlsettings = settings.Value;
        }

        [HttpGet]
        public IEnumerable<Person> GetPeople()
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    var result= (JsonConvert.DeserializeObject<JObject>(client.DownloadString(_urlsettings.SwapiPeopleUrl)))["results"];
                    return JsonConvert.DeserializeObject<List<Person>>(result.ToString());
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
