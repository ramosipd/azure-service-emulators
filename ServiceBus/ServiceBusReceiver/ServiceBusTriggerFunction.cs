using Azure.Messaging.ServiceBus;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System;
using System.Text.Json;

public class ServiceBusTriggerFunction
{
    private readonly ILogger<ServiceBusTriggerFunction> _logger;

    public ServiceBusTriggerFunction(ILogger<ServiceBusTriggerFunction> logger)
    {
        _logger = logger;
    }

    [Function("ServiceBusTriggerFunction")]
    public void Run([ServiceBusTrigger("queue1", Connection = "ServiceBusConnection")] ServiceBusReceivedMessage message)
    {
        try
        {
            var messageBody = message.Body.ToString();
            var timestamp = message.ApplicationProperties.ContainsKey("Timestamp") 
                ? message.ApplicationProperties["Timestamp"] 
                : "Not specified";
            var messageType = message.ApplicationProperties.ContainsKey("MessageType")
                ? message.ApplicationProperties["MessageType"]
                : "Unknown";

            _logger.LogInformation($"Received message: {messageBody}");
            _logger.LogInformation($"Message Type: {messageType}");
            _logger.LogInformation($"Timestamp: {timestamp}");
            _logger.LogInformation($"Message ID: {message.MessageId}");
            _logger.LogInformation($"Delivery Count: {message.DeliveryCount}");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error processing message: {ex.Message}");
            throw;
        }
    }
}