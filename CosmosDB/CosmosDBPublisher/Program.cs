using System;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;

class Program
{
    static async Task Main(string[] args)
    {
        var accountEndpoint = "https://localhost:8081/";
        var authKeyOrResourceToken = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";

        var options = new CosmosClientOptions
        {
            HttpClientFactory = () => new HttpClient(new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            }),
            ConnectionMode = ConnectionMode.Gateway
        };

        using CosmosClient client = new CosmosClient(accountEndpoint, authKeyOrResourceToken, options);

        Database database = await client.CreateDatabaseIfNotExistsAsync(
            id: "cosmicworks",
            throughput: 400
        );

        Container container = await database.CreateContainerIfNotExistsAsync(
            id: "products",
            partitionKeyPath: "/id"
        );
        
        var item = new {
            id = "68719518371",
            name = "Kiama classic surfboard"
        };

        await container.UpsertItemAsync(item);
    }
}