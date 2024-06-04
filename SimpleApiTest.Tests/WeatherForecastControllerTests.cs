using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using System.Net.Http;
using System.Text.Json;
using System.Collections.Generic;

namespace SimpleApiTest.Tests
{
    public class WeatherForecastControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly HttpClient _client;

        public WeatherForecastControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _client = _factory.CreateClient();
        }

        [Fact]
        public async Task Get_ReturnsSuccessStatusCodeAndCorrectContentType()
        {
            // Act
            var response = await _client.GetAsync("/WeatherForecast");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }

        [Fact]
        public async Task Get_ReturnsExpectedWeatherForecasts()
        {
            // Act
            var response = await _client.GetAsync("/WeatherForecast");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var weatherForecasts = JsonSerializer.Deserialize<List<WeatherForecast>>(responseString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            Assert.Equal(5, weatherForecasts.Count);
            Assert.All(weatherForecasts, forecast => Assert.Contains(forecast.Summary, new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" }));
        }
    }

    // You may need to add the WeatherForecast class here for the tests to compile.
    public class WeatherForecast
    {
        public DateTime Date { get; set; }
        public int TemperatureC { get; set; }
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
        public string Summary { get; set; }
    }
}
