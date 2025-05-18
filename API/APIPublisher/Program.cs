using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        using var client = new HttpClient { BaseAddress = new Uri("http://localhost:5000") };

        // Simulate GET request
        Console.WriteLine("Sending GET request...");
        var getResponse = await client.GetAsync("/api/resource");
        Console.WriteLine($"GET Response: {await getResponse.Content.ReadAsStringAsync()}");

        // Simulate POST request
        Console.WriteLine("Sending POST request...");
        var postData = new { key = "value" };
        var postContent = new StringContent(JsonSerializer.Serialize(postData), Encoding.UTF8, "application/json");
        var postResponse = await client.PostAsync("/api/resource", postContent);
        Console.WriteLine($"POST Response: {await postResponse.Content.ReadAsStringAsync()}");
    }
}
