using System;
using System.Linq;
using System.Threading.Tasks;
using Models;
using SoSAWebsite.Application.Data.ContainerManager;

namespace SoSAWebsite.Application.Data
{
    public class FooService
    {
        /// <summary>
        /// Example for connecting to the database
        /// </summary>
        /// <param name="containerManagerFactory"></param>
        public FooService(ContainerManagerFactory containerManagerFactory)
        {
            var containerManager = containerManagerFactory.GetContainerManager();
            var container = containerManager.GetContainer(DatabaseContainers.Users);
            container.CreateItemAsync<User>(new User() { });
        }
    }
}
