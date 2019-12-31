using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Models
using SoSAWebsite.Application.Data.ContainerManager;
using Microsoft.Azure.Cosmos;

namespace SoSAWebsite.Application.Data
{
    public class UserService
    {

        private Container container;

        /// <summary>
        /// Example for connecting to the database
        /// </summary>
        /// <param name="containerManagerFactory"></param>
        public UserService(ContainerManagerFactory containerManagerFactory)
        {
            var containerManager = containerManagerFactory.GetContainerManager();
            container = containerManager.GetContainer(DatabaseContainers.Users);
        }

        public void createUser()
        {

        }

        public void readUser()
        {

        }

        public void updateUser()
        {

        }

        public void deleteUser()
        {

        }
    }
}
