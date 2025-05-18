using Azure.Storage.Blobs;
using System;
using System.IO;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        string blobStorageConnectionString = "DefaultEndpointsProtocol=http;AccountName=devstoreaccount1;AccountKey=Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==;BlobEndpoint=http://127.0.0.1:5050/devstoreaccount1;QueueEndpoint=http://127.0.0.1:10001/devstoreaccount1;TableEndpoint=http://127.0.0.1:10002/devstoreaccount1";
        string containerName = "samples";
        string downloadDirectory = "downloads";

        // Create download directory if it doesn't exist
        Directory.CreateDirectory(downloadDirectory);

        // Create blob container client
        var blobServiceClient = new BlobServiceClient(blobStorageConnectionString);
        var containerClient = blobServiceClient.GetBlobContainerClient(containerName);

        Console.WriteLine($"Listing blobs in container '{containerName}'...");
        
        // List all blobs in the container
        await foreach (var blobItem in containerClient.GetBlobsAsync())
        {
            Console.WriteLine($"Found blob: {blobItem.Name}");
            
            // Get blob client
            var blobClient = containerClient.GetBlobClient(blobItem.Name);
            
            // Download the blob
            string downloadPath = Path.Combine(downloadDirectory, blobItem.Name);
            Console.WriteLine($"Downloading {blobItem.Name} to {downloadPath}...");
            
            await blobClient.DownloadToAsync(downloadPath);
            Console.WriteLine($"Downloaded {blobItem.Name} successfully.");
        }

        Console.WriteLine("Download complete. Press any key to exit...");
        Console.ReadKey();
    }
}
