using Microsoft.Azure.Cosmos;

namespace SoSAWebsite.Data {
    public class DatabaseConnector {
        public Container UserContainer {get; private set;}

        public DatabaseConnector(string databaseConnectionString) {
            CosmosClient client = new CosmosClient(databaseConnectionString);
            Database db = client.GetDatabase("SoSAWebsiteData");

            UserContainer = db.GetContainer("Users");
        }
    }
}