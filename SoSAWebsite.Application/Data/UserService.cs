using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

using SoSAWebsite.Application.Data.ContainerManager;

namespace SoSAWebsite.Application.Data
{
    public class UserService
    {

        private Microsoft.Azure.Cosmos.Container container;

        /// <summary>
        /// Connect to the database
        /// </summary>
        /// <param name="containerManagerFactory"></param>
        public UserService(ContainerManagerFactory containerManagerFactory)
        {
            var containerManager = containerManagerFactory.GetContainerManager();
            container = containerManager.GetContainer(DatabaseContainers.Users);
        }

        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="user">A pre-created user to be added to the DB</param>
        public void createUser(User user)
        {
            container.CreateItemAsync<User>(user);
        }

        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="containerManagerFactory"></param>
        public void createUser(String uid, String udisplayName, DateTime uGradDate)
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
