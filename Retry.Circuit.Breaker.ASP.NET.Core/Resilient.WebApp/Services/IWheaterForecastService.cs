using Resilient.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resilient.WebApp.Services
{
    public interface IWheaterForecastService
    {
        IEnumerable<WeatherForecast> GetForecasts();
    }
}
