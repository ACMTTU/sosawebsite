using System;
using Microsoft.Azure.Cosmos;

namespace SoSAWebsite.Application.Data.ContainerManager
{
    public class ContainerManagerFactory
    {
        private readonly string connectionString;
        private const string databaseName = "SoSAWebsiteData";

        public ContainerManagerFactory(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public ContainerManager GetContainerManager()
        {
            return new ContainerManager(new CosmosClient(connectionString), databaseName);
        }
    }
}
