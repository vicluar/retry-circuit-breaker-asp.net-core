using Resilient.WebApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Resilient.WebApp.Services
{
    public interface IWheaterForecastService
    {
        Task<IEnumerable<WeatherForecast>> GetForecasts();
    }
}
