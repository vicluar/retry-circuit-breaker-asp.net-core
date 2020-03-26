using Resilient.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resilient.WebApp.Services
{
    public class WeatherForecastService : IWheaterForecastService
    {
        public IEnumerable<WeatherForecast> GetForecasts()
        {
            return new List<WeatherForecast>
            {
                new WeatherForecast(DateTime.Now, 2, 2, "Sunny")
            };
        }
    }
}
