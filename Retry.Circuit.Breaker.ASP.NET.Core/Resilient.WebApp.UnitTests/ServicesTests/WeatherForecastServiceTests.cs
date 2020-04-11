using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;
using NUnit.Framework;
using Resilient.WebApp.Services;

namespace Resilient.WebApp.UnitTests.ServicesTests
{
    public class WeatherForecastServiceTests
    {
        private readonly IWheaterForecastService _sut;

        public WeatherForecastServiceTests()
        {
            var httpClient = new HttpClient(GetHttpMessageHandler());
            var logger = GetMockLogger();

            _sut = new WeatherForecastService(logger, httpClient);
        }

        [Test]
        public void Do_Return_A_List_Of_Weather_Forecasts()
        {
            var forecasts = _sut.GetForecasts().Result;

            Assert.IsNotNull(forecasts);
            Assert.IsTrue(forecasts.Count() > 0);
        }

        [Test]
        public void Return_Valid_Weather_Forecast_Objects()
        {
            var forecasts = _sut.GetForecasts().Result;
            var firstForecast = forecasts.FirstOrDefault();

            Assert.IsNotNull(firstForecast);
            Assert.IsFalse(string.IsNullOrWhiteSpace(firstForecast.Summary));
            Assert.IsTrue(firstForecast.Date != new DateTime(0001, 01, 01));
        }

        private HttpMessageHandler GetHttpMessageHandler()
        {
            var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            handlerMock
               .Protected()
               .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>()
               )
               .ReturnsAsync(new HttpResponseMessage()
               {
                   StatusCode = HttpStatusCode.OK,
                   Content = new StringContent("[{'date':'2020-04-11T23:38:57.9358192+02:00','temperatureC':-2,'temperatureF':29,'summary':'Mild'}]"),
               })
               .Verifiable();

            return handlerMock.Object;
        }

        private ILogger<WeatherForecastService> GetMockLogger()
        {
            var mockLogger = new Mock<ILogger<WeatherForecastService>>();

            return mockLogger.Object;
        }
    }
}
