using Resilient.WebApp.Models;
using System.Collections.Generic;

namespace Resilient.WebApp.Services
{
    public interface IWheaterForecastService
    {
        IEnumerable<WeatherForecast> GetForecasts();
    }
}
