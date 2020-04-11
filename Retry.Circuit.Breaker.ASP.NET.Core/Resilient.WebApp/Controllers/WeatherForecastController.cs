using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Resilient.WebApp.Services;

namespace Resilient.WebApp.Controllers
{
    public class WeatherForecastController : Controller
    {
        private readonly IWheaterForecastService _weatherForecastService;

        public WeatherForecastController(IWheaterForecastService wheaterForecastService) =>
            (_weatherForecastService) = (wheaterForecastService);

        public async Task<IActionResult> Index()
        {
            var forecasts = await _weatherForecastService.GetForecasts();

            return View(forecasts);
        }
    }
}