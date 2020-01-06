using System;
using Microsoft.Azure.Cosmos;

namespace SoSAWebsite.Application.Data
{
    public class ContainerFactory
    {
        private const string databaseName = "SoSAWebsiteData";
        private readonly Database database;

        public Container GetContainer(DatabaseContainers option)
        {
            return database.GetContainer(Enum.GetName(typeof(DatabaseContainers), option));
        }

        public ContainerFactory(string connectionString)
        {
            var client = new CosmosClient(connectionString);
            this.database = client.GetDatabase(databaseName);
        }
    }

    public enum DatabaseContainers
    {
        Users,
        Projects,
        ProjectLeads,
        ProjectContributors,
        Events,
        EventAttendees
    }
}
