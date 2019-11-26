using Microsoft.Azure.Cosmos;
using System.Threading.Tasks;
using System;

namespace SoSAWebsite.Databases {
    public class ContainerManager {
        private readonly Database database;
        public enum DatabaseContainers {
            Users,
            Projects,
            ProjectLeads,
            ProjectContributors,
            Events,
            EventAttendees
        }

        public ContainerManager(CosmosClient client, string databaseName)
        {
            database = client.GetDatabase(databaseName);
        }

        public Container GetContainer(DatabaseContainers option)
        {
            return database.GetContainer(Enum.GetName(typeof(DatabaseContainers), option));
        }
    }
}