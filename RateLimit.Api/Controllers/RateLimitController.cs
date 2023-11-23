using Microsoft.AspNetCore.Mvc;
using RateLimit.Api.Decorators;
using RateLimit.Api.ViewModels;

namespace RateLimit.Api.Controllers
{
    [ApiController]
    [Route("rate")]
    public class RateLimitController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<RateLimitController> _logger;

        public RateLimitController(ILogger<RateLimitController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "limit-request")]
        [RateLimit(MaxRequests = 3, TimeWindowInSeconds = 120)]
        public IEnumerable<WeatherForecast> Get()
        {
            _logger.LogInformation("vai ser bloqueado");
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost(Name = "limit-request")]
        [RateLimit(MaxRequests = 3, TimeWindowInSeconds = 120)]
        public IEnumerable<WeatherForecast> Post(int numero)
        {
            _logger.LogInformation("vai ser bloqueado");
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
