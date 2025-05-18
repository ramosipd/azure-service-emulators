using Azure.Messaging.ServiceBus;
using System;
using System.Threading.Tasks;

class Program
{
    private const string ServiceBusConnectionString = "Endpoint=sb://localhost;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=SAS_KEY_VALUE;UseDevelopmentEmulator=true;";
    private const string QueueName = "queue1";

    static async Task Main(string[] args)
    {
        try
        {
            await SendMessageAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fatal error: {ex.Message}");
            if (ex.InnerException != null)
            {
                Console.WriteLine($"Inner error: {ex.InnerException.Message}");
            }
        }
    }

    static async Task SendMessageAsync()
    {
        await using var client = new ServiceBusClient(ServiceBusConnectionString);
        ServiceBusSender sender = client.CreateSender(QueueName);

        try
        {
            var message = new ServiceBusMessage("Hello from Service Bus Publisher!");
            message.ApplicationProperties.Add("Timestamp", DateTime.UtcNow);
            message.ApplicationProperties.Add("MessageType", "TestMessage");
            
            Console.WriteLine($"Sending message: {message.Body}");
            await sender.SendMessageAsync(message);
            Console.WriteLine("Message sent successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error sending message: {ex.Message}");
            throw;
        }
    }
}