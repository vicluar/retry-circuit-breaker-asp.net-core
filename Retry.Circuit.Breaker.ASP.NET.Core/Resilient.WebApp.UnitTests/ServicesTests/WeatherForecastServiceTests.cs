using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Resilient.WebApp.Services;

namespace Resilient.WebApp.UnitTests.ServicesTests
{
    public class WeatherForecastServiceTests
    {
        private readonly IWheaterForecastService _sut;

        public WeatherForecastServiceTests()
        {
            _sut = new WeatherForecastService();
        }

        [Test]
        public void Do_Return_A_List_Of_Weather_Forecasts()
        {
            var forecasts = _sut.GetForecasts();

            Assert.IsNotNull(forecasts);
            Assert.IsTrue(forecasts.Count() > 0);
        }
    }
}
