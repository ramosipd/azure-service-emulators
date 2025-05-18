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
        string fileName = "lorem.txt";
        string fileContent = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.";

        // Create dummy file
        await File.WriteAllTextAsync(fileName, fileContent);
        Console.WriteLine($"Generated file: {fileName}");

        // Create blob container client
        var blobServiceClient = new BlobServiceClient(blobStorageConnectionString);
        var containerClient = blobServiceClient.GetBlobContainerClient(containerName);
        var createResponse = await containerClient.CreateIfNotExistsAsync();
        if (createResponse != null)
        {
            Console.WriteLine($"Container '{containerName}' created.");
        }
        else
        {
            Console.WriteLine($"Container '{containerName}' already exists.");
        }

        // Upload file
        Console.WriteLine($"Uploading {fileName} to container '{containerName}'...");
        var blobClient = containerClient.GetBlobClient(fileName);
        using (var fileStream = File.OpenRead(fileName))
        {
            await blobClient.UploadAsync(fileStream, overwrite: true);
        }
        Console.WriteLine($"Uploaded {fileName} to container '{containerName}'.");
    }
}
