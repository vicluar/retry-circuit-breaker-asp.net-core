using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resilient.WebApp.Models
{
    public class WeatherForecast
    {
        public DateTime Date { get; private set; }
        public int TemperatureInCelsius { get; private set; }
        public int TemperatureInFahrenheit { get; private set; }
        public string Summary { get; private set; }

        public WeatherForecast(DateTime date, int temperatureC,
            int temperatureF, string summary) =>
            (Date, TemperatureInCelsius, TemperatureInFahrenheit, Summary) =
            (date, temperatureC, temperatureF, summary);
    }
}
