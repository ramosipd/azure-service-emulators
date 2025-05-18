using Azure;
using Azure.Messaging;
using Azure.Messaging.EventGrid;
using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        var client = new EventGridPublisherClient(
            new Uri("http://127.0.0.1:6500/topic1/api/events"),
            new AzureKeyCredential("fakeAccessKey"));

        var data = new
        {
            Message = "Hello from Event Grid Publisher!",
            Timestamp = DateTime.UtcNow
        };

        try
        {
            var cloudEvent = new CloudEvent(
                source: "/example/source",
                type: "MyEvent",
                data: BinaryData.FromObjectAsJson(data),
                dataContentType: "application/json")
                {
                    Subject = "test"
                };
 

            await client.SendEventAsync(cloudEvent);
            Console.WriteLine("CloudEvent sent successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error sending event: {ex.Message}");
        }
    }
}
