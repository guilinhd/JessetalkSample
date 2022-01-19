using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using OptionsSample.Models;

namespace OptionsSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IOptionsSnapshot<Student> _student;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IOptionsSnapshot<Student> student)
        {
            _logger = logger;
            _student = student;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {

            Console.WriteLine("name is:{0}, age is:{1}", _student.Value.Name, _student.Value.Age);

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
