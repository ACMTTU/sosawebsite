using Microsoft.Azure.Cosmos;

namespace SoSAWebsite.Data
{
    public class ConnectionFactory
    {
        private readonly string connectionString;
        private const string databaseName = "SoSAWebsiteData";

        public ConnectionFactory(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public ContainerManager GetCollectionManager()
        {
            return new ContainerManager(new CosmosClient(connectionString), databaseName);
        }
    }
}