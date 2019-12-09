using System;
using System.Linq;
using System.Threading.Tasks;
using Models;
using SoSAWebsite.Application.Data.ContainerManager;

namespace SoSAWebsite.Application.Data
{
    public class WeatherForecastService
    {
        /// <summary>
        /// Example for connecting to the database
        /// </summary>
        /// <param name="containerManagerFactory"></param>
        public WeatherForecastService(ContainerManagerFactory containerManagerFactory)
        {
            var containerManager = containerManagerFactory.GetContainerManager();
            var container = containerManager.GetContainer(DatabaseContainers.Users);
            container.CreateItemAsync<User>(new User() { });
        }
        

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
        {
            var rng = new Random();
            return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            }).ToArray());
        }
    }
}
