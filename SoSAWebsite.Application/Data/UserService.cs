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
        /// <param name="user"> A pre-created user to be added to the DB </param>
        public void createUser(User user)
        {
            container.CreateItemAsync<User>(user);
        }

        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="uid"> A new user's ID </param>
        /// <param name="udisplayName"> A new user's display name </param>
        /// <param name="uGradDate"> A new user's graduation date </param>
        public void createUser(String uid, String udisplayName, DateTime uGradDate)
        {
            User toBeAdded = new User();
            toBeAdded.id = uid;
            toBeAdded.displayName = udisplayName;
            toBeAdded.graduationDate = uGradDate;

            container.CreateItemAsync<User>(toBeAdded);
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
