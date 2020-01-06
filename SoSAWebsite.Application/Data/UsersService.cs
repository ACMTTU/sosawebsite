using System;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;

namespace SoSAWebsite.Application.Data
{
    public class UsersService
    {
        private readonly Container userContainer;
        
        public UsersService(ContainerFactory cf)
        {
            userContainer = cf.GetContainer(DatabaseContainers.Users);
        }
    }
}
