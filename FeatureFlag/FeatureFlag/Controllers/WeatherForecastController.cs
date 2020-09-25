using FeatureFlag.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeatureFlag.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IFeatureManager _featureManager;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IFeatureManagerSnapshot featureManager)
        {
            _logger = logger;
            _featureManager = featureManager;
        }

        [HttpGet]
        [FeatureGate(FeatureManagement.EnableWeatherGetApi)]
        public async Task<IEnumerable<WeatherForecast>> GetAsync()
        {
            var rng = new Random();

            if (await _featureManager.IsEnabledAsync(nameof(FeatureManagement.EnableMoreRecords)))
            {
                return Enumerable.Range(1, 50).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                })
                .ToArray();
            }
            else
            {
                return Enumerable.Range(1, 2).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                })
                .ToArray();
            }
        }


    }

}

