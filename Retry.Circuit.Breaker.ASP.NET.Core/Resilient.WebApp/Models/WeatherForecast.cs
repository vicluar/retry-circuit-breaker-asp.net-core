using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resilient.WebApp.Models
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }
        public int TemperatureInCelsius { get; set; }
        public int TemperatureInFahrenheit { get; set; }
        public string Summary { get; set; }
    }
}
