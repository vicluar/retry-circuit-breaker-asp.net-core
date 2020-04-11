﻿using Newtonsoft.Json;
using Resilient.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Resilient.WebApp.Services
{
    public class WeatherForecastService : IWheaterForecastService
    {
        private const string BASE_URI = "https://localhost:44341";
        private readonly HttpClient _httpClient;

        public WeatherForecastService(HttpClient httpClient) =>
            (_httpClient) = (httpClient);

        public async Task<IEnumerable<WeatherForecast>> GetForecasts()
        {
            var response = await _httpClient.GetAsync($"{BASE_URI}/weatherforecast");

            if (response.IsSuccessStatusCode)
            {
                var weatherForecasts = JsonConvert.DeserializeObject<List<WeatherForecast>>(response.Content.ReadAsStringAsync().Result);
                return weatherForecasts;
            }
            else
            {
                // TODO: Something went wrong with the http call.
                // Code to manage that scenario.
                return default;
            }
        }
    }
}
