using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Microsoft.Azure.Cosmos;


namespace SoSAWebsite.Application.Data
{
    public class UserService
    {

        private readonly Container container;

        /// <summary>
        /// Connect to the database
        /// </summary>
        /// <param name="cf"></param>
        public UserService(ContainerFactory cf)
        {
            container = cf.GetContainer(DatabaseContainers.Users);
        }

        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="user"> A pre-created user to be added to the DB </param>
        public void createUser(Models.User user)
        {
            container.CreateItemAsync<Models.User>(user);
        }

        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="uid"> A new user's ID </param>
        /// <param name="udisplayName"> A new user's display name </param>
        /// <param name="uGradDate"> A new user's graduation date </param>
        public async void createUser(String uid, String udisplayName, DateTime uGradDate)
        {
            Models.User toBeAdded = new Models.User();
            toBeAdded.id = uid;
            toBeAdded.displayName = udisplayName;
            toBeAdded.graduationDate = uGradDate;

            await container.CreateItemAsync<Models.User>(toBeAdded);
        }

        /// <summary>
        /// Get a specific user by their unique ID
        /// </summary>
        /// <param name="id"> A user's ID </param>
        public async Task<Models.User> readUser(String id)
        {
            PartitionKey pk = new PartitionKey(id);
            Models.User aUser = null;

            try
            {
                ItemResponse<Models.User> userItemResponse = await container.ReadItemAsync<Models.User>(id, pk);
                aUser = userItemResponse.Resource;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }


            return aUser;
        }

        public void updateUser()
        {

        }

        public void deleteUser()
        {

        }
    }
}
