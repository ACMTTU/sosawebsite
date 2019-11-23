using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;
using SoSAWebsite.Databases;

namespace SoSAWebsite.Data
{
    public class WeatherForecastService
    {
        /// <summary>
        /// Here is an example of how you would connect to a database in a service that you create
        /// </summary>
        /// <param name="factory">The factory for creating ContainerManagers</param>
        public WeatherForecastService(ContainerManagerFactory factory)
        {
            ContainerManager manager = factory.GetContainerManager();
            Container container = manager.GetContainer(ContainerManager.DatabaseContainers.Users);
            Console.WriteLine(container.Id);
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
