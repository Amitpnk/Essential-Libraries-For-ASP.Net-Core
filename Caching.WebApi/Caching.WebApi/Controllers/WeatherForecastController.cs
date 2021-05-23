using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caching.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly List<string> Summaries = new List<string> {
        
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };


        private readonly IDistributedCache _distributedCache;


        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            IDistributedCache distributedCache)
        {
            _logger = logger;
            _distributedCache = distributedCache;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var cacheKey = "weatherList";
            string serializedCustomerList;
            var weatherList = new List<string>();
            var redisCustomerList = await _distributedCache.GetAsync(cacheKey);
            if (redisCustomerList != null)
            {
                serializedCustomerList = Encoding.UTF8.GetString(redisCustomerList);
                weatherList = JsonConvert.DeserializeObject<List<string>>(serializedCustomerList);
            }
            else
            {
                weatherList = GetFromDb();

                serializedCustomerList = JsonConvert.SerializeObject(weatherList);
                redisCustomerList = Encoding.UTF8.GetBytes(serializedCustomerList);
                var options = new DistributedCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.Now.AddMinutes(10))
                    .SetSlidingExpiration(TimeSpan.FromMinutes(2));
                await _distributedCache.SetAsync(cacheKey, redisCustomerList, options);
            }
            return Ok(weatherList);
                                
        }

        private List<string> GetFromDb()
        {
            // Sample code getting from db
            return Summaries.ToList();
        }
    }
}
